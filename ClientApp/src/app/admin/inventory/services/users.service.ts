import {DecimalPipe} from '@angular/common';
import {HttpClient} from '@angular/common/http';
import {Injectable, PipeTransform} from '@angular/core';
import {BehaviorSubject, debounceTime, delay, Observable, of, Subject, switchMap, tap} from 'rxjs';
import {config} from "../../../../env/config.prod";
import {ManagementUsersResponse} from '../../../core/interfaces/Security/Response/managementUsersResponse';
import {RolesListResponse} from '../../../core/interfaces/Security/Response/rolesListResponse';
import {UsersListResponse} from '../../../core/interfaces/Security/Response/usersListResponse';
import {UserForCreationDto} from '../../../core/interfaces/Security/userForCreationDto';
import {SortColumn, SortDirection} from '@core/shared/directives/sortable.directive';
import {SearchResult} from '../../../core/interfaces/search-result';
import {State} from '../../../core/interfaces/state';
import {UserResponse} from '../../../core/interfaces/Security/Response/userResponse';

const compare = (v1: string | number, v2: string | number) => (v1 < v2 ? -1 : v1 > v2 ? 1 : 0);

function sort(users: ManagementUsersResponse[], column: SortColumn, direction: string): ManagementUsersResponse[] {
  if (direction === '' || column === '') {
    return users;
  } else {
    return [...users].sort((a: any, b: any) => {
      const res = compare(a[column], b[column]);
      return direction === 'asc' ? res : -res;
    });
  }
}

function matches(user: ManagementUsersResponse, term: string, pipe: PipeTransform) {
  return (
    user.userName.toLowerCase().includes(term.toLowerCase()) ||
    pipe.transform(user.id).includes(term)
  );
}

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private apiUrl = `${config.apiURL}users/`
  private _search$ = new Subject<void>();
  private _managementUsers$ = Array<ManagementUsersResponse>();
  private _state: State = {
    page: 1,
    pageSize: 5,
    searchTerm: '',
    sortColumn: '',
    sortDirection: '',
  };

  constructor(
    private pipe: DecimalPipe,
    private http: HttpClient,
  ) {
  }

  private _loading$ = new BehaviorSubject<boolean>(true);

  get loading$() {
    return this._loading$.asObservable();
  }

  private _users$ = new BehaviorSubject<ManagementUsersResponse[]>([]);

  get users$() {
    return this._users$.asObservable();
  }

  private _total$ = new BehaviorSubject<number>(0);

  get total$() {
    return this._total$.asObservable();
  }

  get page() {
    return this._state.page;
  }

  set page(page: number) {
    this._set({page});
  }

  get pageSize() {
    return this._state.pageSize;
  }

  set pageSize(pageSize: number) {
    this._set({pageSize});
  }

  get searchTerm() {
    return this._state.searchTerm;
  }

  set searchTerm(searchTerm: string) {
    this._set({searchTerm});
  }

  set sortColumn(sortColumn: SortColumn) {
    this._set({sortColumn});
  }

  set sortDirection(sortDirection: SortDirection) {
    this._set({sortDirection});
  }

  RetrieveData() {
    this.Get().subscribe((data) => {
      this._managementUsers$ = data;
      this._search$
        .pipe(
          tap(() => this._loading$.next(true)),
          debounceTime(200),
          switchMap(() => this._search()),
          delay(200),
          tap(() => this._loading$.next(false)),
        )
        .subscribe((result) => {
          this._users$.next(result.items);
          this._total$.next(result.total);
        });

      this._search$.next();
    });
  }

  Add(user: UserForCreationDto) {
    return this.http.post(this.apiUrl, user);
  }

  Update(id: string, user: UserForCreationDto) {
    return this.http.put(`${this.apiUrl}${id}`, user);
  }

  GetManagement(id: string): Observable<UserResponse> {
    return this.http.get<UserResponse>(`${this.apiUrl}${id}`);
  }

  Get(): Observable<ManagementUsersResponse[]> {
    return this.http.get<ManagementUsersResponse[]>(`${this.apiUrl}`);
  }

  GetList(): Observable<UsersListResponse[]> {
    return this.http.get<UsersListResponse[]>(`${this.apiUrl}usersList`);
  }

  GetRolesList(): Observable<RolesListResponse[]> {
    return this.http.get<RolesListResponse[]>(`${this.apiUrl}rolesList`);
  }

  Delete(id: string) {
    return this.http.delete(`${this.apiUrl}${id}`);
  }

  DeleteRoles(id: string, roleId: string) {
    return this.http.delete(`${this.apiUrl}${id}/roles/${roleId}`);
  }

  private _set(patch: Partial<State>) {
    Object.assign(this._state, patch);
    this._search$.next();
  }

  private _search(): Observable<SearchResult> {
    const {sortColumn, sortDirection, pageSize, page, searchTerm} = this._state;

    // 1. sort
    let items = sort(this._managementUsers$, sortColumn, sortDirection);

    // 2. filter
    items = items.filter((user) => matches(user, searchTerm, this.pipe));
    const total = items.length;

    // 3. paginate
    items = items.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({items, total});
  }
}

import { DecimalPipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable, PipeTransform } from '@angular/core';
import { BehaviorSubject, debounceTime, delay, Observable, of, Subject, switchMap, tap } from 'rxjs';
import { config } from "../../env/config.prod";
import { ManagementUsersResponse } from '../../interfaces/Security/Response/managementUsersResponse';
import { RolesListResponse } from '../../interfaces/Security/Response/rolesListResponse';
import { UsersListResponse } from '../../interfaces/Security/Response/usersListResponse';
import { UserForCreationDto } from '../../interfaces/Security/userForCreationDto';
import { SortColumn, SortDirection } from '../directives/sortable.directive';
import { SearchResult } from './search-result';
import { State } from './state';
import { UserResponse } from '../../interfaces/Security/Response/userResponse';

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
  private _loading$ = new BehaviorSubject<boolean>(true);
  private _search$ = new Subject<void>();
  private _users$ = new BehaviorSubject<ManagementUsersResponse[]>([]);
  private _managementUsers$ = Array<ManagementUsersResponse>();
  private _total$ = new BehaviorSubject<number>(0);

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

  get users$() {
    return this._users$.asObservable();
  }

  get total$() {
    return this._total$.asObservable();
  }
  get loading$() {
    return this._loading$.asObservable();
  }
  get page() {
    return this._state.page;
  }
  get pageSize() {
    return this._state.pageSize;
  }
  get searchTerm() {
    return this._state.searchTerm;
  }

  set page(page: number) {
    this._set({ page });
  }
  set pageSize(pageSize: number) {
    this._set({ pageSize });
  }
  set searchTerm(searchTerm: string) {
    this._set({ searchTerm });
  }
  set sortColumn(sortColumn: SortColumn) {
    this._set({ sortColumn });
  }
  set sortDirection(sortDirection: SortDirection) {
    this._set({ sortDirection });
  }

  private _set(patch: Partial<State>) {
    Object.assign(this._state, patch);
    this._search$.next();
  }

  private _search(): Observable<SearchResult> {
    const { sortColumn, sortDirection, pageSize, page, searchTerm } = this._state;

    // 1. sort
    let items = sort(this._managementUsers$, sortColumn, sortDirection);

    // 2. filter
    items = items.filter((user) => matches(user, searchTerm, this.pipe));
    const total = items.length;

    // 3. paginate
    items = items.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({ items, total });
  }
}

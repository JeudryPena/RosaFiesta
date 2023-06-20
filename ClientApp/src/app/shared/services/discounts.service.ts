import { DecimalPipe } from '@angular/common';
import { Injectable, PipeTransform } from '@angular/core';
import { BehaviorSubject, Observable, Subject, debounceTime, delay, of, switchMap, tap } from 'rxjs';
import { SortColumn, SortDirection } from '../directives/sortable.directive';
import { HttpClient } from '@angular/common/http';
import { config } from "../../env/config.prod";
import { ManagementDiscountsResponse } from '../../interfaces/Product/Response/managementDiscountsResponse';
import { SearchResult } from './search-result';
import { State } from './state';
import { CategoryManagementResponse } from '../../interfaces/Product/Response/categoryManagementResponse';
import { UsersService } from './users.service';
import { DiscountDto } from '../../interfaces/Product/discountDto';

const compare = (v1: string | number, v2: string | number) => (v1 < v2 ? -1 : v1 > v2 ? 1 : 0);

function sort(discounts: ManagementDiscountsResponse[], column: SortColumn, direction: string): ManagementDiscountsResponse[] {
  if (direction === '' || column === '') {
    return discounts;
  } else {
    return [...discounts].sort((a: any, b: any) => {
      const res = compare(a[column], b[column]);
      return direction === 'asc' ? res : -res;
    });
  }
}

function matches(discount: ManagementDiscountsResponse, term: string, pipe: PipeTransform) {
  return (
    discount.name.toLowerCase().includes(term.toLowerCase()) ||
    pipe.transform(discount.code).includes(term)
  );
}

@Injectable({
  providedIn: 'root'
})
export class DiscountsService {
  private apiUrl = `${config.apiURL}discounts/`
  private _loading$ = new BehaviorSubject<boolean>(true);
  private _search$ = new Subject<void>();
  private _discounts$ = new BehaviorSubject<ManagementDiscountsResponse[]>([]);
  private _managementDiscounts$ = Array<ManagementDiscountsResponse>();
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
    private service: UsersService
  ) {
    this.RetrieveData();
  }

  RetrieveData() {
    this.GetDiscountsManagement().subscribe((data) => {
      this._managementDiscounts$ = data;
      this._managementDiscounts$.forEach(i => {
        this.service.UserName(i.createdBy).subscribe((data) => {
          i.createdBy = data.userName;
        });
        this.service.UserName(i.updatedBy).subscribe((data) => {
          i.updatedBy = data.userName;
        });
      });
      this._search$
        .pipe(
          tap(() => this._loading$.next(true)),
          debounceTime(200),
          switchMap(() => this._search()),
          delay(200),
          tap(() => this._loading$.next(false)),
        )
        .subscribe((result) => {
          this._discounts$.next(result.items);
          this._total$.next(result.total);
        });

      this._search$.next();
    });
  }

  AddDiscount(category: DiscountDto) {
    return this.http.post(this.apiUrl, category);
  }

  UpdateDiscount(code: string, category: DiscountDto) {
    return this.http.put(`${this.apiUrl}/${code}`, category);
  }

  GetManagementDiscount(code: string): Observable<ManagementDiscountsResponse> {
    return this.http.get<ManagementDiscountsResponse>(`${this.apiUrl}${code}management`);
  }

  GetDiscountsManagement(): Observable<ManagementDiscountsResponse[]> {
    return this.http.get<ManagementDiscountsResponse[]>(`${this.apiUrl}management`);
  }

  DeleteDiscount(code: string) {
    return this.http.get(`${this.apiUrl}${code}delete`);
  }

  get discounts$() {
    return this._discounts$.asObservable();
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
    let items = sort(this._managementDiscounts$, sortColumn, sortDirection);

    // 2. filter
    items = items.filter((discount) => matches(discount, searchTerm, this.pipe));
    const total = items.length;

    // 3. paginate
    items = items.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({ items, total });
  }
}


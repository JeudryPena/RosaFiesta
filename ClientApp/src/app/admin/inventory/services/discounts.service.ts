import {DecimalPipe} from '@angular/common';
import {HttpClient} from '@angular/common/http';
import {Injectable, PipeTransform} from '@angular/core';
import {BehaviorSubject, debounceTime, delay, Observable, of, Subject, switchMap, tap} from 'rxjs';
import {config} from "../../../../env/config.prod";
import {DiscountResponse} from '../../../core/interfaces/Product/Response/discountResponse';
import {ManagementDiscountsResponse} from '../../../core/interfaces/Product/Response/managementDiscountsResponse';
import {DiscountDto} from '../../../core/interfaces/Product/discountDto';
import {SortColumn, SortDirection} from '@core/shared/directives/sortable.directive';
import {SearchResult} from '../../../core/interfaces/search-result';
import {State} from '../../../core/interfaces/state';

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
    discount.value ||
    pipe.transform(discount.value).includes(term)
  );
}

@Injectable({
  providedIn: 'root'
})
export class DiscountsService {
  private apiUrl = `${config.apiURL}discounts/`
  private _search$ = new Subject<void>();
  private _managementDiscounts$ = Array<ManagementDiscountsResponse>();
  private _state: State = {
    page: 1,
    pageSize: 5,
    searchTerm: '',
    sortColumn: '',
    sortDirection: '',
  };

  constructor(
    private pipe: DecimalPipe,
    private http: HttpClient
  ) {
  }

  private _loading$ = new BehaviorSubject<boolean>(true);

  get loading$() {
    return this._loading$.asObservable();
  }

  private _discounts$ = new BehaviorSubject<ManagementDiscountsResponse[]>([]);

  get discounts$() {
    return this._discounts$.asObservable();
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
    this.GetDiscountsManagement().subscribe((data) => {
      this._managementDiscounts$ = data;
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

  getHotOffers(): Observable<DiscountResponse> {
    return this.http.get<DiscountResponse>(`${this.apiUrl}hotOffers`);
  }

  AddDiscount(discount: DiscountDto) {
    return this.http.post(this.apiUrl, discount);
  }

  UpdateDiscount(id: string, discount: DiscountDto) {
    return this.http.put(`${this.apiUrl}${id}`, discount);
  }

  GetManagementDiscount(id: string): Observable<ManagementDiscountsResponse> {
    return this.http.get<ManagementDiscountsResponse>(`${this.apiUrl}${id}/management`);
  }

  GetDiscountsManagement(): Observable<ManagementDiscountsResponse[]> {
    return this.http.get<ManagementDiscountsResponse[]>(`${this.apiUrl}management`);
  }

  GetOptionDiscount(id: string): Observable<DiscountResponse> {
    return this.http.get<DiscountResponse>(`${this.apiUrl}options/${id}`);
  }

  DeleteDiscount(id: string) {
    return this.http.delete(`${this.apiUrl}${id}`);
  }

  DeleteDiscountProducts(id: string, optionId: string | null) {
    if (!optionId)
      optionId = '';
    return this.http.delete(`${this.apiUrl}${id}/options/${optionId}`);
  }

  private _set(patch: Partial<State>) {
    Object.assign(this._state, patch);
    this._search$.next();
  }

  private _search(): Observable<SearchResult> {
    const {sortColumn, sortDirection, pageSize, page, searchTerm} = this._state;

    // 1. sort
    let items = sort(this._managementDiscounts$, sortColumn, sortDirection);

    // 2. filter
    items = items.filter((discount) => matches(discount, searchTerm, this.pipe));
    const total = items.length;

    // 3. paginate
    items = items.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({items, total});
  }
}

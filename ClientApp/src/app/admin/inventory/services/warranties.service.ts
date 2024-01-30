import {DecimalPipe} from '@angular/common';
import {HttpClient} from '@angular/common/http';
import {Injectable, PipeTransform} from '@angular/core';
import {BehaviorSubject, debounceTime, delay, Observable, of, Subject, switchMap, tap} from 'rxjs';
import {config} from "../../../../env/config.prod";
import {WarrantiesListResponse} from '../../../core/interfaces/Product/Response/warrantiesListResponse';
import {WarrantiesManagementResponse} from '../../../core/interfaces/Product/Response/warrantiesManagementResponse';
import {WarrantyResponse} from '../../../core/interfaces/Product/Response/warrantyResponse';
import {WarrantyDto} from '../../../core/interfaces/Product/warrantyDto';
import {SortColumn, SortDirection} from '@core/shared/directives/sortable.directive';
import {SearchResult} from '../../../core/interfaces/search-result';
import {State} from '../../../core/interfaces/state';
import {WarrantyPreviewResponse} from "@core/interfaces/Product/Response/warrantyPreviewResponse";

const compare = (v1: string | number, v2: string | number) => (v1 < v2 ? -1 : v1 > v2 ? 1 : 0);

function sort(warranties: WarrantiesManagementResponse[], column: SortColumn, direction: string): WarrantiesManagementResponse[] {
  if (direction === '' || column === '') {
    return warranties;
  } else {
    return [...warranties].sort((a: any, b: any) => {
      const res = compare(a[column], b[column]);
      return direction === 'asc' ? res : -res;
    });
  }
}

function matches(warranty: WarrantiesManagementResponse, term: string, pipe: PipeTransform) {
  return (
    warranty.name?.toLowerCase().includes(term.toLowerCase()) ||
    warranty.description?.toLowerCase().includes(term.toLowerCase()) ||
    warranty.type?.toLowerCase().includes(term.toLowerCase())
    || warranty.status?.toLowerCase().includes(term.toLowerCase())
  );
}

@Injectable({
  providedIn: 'root'
})
export class WarrantiesService {
  private apiUrl = `${config.apiURL}warranties/`
  private _search$ = new Subject<void>();
  private _managementWarranties$ = Array<WarrantiesManagementResponse>();
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

  private _warranties$ = new BehaviorSubject<WarrantiesManagementResponse[]>([]);

  get warranties$() {
    return this._warranties$.asObservable();
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
    this.GetWarrantiesManagement().subscribe((data) => {
      this._managementWarranties$ = data;
      this._search$
        .pipe(
          tap(() => this._loading$.next(true)),
          debounceTime(200),
          switchMap(() => this._search()),
          delay(200),
          tap(() => this._loading$.next(false)),
        )
        .subscribe((result) => {
          this._warranties$.next(result.items);
          this._total$.next(result.total);
        });

      this._search$.next();
    });
  }

  GetWarranty(warrantyId: string): Observable<WarrantyPreviewResponse> {
    return this.http.get<WarrantyPreviewResponse>(`${this.apiUrl}${warrantyId}/preview`);
  }

  GetWarrantyByProductId(productId: string): Observable<string> {
    return this.http.get<string>(`${this.apiUrl}${productId}product/${productId}/preview`);
  }

  AddWarranty(warranty: WarrantyDto) {
    return this.http.post(this.apiUrl, warranty);
  }

  UpdateWarranty(id: string, warranty: WarrantyDto) {
    return this.http.put(`${this.apiUrl}${id}`, warranty);
  }

  GetManagementWarranty(id: string): Observable<WarrantyResponse> {
    return this.http.get<WarrantyResponse>(`${this.apiUrl}${id}`);
  }

  GetWarrantiesManagement(): Observable<WarrantiesManagementResponse[]> {
    return this.http.get<WarrantiesManagementResponse[]>(`${this.apiUrl}management`);
  }

  GetWarrantiesList(): Observable<WarrantiesListResponse[]> {
    return this.http.get<WarrantiesListResponse[]>(`${this.apiUrl}warrantiesList`);
  }

  DeleteWarranty(id: string) {
    return this.http.delete(`${this.apiUrl}${id}`);
  }

  DeleteWarrantyProducts(id: string, productId: string) {
    return this.http.delete(`${this.apiUrl}${id}/products/${productId}`);
  }

  private _set(patch: Partial<State>) {
    Object.assign(this._state, patch);
    this._search$.next();
  }

  private _search(): Observable<SearchResult> {
    const {sortColumn, sortDirection, pageSize, page, searchTerm} = this._state;

    // 1. sort
    let items = sort(this._managementWarranties$, sortColumn, sortDirection);

    // 2. filter
    items = items.filter((discount) => matches(discount, searchTerm, this.pipe));
    const total = items.length;

    // 3. paginate
    items = items.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({items, total});
  }
}

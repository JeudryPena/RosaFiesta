import {DecimalPipe} from '@angular/common';
import {HttpClient} from '@angular/common/http';
import {Injectable, PipeTransform} from '@angular/core';
import {BehaviorSubject, debounceTime, delay, Observable, of, Subject, switchMap, tap} from 'rxjs';
import {config} from "../../../../env/config.prod";
import {SupplierResponse} from '../../../core/interfaces/Product/Response/supplierResponse';
import {SupplierDto} from '../../../core/interfaces/Product/supplierDto';
import {SortColumn, SortDirection} from '@core/shared/directives/sortable.directive';
import {SearchResult} from '../../../core/interfaces/search-result';
import {State} from '../../../core/interfaces/state';
import {SuppliersListResponse} from '../../../core/interfaces/Product/Response/suppliersListResponse';

const compare = (v1: string | number, v2: string | number) => (v1 < v2 ? -1 : v1 > v2 ? 1 : 0);

function sort(suppliers: SupplierResponse[], column: SortColumn, direction: string): SupplierResponse[] {
  if (direction === '' || column === '') {
    return suppliers;
  } else {
    return [...suppliers].sort((a: any, b: any) => {
      const res = compare(a[column], b[column]);
      return direction === 'asc' ? res : -res;
    });
  }
}

function matches(supplier: SupplierResponse, term: string, pipe: PipeTransform) {
  return (
    supplier.name?.toLowerCase().includes(term.toLowerCase()) ||
    supplier.email?.toLowerCase().includes(term.toLowerCase()) ||
    supplier.phone?.toLowerCase().includes(term.toLowerCase()) ||
    supplier.address?.toLowerCase().includes(term.toLowerCase())
  );
}

@Injectable({
  providedIn: 'root'
})
export class SuppliersService {
  private apiUrl = `${config.apiURL}suppliers/`
  private _search$ = new Subject<void>();
  private _managementSuppliers$ = Array<SupplierResponse>();
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

  private _suppliers$ = new BehaviorSubject<SupplierResponse[]>([]);

  get suppliers$() {
    return this._suppliers$.asObservable();
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
      this._managementSuppliers$ = data;
      this._search$
        .pipe(
          tap(() => this._loading$.next(true)),
          debounceTime(200),
          switchMap(() => this._search()),
          delay(200),
          tap(() => this._loading$.next(false)),
        )
        .subscribe((result) => {
          this._suppliers$.next(result.items);
          this._total$.next(result.total);
        });

      this._search$.next();
    });
  }

  Add(supplier: SupplierDto) {
    return this.http.post(this.apiUrl, supplier);
  }

  Update(id: string, supplier: SupplierDto) {
    return this.http.put(`${this.apiUrl}${id}`, supplier);
  }

  GetManagement(id: string): Observable<SupplierResponse> {
    return this.http.get<SupplierResponse>(`${this.apiUrl}${id}`);
  }

  Get(): Observable<SupplierResponse[]> {
    return this.http.get<SupplierResponse[]>(`${this.apiUrl}`);
  }

  GetList(): Observable<SuppliersListResponse[]> {
    return this.http.get<SuppliersListResponse[]>(`${this.apiUrl}suppliersList`);
  }

  Delete(id: string) {
    return this.http.delete(`${this.apiUrl}${id}`);
  }

  DeleteProducts(id: string, productId: string) {
    return this.http.delete(`${this.apiUrl}${id}/products/${productId}`);
  }

  private _set(patch: Partial<State>) {
    Object.assign(this._state, patch);
    this._search$.next();
  }

  private _search(): Observable<SearchResult> {
    const {sortColumn, sortDirection, pageSize, page, searchTerm} = this._state;

    // 1. sort
    let items = sort(this._managementSuppliers$, sortColumn, sortDirection);

    // 2. filter
    items = items.filter((supplier) => matches(supplier, searchTerm, this.pipe));
    const total = items.length;

    // 3. paginate
    items = items.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({items, total});
  }
}

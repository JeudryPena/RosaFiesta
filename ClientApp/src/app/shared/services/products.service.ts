import { DecimalPipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable, PipeTransform } from '@angular/core';
import { BehaviorSubject, Observable, Subject, of } from 'rxjs';
import { debounceTime, delay, switchMap, tap } from 'rxjs/operators';
import { config } from "../../env/config.prod";
import { ManagementProductsResponse } from '../../interfaces/Product/Response/managementProductsResponse';
import { OptionsListResponse } from '../../interfaces/Product/Response/optionsListResponse';
import { ProductResponse } from '../../interfaces/Product/Response/productResponse';
import { ProductsListResponse } from '../../interfaces/Product/Response/productsListResponse';
import { ProductDto } from '../../interfaces/Product/productDto';
import { SortColumn, SortDirection } from '../directives/sortable.directive';
import { SearchResult } from './search-result';
import { State } from './state';
import { ProductDetailResponse } from '../../interfaces/Product/Response/productDetailResponse';

const compare = (v1: string | number, v2: string | number) => (v1 < v2 ? -1 : v1 > v2 ? 1 : 0);

function sort(products: ManagementProductsResponse[], column: SortColumn, direction: string): ManagementProductsResponse[] {
  if (direction === '' || column === '') {
    return products;
  } else {
    return [...products].sort((a: any, b: any) => {
      const res = compare(a[column], b[column]);
      return direction === 'asc' ? res : -res;
    });
  }
}

function matches(product: ManagementProductsResponse, term: string, pipe: PipeTransform) {
  return (
    product.id?.toLowerCase().includes(term.toLowerCase()) ||
    pipe.transform(product.code).includes(term)
  );
}

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private apiUrl = `${config.apiURL}products/`
  private _loading$ = new BehaviorSubject<boolean>(true);
  private _search$ = new Subject<void>();
  private _products$ = new BehaviorSubject<ManagementProductsResponse[]>([]);
  private _managementProducts$: ManagementProductsResponse[] = [];
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
    private http: HttpClient
  ) {
    this.RetrieveData();
  }

  RetrieveData() {
    this.getProducts().subscribe((data: ManagementProductsResponse[]) => {
      this._managementProducts$ = data;
      this._search$
        .pipe(
          tap(() => this._loading$.next(true)),
          debounceTime(200),
          switchMap(() => this._search()),
          delay(200),
          tap(() => this._loading$.next(false)),
        )
        .subscribe((result) => {
          this._products$.next(result.items);
          this._total$.next(result.total);
        });

      this._search$.next();
    });
  }

  GetOptions(): Observable<OptionsListResponse[]> {
    return this.http.get<OptionsListResponse[]>(`${this.apiUrl}options-list`);
  }

  getProducts(): Observable<ManagementProductsResponse[]> {
    return this.http.get<ManagementProductsResponse[]>(this.apiUrl);
  }

  GetProductsList(): Observable<ProductsListResponse[]> {
    return this.http.get<ProductsListResponse[]>(`${this.apiUrl}productsList`);
  }

  GetProduct(id: string): Observable<ProductResponse> {
    return this.http.get<ProductResponse>(`${this.apiUrl}${id}`);
  }

  GetProductDetail(productId: string): Observable<ProductDetailResponse> {
    return this.http.get<ProductDetailResponse>(`${this.apiUrl}${productId}/detail`);
  }

  AddProduct(product: ProductDto) {
    return this.http.post(this.apiUrl, product);
  }

  UpdateProduct(id: string, product: ProductDto) {
    console.log(product)
    return this.http.put(`${this.apiUrl}${id}`, product);
  }

  DeleteProduct(id: string, optionId: string | null) {
    if (optionId === null)
      optionId = '';
    return this.http.delete(`${this.apiUrl}${id}/option/${optionId}`);
  }

  get products$() {
    return this._products$.asObservable();
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

    let items = sort(this._managementProducts$, sortColumn, sortDirection);

    items = items.filter((product) => matches(product, searchTerm, this.pipe));
    const total = items.length;

    items = items.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({ items, total });
  }
}
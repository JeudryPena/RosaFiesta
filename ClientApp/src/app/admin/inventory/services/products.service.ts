import {DecimalPipe} from '@angular/common';
import {HttpClient} from '@angular/common/http';
import {Injectable, PipeTransform} from '@angular/core';
import {BehaviorSubject, Observable, of, Subject} from 'rxjs';
import {debounceTime, delay, switchMap, tap} from 'rxjs/operators';
import {config} from "@env/config.prod";
import {ManagementProductsResponse} from '@core/interfaces/Product/Response/managementProductsResponse';
import {OptionsListResponse} from '@core/interfaces/Product/Response/optionsListResponse';
import {ProductResponse} from '@core/interfaces/Product/Response/productResponse';
import {ProductsListResponse} from '@core/interfaces/Product/Response/productsListResponse';
import {ProductDto} from '@core/interfaces/Product/productDto';
import {SortColumn, SortDirection} from '@core/shared/directives/sortable.directive';
import {SearchResult} from '@core/interfaces/search-result';
import {State} from '@core/interfaces/state';
import {ProductDetailResponse} from '@core/interfaces/Product/Response/productDetailResponse';
import {ProductPreviewResponse} from '@core/interfaces/Product/Response/productPreviewResponse';
import {SearchFilter} from "@core/interfaces/searchFilter";
import {SearchProducts} from "@core/interfaces/searchProducts";

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
  private _search$ = new Subject<void>();
  private _managementProducts$: ManagementProductsResponse[] = [];
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

  private _products$ = new BehaviorSubject<ManagementProductsResponse[]>([]);

  get products$() {
    return this._products$.asObservable();
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

  retrieveFilteredProducts(filter: SearchFilter): Observable<ProductPreviewResponse[]> {
    return this.http.post<ProductPreviewResponse[]>(`${this.apiUrl}filtered`, filter);
  }

  retrieveSearchProducts(filter: SearchProducts): Observable<ProductPreviewResponse[]> {
    return this.http.post<ProductPreviewResponse[]>(`${this.apiUrl}filtered`, filter);
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

  GetProductsPreview(): Observable<ProductPreviewResponse[]> {
    return this.http.get<ProductPreviewResponse[]>(`${this.apiUrl}options`);
  }

  GetRelatedProducts(categoryId: number) {
    return this.http.get<ProductPreviewResponse[]>(`${this.apiUrl}related-products/${categoryId}`);
  }

  GetRecommendProducts(): Observable<ProductPreviewResponse[]> {
    return this.http.get<ProductPreviewResponse[]>(`${this.apiUrl}recommended-products`);
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

  GetProductDetail(productId: string, optionId: string): Observable<ProductDetailResponse> {
    return this.http.get<ProductDetailResponse>(`${this.apiUrl}${productId}/option/${optionId}/detail`);
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


  increaseView(id: string) {
    return this.http.get(`${this.apiUrl}${id}/view`);
  }

  private _set(patch: Partial<State>) {
    Object.assign(this._state, patch);
    this._search$.next();
  }

  private _search(): Observable<SearchResult> {
    const {sortColumn, sortDirection, pageSize, page, searchTerm} = this._state;

    let items = sort(this._managementProducts$, sortColumn, sortDirection);

    items = items.filter((product) => matches(product, searchTerm, this.pipe));
    const total = items.length;

    items = items.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({items, total});
  }
}

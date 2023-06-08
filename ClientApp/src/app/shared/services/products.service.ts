import { DecimalPipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable, PipeTransform } from '@angular/core';
import { BehaviorSubject, Observable, Subject, of } from 'rxjs';
import { debounceTime, delay, switchMap, tap } from 'rxjs/operators';
import { config } from "../../env/config.prod";
import { ProductPreviewResponse } from '../../interfaces/Product/Response/productPreviewResponse';
import { SortColumn, SortDirection } from '../directives/sortable.directive';
import { ProductsResponse } from '../../interfaces/Product/Response/productsResponse';

interface SearchResult {
  products: ProductsResponse[];
  total: number;
}

interface State {
  page: number;
  pageSize: number;
  searchTerm: string;
  sortColumn: SortColumn;
  sortDirection: SortDirection;
}

const compare = (v1: string | number, v2: string | number) => (v1 < v2 ? -1 : v1 > v2 ? 1 : 0);

function sort(products: ProductsResponse[], column: SortColumn, direction: string): ProductsResponse[] {
  if (direction === '' || column === '') {
    return products;
  } else {
    return [...products].sort((a: any, b: any) => {
      const res = compare(a[column], b[column]);
      return direction === 'asc' ? res : -res;
    });
  }
}

function matches(product: ProductsResponse, term: string, pipe: PipeTransform) {
  return (
    product.title.toLowerCase().includes(term.toLowerCase()) ||
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
  private _products$ = new BehaviorSubject<ProductsResponse[]>([]);
  private _managementProducts$: ProductsResponse[] = [];
  private _total$ = new BehaviorSubject<number>(0);

  private _state: State = {
    page: 1,
    pageSize: 4,
    searchTerm: '',
    sortColumn: '',
    sortDirection: '',
  };

  constructor(
    private pipe: DecimalPipe,
    private http: HttpClient
  ) {
    this.getProducts();
    this._search$
      .pipe( 
        tap(() => this._loading$.next(true)),
        debounceTime(200),
        switchMap(() => this._search()),
        delay(200),
        tap(() => this._loading$.next(false)),
      )
      .subscribe((result) => {
        this._products$.next(result.products);
        this._total$.next(result.total);
      });

    this._search$.next();
  }

  getProducts() {
    return this.http.get<ProductsResponse[]>(this.apiUrl).subscribe((data) => {
      this._managementProducts$ = data;
    });
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

    let products = sort(this._managementProducts$, sortColumn, sortDirection);

    products = products.filter((product) => matches(product, searchTerm, this.pipe));
    const total = products.length;

    products = products.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({ products, total });
  }
}
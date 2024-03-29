import {DecimalPipe} from '@angular/common';
import {HttpClient} from '@angular/common/http';
import {Injectable, PipeTransform} from '@angular/core';
import {BehaviorSubject, debounceTime, delay, Observable, of, Subject, switchMap, tap} from 'rxjs';
import {config} from "@env/config.dev";
import {
  CategoriesListResponse,
  Category,
  CategoryDto,
  CategoryPreviewResponse,
  CategoryResponse
} from '@core/interfaces/Product/category';
import {SortColumn, SortDirection} from '@core/shared/directives/sortable.directive';
import {SearchResult} from '@core/interfaces/search-result';
import {State} from '@core/interfaces/state';

const compare = (v1: string | number, v2: string | number) => (v1 < v2 ? -1 : v1 > v2 ? 1 : 0);

function sort(categories: Category[], column: SortColumn, direction: string): Category[] {
  if (direction === '' || column === '') {
    return categories;
  } else {
    return [...categories].sort((a: any, b: any) => {
      const res = compare(a[column], b[column]);
      return direction === 'asc' ? res : -res;
    });
  }
}

function matches(category: Category, term: string, pipe: PipeTransform) {
  return (
    category.name.toLowerCase().includes(term.toLowerCase()) ||
    category.description.toLowerCase().includes(term.toLowerCase())
  );
}

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  public _categoriesData: Array<Category> = [];
  public categoriesPreview: CategoryPreviewResponse[] = [];
  private apiUrl = `${config.apiURL}categories/`
  private _search$ = new Subject<void>();
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

  private _categories$ = new BehaviorSubject<Category[]>([]);

  get categories$() {
    return this._categories$.asObservable();
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
    this.GetCategoriesManagement().subscribe((data) => {
      this._categoriesData = data;
      this._search$
        .pipe(
          tap(() => this._loading$.next(true)),
          debounceTime(200),
          switchMap(() => this._search()),
          delay(200),
          tap(() => this._loading$.next(false)),
        )
        .subscribe((result) => {
          this._categories$.next(result.items);
          this._total$.next(result.total);
        });

      this._search$.next();
    });
  }

  getCategoryNameByProductId(productId: string): Observable<string> {
    return this.http.get<string>(`${this.apiUrl}product/${productId}/name`);
  }

  AddCategory(category: CategoryDto) {
    return this.http.post(this.apiUrl, category);
  }

  GetCategoriesList(): Observable<CategoriesListResponse[]> {
    return this.http.get<CategoriesListResponse[]>(this.apiUrl + 'categoriesList');
  }

  GetCategoriesManagement(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl + 'categoriesManagement');
  }

  GetCategories(): Observable<CategoryPreviewResponse[]> {
    return this.http.get<CategoryPreviewResponse[]>(this.apiUrl + 'categoriesPreview')
  }

  GetCategoryManagement(categoryId: number): Observable<Category> {
    return this.http.get<Category>(`${this.apiUrl}${categoryId}/category-management`);
  }

  GetCategory(categoryId: number): Observable<CategoryResponse> {
    return this.http.get<CategoryResponse>(`${this.apiUrl}${categoryId}`);
  }

  UpdateCategory(categoryId: number, category: CategoryDto) {
    return this.http.put(`${this.apiUrl}${categoryId}`, category);
  }

  DeleteCategory(categoryId: number) {
    return this.http.get(`${this.apiUrl}${categoryId}/delete`);
  }

  private _set(patch: Partial<State>) {
    Object.assign(this._state, patch);
    this._search$.next();
  }

  private _search(): Observable<SearchResult> {
    const {sortColumn, sortDirection, pageSize, page, searchTerm} = this._state;
    let items = sort(this._categoriesData, sortColumn, sortDirection);

    items = items.filter((category) => matches(category, searchTerm, this.pipe));
    const total = items.length;

    items = items.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({items, total});
  }
}

import { DecimalPipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable, PipeTransform } from '@angular/core';
import { BehaviorSubject, Observable, Subject, debounceTime, delay, of, switchMap, tap } from 'rxjs';
import { config } from "../../env/config.dev";
import { CategoriesListResponse } from '../../interfaces/Product/Response/categoriesListResponse';
import { CategoryManagementResponse } from '../../interfaces/Product/Response/categoryManagementResponse';
import { CategoryPreviewResponse } from '../../interfaces/Product/Response/categoryPreviewResponse';
import { CategoryDto } from '../../interfaces/Product/categoryDto';
import { SortColumn, SortDirection } from '../directives/sortable.directive';
import { SearchResult } from './search-result';
import { State } from './state';
import { UsersService } from './users.service';

const compare = (v1: string | number, v2: string | number) => (v1 < v2 ? -1 : v1 > v2 ? 1 : 0);

function sort(categories: CategoryManagementResponse[], column: SortColumn, direction: string): CategoryManagementResponse[] {
  if (direction === '' || column === '') {
    return categories;
  } else {
    return [...categories].sort((a: any, b: any) => {
      const res = compare(a[column], b[column]);
      return direction === 'asc' ? res : -res;
    });
  }
}

function matches(category: CategoryManagementResponse, term: string, pipe: PipeTransform) {
  return (
    category.name.toLowerCase().includes(term.toLowerCase()) ||
    pipe.transform(category.id).includes(term)
  );
}

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  private apiUrl = `${config.apiURL}categories/`
  private _loading$ = new BehaviorSubject<boolean>(true);
  private _search$ = new Subject<void>();
  private _categories$ = new BehaviorSubject<CategoryManagementResponse[]>([]);
  private _total$ = new BehaviorSubject<number>(0);
  public categoriesData: CategoryManagementResponse[] = [];

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
    this.GetCategoriesManagement().subscribe((data) => {
      this.categoriesData = data;
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

  AddCategory(category: CategoryDto) {
    return this.http.post(this.apiUrl, category);
  }

  GetCategoriesList(): Observable<CategoriesListResponse[]> {
    return this.http.get<CategoriesListResponse[]>(this.apiUrl + 'categoriesList');
  }

  GetCategoriesManagement(): Observable<CategoryManagementResponse[]> {
    return this.http.get<CategoryManagementResponse[]>(this.apiUrl + 'categoriesManagement');
  }

  GetCategories(): Observable<CategoryPreviewResponse[]> {
    return this.http.get<CategoryPreviewResponse[]>(this.apiUrl + 'categoriesPreview')
  }

  GetCategory(categoryId: number): Observable<CategoryManagementResponse> {
    return this.http.get<CategoryManagementResponse>(`${this.apiUrl}${categoryId}/category-management`);
  }

  UpdateCategory(categoryId: number, category: CategoryDto) {
    return this.http.put(`${this.apiUrl}${categoryId}`, category);
  }

  DeleteCategory(categoryId: number) {
    return this.http.get(`${this.apiUrl}${categoryId}/delete`);
  }

  get categories$() {
    return this._categories$.asObservable();
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
    let items = sort(this.categoriesData, sortColumn, sortDirection);

    items = items.filter((category) => matches(category, searchTerm, this.pipe));
    const total = items.length;

    items = items.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({ items, total });
  }
}


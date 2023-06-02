import { DecimalPipe } from '@angular/common';
import { Injectable, PipeTransform } from '@angular/core';
import { BehaviorSubject, Subject, tap, debounceTime, switchMap, delay, Observable, of } from 'rxjs';
import { Categories } from '../../dummy/categories';
import { ProductAndOptionsPreviewResponse } from '../../interfaces/product/response/productAndOptionsPreviewResponse';
import { SortColumn, SortDirection } from '../directives/sortable.directive';
import { CategoryPreviewResponse } from '../../interfaces/product/response/categoryPreviewResponse';

interface SearchResult {
  categories: CategoryPreviewResponse[];
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

function sort(categories: CategoryPreviewResponse[], column: SortColumn, direction: string): CategoryPreviewResponse[] {
  if (direction === '' || column === '') {
    return categories;
  } else {
    return [...categories].sort((a: any, b: any) => {
      const res = compare(a[column], b[column]);
      return direction === 'asc' ? res : -res;
    });
  }
}

function matches(category: CategoryPreviewResponse, term: string, pipe: PipeTransform) {
  return (
    category.title.toLowerCase().includes(term.toLowerCase()) ||
    pipe.transform(category.id).includes(term)
  );
}

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  private _loading$ = new BehaviorSubject<boolean>(true);
  private _search$ = new Subject<void>();
  private _categories$ = new BehaviorSubject<CategoryPreviewResponse[]>([]);
  private _total$ = new BehaviorSubject<number>(0);

  private _state: State = {
    page: 1,
    pageSize: 4,
    searchTerm: '',
    sortColumn: '',
    sortDirection: '',
  };

  constructor(private pipe: DecimalPipe) {
    this._search$
      .pipe(
        tap(() => this._loading$.next(true)),
        debounceTime(200),
        switchMap(() => this._search()),
        delay(200),
        tap(() => this._loading$.next(false)),
      )
      .subscribe((result) => {
        this._categories$.next(result.categories);
        this._total$.next(result.total);
      });

    this._search$.next();
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

    // 1. sort
    let categories = sort(Categories, sortColumn, sortDirection);

    // 2. filter
    categories = categories.filter((category) => matches(category, searchTerm, this.pipe));
    const total = categories.length;

    // 3. paginate
    categories = categories.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({ categories, total });
  }
}


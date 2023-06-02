import { DecimalPipe } from '@angular/common';
import { Injectable, PipeTransform } from '@angular/core';
import { BehaviorSubject, Subject, tap, debounceTime, switchMap, delay, Observable, of } from 'rxjs';
import { Discounts } from '../../dummy/discounts';
import { SortColumn, SortDirection } from '../directives/sortable.directive';
import { DiscountResponse } from '../../interfaces/product/response/discountResponse';

interface SearchResult {
  discounts: DiscountResponse[];
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

function sort(discounts: DiscountResponse[], column: SortColumn, direction: string): DiscountResponse[] {
  if (direction === '' || column === '') {
    return discounts;
  } else {
    return [...discounts].sort((a: any, b: any) => {
      const res = compare(a[column], b[column]);
      return direction === 'asc' ? res : -res;
    });
  }
}

function matches(discount: DiscountResponse, term: string, pipe: PipeTransform) {
  return (
    discount.name.toLowerCase().includes(term.toLowerCase()) ||
    pipe.transform(discount.code).includes(term) 
  );
}

@Injectable({
  providedIn: 'root'
})
export class DiscountsService {
  private _loading$ = new BehaviorSubject<boolean>(true);
  private _search$ = new Subject<void>();
  private _discounts$ = new BehaviorSubject<DiscountResponse[]>([]);
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
        this._discounts$.next(result.discounts);
        this._total$.next(result.total);
      });

    this._search$.next();
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
    let discounts = sort(Discounts, sortColumn, sortDirection);

    // 2. filter
    discounts = discounts.filter((discount) => matches(discount, searchTerm, this.pipe));
    const total = discounts.length;

    // 3. paginate
    discounts = discounts.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({ discounts, total });
  }
}


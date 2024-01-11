import {AfterViewInit, Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {ProductPreviewResponse} from "@core/interfaces/Product/Response/productPreviewResponse";
import {CategoryPreviewResponse} from "@core/interfaces/Product/category";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator, PageEvent} from "@angular/material/paginator";
import {WisheslistService} from "@intranet/services/wisheslist.service";
import {Router} from "@angular/router";
import {Observable} from "rxjs";

@Component({
  selector: 'app-products-blocks',
  templateUrl: './products-blocks.component.html',
  styleUrl: './products-blocks.component.sass'
})
export class ProductsBlocksComponent implements AfterViewInit, OnInit {

  length = 50;
  pageSize = 8;
  pageIndex = 0;
  pageEvent: PageEvent;

  @Input() selectedCondition: string;
  @Input() selectedRating: number;
  @Input() startValue = 0;
  @Input() endValue = 0;

  @Input() products: ProductPreviewResponse[];
  @Input() selectedCategory: CategoryPreviewResponse;

  paginator: MatPaginator;
  productsData: MatTableDataSource<ProductPreviewResponse> =
    new MatTableDataSource<ProductPreviewResponse>();

  paginatedProducts$: Observable<any>;

  @Output() removeCondition: EventEmitter<any> = new EventEmitter<any>();
  @Output() removeRating: EventEmitter<any> = new EventEmitter<any>();
  @Output() removeStartValue: EventEmitter<any> = new EventEmitter<any>();
  @Output() removeEndValue: EventEmitter<any> = new EventEmitter<any>();

  constructor(
    private readonly wishlistService: WisheslistService,
    private readonly router: Router
  ) {
  }

  handlePageEvent(e: PageEvent) {
    this.pageEvent = e;
    this.length = e.length;
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
  }

  ngOnInit(): void {
    this.productsData.data = this.products;
    this.paginatedProducts$ = this.productsData.connect();
  }

  initializePaginator($event: MatPaginator) {
    this.paginator = $event;
    this.productsData.paginator = this.paginator;
  }

  ngAfterViewInit(): void {

  }
}

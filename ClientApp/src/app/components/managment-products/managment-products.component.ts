import { Component, OnInit, QueryList, ViewChildren } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { AsyncPipe, DecimalPipe, NgFor, NgIf } from '@angular/common';
import { ProductAndOptionsPreviewResponse } from '../../interfaces/product/response/productAndOptionsPreviewResponse';
import { ProductsService } from '../../shared/services/products.service';
import { NgbdSortableHeader, SortEvent } from '../../shared/directives/sortable.directive';
import { FormsModule } from '@angular/forms';
import { NgbPaginationModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-managment-products',
  templateUrl: './managment-products.component.html',
  styleUrls: ['./managment-products.component.scss'],
  providers: [ProductsService, DecimalPipe],
})
export class ManagmentProductsComponent implements OnInit {

  products$: Observable<ProductAndOptionsPreviewResponse[]>;
  total$: Observable<number>;

  @ViewChildren(NgbdSortableHeader) headers!: QueryList<NgbdSortableHeader>;

  constructor(public service: ProductsService) {
    this.products$ = service.countries$;
    this.total$ = service.total$;
  }

  onSort({ column, direction }: SortEvent) {
    // resetting other headers
    this.headers.forEach((header) => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    this.service.sortColumn = column;
    this.service.sortDirection = direction;
  }

  ngOnInit(): void {
    
  }

  collectionSize = 0;
  pageSize = 5;
  page = 1;
  maxSize = 10;

  onScroll(event: any) {
    console.log('User scrolled table!', event.target)
    // Update your data or pagination here  
  }
}

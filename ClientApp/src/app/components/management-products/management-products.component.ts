import { DecimalPipe } from '@angular/common';
import { Component, QueryList, ViewChildren } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { ProductPreviewResponse } from '../../interfaces/Product/Response/productPreviewResponse';
import { NgbdSortableHeader, SortEvent } from '../../shared/directives/sortable.directive';
import { ProductsService } from '../../shared/services/products.service';
import { ModalProductComponent } from '../modal-product/modal-product.component';
import { ProductsResponse } from '../../interfaces/Product/Response/productsResponse';

@Component({
  selector: 'app-management-products',
  templateUrl: './management-products.component.html',
  styleUrls: ['./management-products.component.scss'],
  providers: [ProductsService, DecimalPipe],
})
export class ManagementProductsComponent {

  products$: Observable<ProductsResponse[]>;
  total$: Observable<number>;

  @ViewChildren(NgbdSortableHeader) headers!: QueryList<NgbdSortableHeader>;

  constructor(
    public service: ProductsService,
    public modalService: NgbModal,
    config: NgbModalConfig
  ) {
    this.products$ = service.products$;
    this.total$ = service.total$;
    // config.backdrop = 'static';
    // config.keyboard = false;
  }

  

  AddProduct() {
    const modalRef = this.modalService.open(ModalProductComponent, { size: 'lg', scrollable: true });
    modalRef.componentInstance.name = 'World';
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

  collectionSize = 0;
  pageSize = 5;
  page = 1;
  maxSize = 10;
}

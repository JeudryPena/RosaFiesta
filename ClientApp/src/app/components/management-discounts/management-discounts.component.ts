import { Component, QueryList, ViewChildren } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { ProductAndOptionsPreviewResponse } from '../../interfaces/product/response/productAndOptionsPreviewResponse';
import { NgbdSortableHeader, SortEvent } from '../../shared/directives/sortable.directive';
import { ProductsService } from '../../shared/services/products.service';
import { ModalProductComponent } from '../modal-product/modal-product.component';
import { DiscountResponse } from '../../interfaces/product/response/discountResponse';
import { DiscountsService } from '../../shared/services/discounts.service';
import { ModalDiscountComponent } from '../modal-discount/modal-discount.component';

@Component({
  selector: 'app-management-discounts',
  templateUrl: './management-discounts.component.html',
  styleUrls: ['./management-discounts.component.scss']
})
export class ManagementDiscountsComponent {
  discounts$: Observable<DiscountResponse[]>;
  total$: Observable<number>;

  @ViewChildren(NgbdSortableHeader) headers!: QueryList<NgbdSortableHeader>;

  constructor(
    public service: DiscountsService,
    public modalService: NgbModal,
    config: NgbModalConfig
  ) {
    this.discounts$ = service.discounts$;
    this.total$ = service.total$;
    // config.backdrop = 'static';
    // config.keyboard = false;
  }

  AddDiscount() {
    const modalRef = this.modalService.open(ModalDiscountComponent, { size: 'lg', scrollable: true });
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

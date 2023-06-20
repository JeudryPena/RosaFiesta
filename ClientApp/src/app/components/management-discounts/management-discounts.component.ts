import { Component, QueryList, ViewChildren } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { ManagementDiscountsResponse } from '../../interfaces/Product/Response/managementDiscountsResponse';
import { NgbdSortableHeader, SortEvent } from '../../shared/directives/sortable.directive';
import { DiscountsService } from '../../shared/services/discounts.service';
import { ModalDiscountComponent } from '../modal-discount/modal-discount.component';

@Component({
  selector: 'app-management-discounts',
  templateUrl: './management-discounts.component.html',
  styleUrls: ['./management-discounts.component.scss']
})
export class ManagementDiscountsComponent {
  discounts$: Observable<ManagementDiscountsResponse[]> = new Observable<ManagementDiscountsResponse[]>();
  total$: Observable<number> = new Observable<number>();
  collectionSize = 0;
  pageSize = 5;
  page = 1;
  maxSize = 10;

  @ViewChildren(NgbdSortableHeader) headers!: QueryList<NgbdSortableHeader>;

  constructor(
    public service: DiscountsService,
    public modalService: NgbModal,
    config: NgbModalConfig
  ) {
    this.retrieveData();
    // config.backdrop = 'static';
    // config.keyboard = false;
  }

  retrieveData() {
    this.service.RetrieveData();
    this.discounts$ = this.service.discounts$;
    this.total$ = this.service.total$;
  }

  Retrieve(code: string) {

  }

  Modify(code: string) {

  }

  Delete(code: string) {

  }

  DeleteProduct(code: string) {

  }

  AddDiscount() {
    const modalRef = this.modalService.open(ModalDiscountComponent, { size: 'xl', scrollable: true });
    modalRef.componentInstance.title = 'Añadir Descuento';
    modalRef.result.then((result) => {
      if (result)
        this.retrieveData();
    });
  }

  onSort({ column, direction }: SortEvent) {
    this.headers.forEach((header) => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    this.service.sortColumn = column;
    this.service.sortDirection = direction;
  }
}

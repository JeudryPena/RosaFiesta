import { Component, QueryList, ViewChildren } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { SaveModalComponent } from '../../helpers/save-modal/save-modal.component';
import { Status } from '../../helpers/save-modal/status';
import { ManagementDiscountsResponse } from '../../interfaces/Product/Response/managementDiscountsResponse';
import { NgbdSortableHeader, SortEvent } from '../../shared/directives/sortable.directive';
import { DiscountsService } from '../../shared/services/discounts.service';
import { ModalDiscountComponent } from '../modal-discount/modal-discount.component';

@Component({
  selector: 'app-management-services',
  templateUrl: './management-services.component.html',
  styleUrls: ['./management-services.component.scss']
})
export class ManagementServicesComponent {
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
    const modalRef = this.modalService.open(ModalDiscountComponent, { size: 'lg', scrollable: true });
    modalRef.componentInstance.title = 'Consultar Descuento';
    modalRef.componentInstance.code = code;
    modalRef.componentInstance.read = true;
  }

  Modify(code: string) {
    const modalRef = this.modalService.open(ModalDiscountComponent, { size: 'lg', scrollable: true });
    modalRef.componentInstance.title = 'Modificar Descuento';
    modalRef.componentInstance.update = true;
    modalRef.componentInstance.code = code;
    modalRef.result.then((result) => {
      if (result)
        this.retrieveData();
    });
  }

  Delete(code: string) {
    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea eliminar el descuento?';
    modalRef.componentInstance.status = Status.Pending;
    modalRef.result.then((result) => {
      if (result) {
        this.service.DeleteDiscount(code).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Descuento eliminado!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(() => {
              this.retrieveData()
            });
          }, error: (error) => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = error;
            modalRef.componentInstance.status = Status.Failed;
          }
        });
      }
    });
  }

  DeleteProducts(code: string, optionId: number | null) {
    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea eliminar el descuento del producto?';
    modalRef.componentInstance.status = Status.Pending;
    modalRef.result.then((result) => {
      if (result) {
        this.service.DeleteDiscountProducts(code, optionId).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Descuento de producto eliminado!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(() => {
              this.retrieveData()
            });
          }, error: (error) => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = error;
            modalRef.componentInstance.status = Status.Failed;
          }
        });
      }
    });
  }

  AddDiscount() {
    const modalRef = this.modalService.open(ModalDiscountComponent, { size: 'lg', scrollable: true });
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


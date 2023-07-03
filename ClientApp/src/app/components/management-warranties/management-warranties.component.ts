import { Component, QueryList, ViewChildren } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { SaveModalComponent } from '../../helpers/save-modal/save-modal.component';
import { Status } from '../../helpers/save-modal/status';
import { WarrantyResponse } from '../../interfaces/Product/Response/warrantyResponse';
import { NgbdSortableHeader, SortEvent } from '../../shared/directives/sortable.directive';
import { WarrantiesService } from '../../shared/services/warranties.service';
import { ModalDiscountComponent } from '../modal-discount/modal-discount.component';

@Component({
  selector: 'app-management-warranties',
  templateUrl: './management-warranties.component.html',
  styleUrls: ['./management-warranties.component.scss']
})
export class ManagementWarrantiesComponent {
  warranties$: Observable<WarrantyResponse[]> = new Observable<WarrantyResponse[]>();
  total$: Observable<number> = new Observable<number>();
  collectionSize = 0;
  pageSize = 5;
  page = 1;
  maxSize = 10;

  @ViewChildren(NgbdSortableHeader) headers!: QueryList<NgbdSortableHeader>;

  constructor(
    public service:   WarrantiesService,
    public modalService: NgbModal,
    config: NgbModalConfig
  ) {
    this.retrieveData();
    // config.backdrop = 'static';
    // config.keyboard = false;
  }

  retrieveData() {
    this.service.RetrieveData();
    this.warranties$ = this.service.warranties$; 
    this.total$ = this.service.total$;
  }

  Retrieve(id: string) {
    const modalRef = this.modalService.open(ModalDiscountComponent, { size: 'lg', scrollable: true });
    modalRef.componentInstance.title = 'Consultar Garantia';
    modalRef.componentInstance.id = id;
    modalRef.componentInstance.read = true;
  }

  Modify(id: string) {
    const modalRef = this.modalService.open(ModalDiscountComponent, { size: 'lg', scrollable: true });
    modalRef.componentInstance.title = 'Modificar Garantia';
    modalRef.componentInstance.update = true;
    modalRef.componentInstance.id = id;
    modalRef.result.then((result) => {
      if (result)
        this.retrieveData();
    });
  }

  Delete(id: string) {
    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea eliminar la garantia?';
    modalRef.componentInstance.status = Status.Pending;
    modalRef.result.then((result) => {
      if (result) {
        this.service.DeleteWarranty(id).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Garantia eliminada!';
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

  DeleteProducts(id: string, productId: string) {
    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea eliminar la garantia del producto?';
    modalRef.componentInstance.status = Status.Pending;
    modalRef.result.then((result) => {
      if (result) {
        this.service.DeleteWarrantyProducts(id, productId).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Garantia del producto eliminado!';
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

  AddWarranty() {
    const modalRef = this.modalService.open(ModalDiscountComponent, { size: 'lg', scrollable: true });
    modalRef.componentInstance.title = 'Añadir Garantia';
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


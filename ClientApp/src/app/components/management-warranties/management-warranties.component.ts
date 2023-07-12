import { Component, QueryList, ViewChildren } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { SaveModalComponent } from '../../helpers/save-modal/save-modal.component';
import { Status } from '../../helpers/save-modal/status';
import { WarrantiesManagementResponse } from '../../interfaces/Product/Response/warrantiesManagementResponse';
import { NgbdSortableHeader, SortEvent } from '../../shared/directives/sortable.directive';
import { WarrantiesService } from '../../shared/services/warranties.service';
import { ModalWarrantyComponent } from '../modal-warranty/modal-warranty.component';

@Component({
  selector: 'app-management-warranties',
  templateUrl: './management-warranties.component.html',
  styleUrls: ['./management-warranties.component.scss']
})
export class ManagementWarrantiesComponent {
  warranties$: Observable<WarrantiesManagementResponse[]> = new Observable<WarrantiesManagementResponse[]>();
  total$: Observable<number> = new Observable<number>();
  collectionSize = 0;
  pageSize = 5;
  page = 1;
  maxSize = 10;

  @ViewChildren(NgbdSortableHeader) headers!: QueryList<NgbdSortableHeader>;

  constructor(
    public service: WarrantiesService,
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
    const modalRef = this.modalService.open(ModalWarrantyComponent, { size: 'lg', scrollable: true });
    modalRef.componentInstance.title = 'Consultar Garantía';
    modalRef.componentInstance.id = id;
    modalRef.componentInstance.read = true;
  }

  Modify(id: string) {
    const modalRef = this.modalService.open(ModalWarrantyComponent, { size: 'lg', scrollable: true });
    modalRef.componentInstance.title = 'Modificar Garantía';
    modalRef.componentInstance.update = true;
    modalRef.componentInstance.id = id;
    modalRef.result.then((result) => {
      if (result)
        this.retrieveData();
    });
  }

  Delete(id: string) {
    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea eliminar la garantía?';
    modalRef.componentInstance.status = Status.Pending;
    modalRef.result.then((result) => {
      if (result) {
        this.service.DeleteWarranty(id).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Garantía eliminada!';
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
    modalRef.componentInstance.title = '¿Desea eliminar la Garantía del producto?';
    modalRef.componentInstance.status = Status.Pending;
    modalRef.result.then((result) => {
      if (result) {
        this.service.DeleteWarrantyProducts(id, productId).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Garantía del producto eliminado!';
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
    const modalRef = this.modalService.open(ModalWarrantyComponent, { size: 'lg', scrollable: true });
    modalRef.componentInstance.title = 'Añadir Garantía';
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


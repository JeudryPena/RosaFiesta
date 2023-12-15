import {Component, QueryList, ViewChildren} from '@angular/core';
import {NgbModal, NgbModalConfig} from '@ng-bootstrap/ng-bootstrap';
import {Observable} from 'rxjs';
import {SaveModalComponent} from '@core/shared/components/save-modal/save-modal.component';
import {Status} from '@core/shared/components/save-modal/status';
import {SupplierResponse} from '../../../../core/interfaces/Product/Response/supplierResponse';
import {NgbdSortableHeader, SortEvent} from '@core/shared/directives/sortable.directive';
import {SuppliersService} from '../../services/suppliers.service';
import {ModalSuppliersComponent} from '../../components/modal-suppliers/modal-suppliers.component';

@Component({
  selector: 'app-management-suppliers',
  templateUrl: './management-suppliers.component.html',
  styleUrls: ['./management-suppliers.component.scss']
})
export class ManagementSuppliersComponent {
  suppliers$: Observable<SupplierResponse[]> = new Observable<SupplierResponse[]>();
  total$: Observable<number> = new Observable<number>();
  collectionSize = 0;
  pageSize = 5;
  page = 1;
  maxSize = 10;

  @ViewChildren(NgbdSortableHeader) headers!: QueryList<NgbdSortableHeader>;

  constructor(
    public service: SuppliersService,
    public modalService: NgbModal,
    config: NgbModalConfig
  ) {
    this.retrieveData();
    // config.backdrop = 'static';
    // config.keyboard = false;
  }

  retrieveData() {
    this.service.RetrieveData();
    this.suppliers$ = this.service.suppliers$;
    this.total$ = this.service.total$;
  }

  Retrieve(id: string) {
    const modalRef = this.modalService.open(ModalSuppliersComponent, {size: 'lg', scrollable: true});
    modalRef.componentInstance.title = 'Consultar suplidor';
    modalRef.componentInstance.id = id;
    modalRef.componentInstance.read = true;
  }

  Modify(id: string) {
    const modalRef = this.modalService.open(ModalSuppliersComponent, {size: 'lg', scrollable: true});
    modalRef.componentInstance.title = 'Modificar suplidor';
    modalRef.componentInstance.update = true;
    modalRef.componentInstance.id = id;
    modalRef.result.then((result) => {
      if (result)
        this.retrieveData();
    });
  }

  Delete(id: string) {
    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea eliminar el suplidor?';
    modalRef.componentInstance.status = Status.Pending;
    modalRef.result.then((result) => {
      if (result) {
        this.service.Delete(id).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = 'Suplidor eliminado!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(() => {
              this.retrieveData()
            });
          }, error: (error) => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = error;
            modalRef.componentInstance.status = Status.Failed;
          }
        });
      }
    });
  }

  DeleteProducts(id: string, productId: string) {
    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea eliminar el suplidor del producto?';
    modalRef.componentInstance.status = Status.Pending;
    modalRef.result.then((result) => {
      if (result) {
        this.service.DeleteProducts(id, productId).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = 'Suplidor del producto eliminado!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(() => {
              this.retrieveData()
            });
          }, error: (error) => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = error;
            modalRef.componentInstance.status = Status.Failed;
          }
        });
      }
    });
  }

  AddSupplier() {
    const modalRef = this.modalService.open(ModalSuppliersComponent, {size: 'lg', scrollable: true});
    modalRef.componentInstance.title = 'Añadir suplidor';
    modalRef.result.then((result) => {
      if (result)
        this.retrieveData();
    });
  }

  onSort({column, direction}: SortEvent) {
    this.headers.forEach((header) => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    this.service.sortColumn = column;
    this.service.sortDirection = direction;
  }
}

import {DecimalPipe} from '@angular/common';
import {Component, QueryList, ViewChildren} from '@angular/core';
import {NgbModal, NgbModalConfig} from '@ng-bootstrap/ng-bootstrap';
import {Observable} from 'rxjs';
import {SaveModalComponent} from '@core/shared/components/save-modal/save-modal.component';
import {Status} from '@core/shared/components/save-modal/status';
import {ManagementProductsResponse} from '../../../../core/interfaces/Product/Response/managementProductsResponse';
import {NgbdSortableHeader, SortEvent} from '@core/shared/directives/sortable.directive';
import {ProductsService} from '../../services/products.service';
import {ModalProductComponent} from '../../components/modal-product/modal-product.component';

@Component({
  selector: 'app-management-products',
  templateUrl: './management-products.component.html',
  styleUrls: ['./management-products.component.scss'],
  providers: [ProductsService, DecimalPipe],
})
export class ManagementProductsComponent {
  products$: Observable<ManagementProductsResponse[]> = new Observable<ManagementProductsResponse[]>();
  total$: Observable<number> = new Observable<number>();
  collectionSize = 0;
  pageSize = 5;
  page = 1;
  maxSize = 10;

  @ViewChildren(NgbdSortableHeader) headers!: QueryList<NgbdSortableHeader>;

  constructor(
    public service: ProductsService,
    public modalService: NgbModal,
    config: NgbModalConfig
  ) {
    this.retrieveData();

    // config.backdrop = 'static';
    // config.keyboard = false;
  }

  retrieveData() {
    this.service.RetrieveData();
    this.products$ = this.service.products$;
    this.total$ = this.service.total$;
  }

  Retrieve(id: string) {
    const modalRef = this.modalService.open(ModalProductComponent, {size: 'xl', scrollable: true});
    modalRef.componentInstance.title = 'Consultar Producto';
    modalRef.componentInstance.productId = id;
    modalRef.componentInstance.read = true;
  }

  Modify(id: string) {
    const modalRef = this.modalService.open(ModalProductComponent, {size: 'xl', scrollable: true});
    modalRef.componentInstance.title = 'Modificar Producto';
    modalRef.componentInstance.update = true;
    modalRef.componentInstance.productId = id;
    modalRef.result.then((result) => {
      if (result)
        this.retrieveData();
    });
  }

  public createImgPath = (serverPath: string) => {
    return `https://localhost:5001/${serverPath}`;
  }

  Delete(id: string, optionId: string | null) {
    console.log(id)
    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea eliminar el producto?';
    modalRef.componentInstance.status = Status.Pending;
    modalRef.result.then((result) => {
      if (result) {
        this.service.DeleteProduct(id, optionId).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = 'Producto eliminado!';
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

  AddProduct() {
    const modalRef = this.modalService.open(ModalProductComponent, {size: 'xl', scrollable: true});
    modalRef.componentInstance.title = 'Añadir Producto';
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

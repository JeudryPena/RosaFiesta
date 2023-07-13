import { DecimalPipe } from '@angular/common';
import { Component, QueryList, ViewChildren } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { SaveModalComponent } from '../../helpers/save-modal/save-modal.component';
import { Status } from '../../helpers/save-modal/status';
import { CategoryManagementResponse } from '../../interfaces/Product/Response/categoryManagementResponse';
import { NgbdSortableHeader, SortEvent } from '../../shared/directives/sortable.directive';
import { CategoriesService } from '../../shared/services/categories.service';
import { ProductsService } from '../../shared/services/products.service';
import { ModalCategoryComponent } from '../modal-category/modal-category.component';

@Component({
  selector: 'app-management-categories',
  templateUrl: './management-categories.component.html',
  styleUrls: ['./management-categories.component.scss'],
  providers: [ProductsService, DecimalPipe],
})
export class ManagementCategoriesComponent {
  categories$: Observable<CategoryManagementResponse[]> = new Observable<CategoryManagementResponse[]>();
  total$: Observable<number> = new Observable<number>();

  collectionSize = 0;
  pageSize = 5;
  page = 1;
  maxSize = 10;

  @ViewChildren(NgbdSortableHeader) headers!: QueryList<NgbdSortableHeader>;

  constructor(
    public service: CategoriesService,
    private modalService: NgbModal,
    config: NgbModalConfig
  ) {
    this.retrieveData();
    // config.backdrop = 'static';
    // config.keyboard = false;
  }

  retrieveData() {
    this.service.RetrieveData();
    this.categories$ = this.service.categories$;
    this.total$ = this.service.total$;
  }

  Retrieve(id: number) {
    const modalRef = this.modalService.open(ModalCategoryComponent, { size: 'lg', scrollable: true });
    modalRef.componentInstance.title = 'Consultar Categoría';
    modalRef.componentInstance.categoryId = id;
    modalRef.componentInstance.read = true;
  }

  Modify(id: number) {
    const modalRef = this.modalService.open(ModalCategoryComponent, { size: 'lg', scrollable: true });
    modalRef.componentInstance.title = 'Modificar Categoría';
    modalRef.componentInstance.update = true;
    modalRef.componentInstance.categoryId = id;
    modalRef.result.then((result) => {
      if (result)
        this.retrieveData();
    });
  }

  Delete(id: number) {
    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea eliminar la categoría?';
    modalRef.componentInstance.status = Status.Pending;
    modalRef.result.then((result) => {
      if (result) {
        this.service.DeleteCategory(id).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Categoría eliminada!';
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

  AddCategory() {
    const modalRef = this.modalService.open(ModalCategoryComponent, { size: 'lg', scrollable: true });
    modalRef.componentInstance.title = 'Añadir Categoría';
    modalRef.result.then(result => {
      if (result)
        this.retrieveData();
    });
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
}

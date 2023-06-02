import { DecimalPipe } from '@angular/common';
import { Component, QueryList, ViewChildren } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { CategoryPreviewResponse } from '../../interfaces/product/response/categoryPreviewResponse';
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
  categories$: Observable<CategoryPreviewResponse[]>;
  total$: Observable<number>;

  @ViewChildren(NgbdSortableHeader) headers!: QueryList<NgbdSortableHeader>;

  constructor(
    public service: CategoriesService,
    public modalService: NgbModal,
    config: NgbModalConfig
  ) {
    this.categories$ = service.categories$;
    this.total$ = service.total$;
    // config.backdrop = 'static';
    // config.keyboard = false;
  }



  AddCategory() {
    const modalRef = this.modalService.open(ModalCategoryComponent, { size: 'lg', scrollable: true });
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

  onScroll(event: any) {
    console.log('User scrolled table!', event.target)
    // Update your data or pagination here  
  }
}
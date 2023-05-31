import { Component, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { AsyncPipe, DecimalPipe, NgFor, NgIf } from '@angular/common';
import { ProductAndOptionsPreviewResponse } from '../../interfaces/product/response/productAndOptionsPreviewResponse';
import { ProductsService } from '../../shared/services/products.service';
import { NgbdSortableHeader, SortEvent } from '../../shared/directives/sortable.directive';
import { FormsModule } from '@angular/forms';
import { NgbPaginationModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalProductComponent } from '../modal-product/modal-product.component';

declare var window: any;

@Component({
  selector: 'app-managment-products',
  templateUrl: './managment-products.component.html',
  styleUrls: ['./managment-products.component.scss'],
  providers: [ProductsService, DecimalPipe],
})
export class ManagmentProductsComponent implements OnInit {
  @ViewChild('myModal') myModal: any;
  formModal: any;

  AddProduct() {
    this.formModal.show();
    this.modalService.open(this.myModal).result.then((result) => {
      // Modal cerrado
    }, (reason) => {
      // Modal cerrado con rechazo
    });

    // Enfocar el elemento después de que se haya abierto completamente el modal
    this.myModal.result.then(() => {
      const myInput = document.getElementById('myInput') as HTMLInputElement;
      myInput.focus();
    });
  }

  close() {
    this.formModal.hide();
  }

  ngOnInit(): void {
    this.formModal = new window.bootstrap.Modal(
      document.getElementById('exampleModal'),
    )
  }

  products$: Observable<ProductAndOptionsPreviewResponse[]>;
  total$: Observable<number>;

  @ViewChildren(NgbdSortableHeader) headers!: QueryList<NgbdSortableHeader>;

  constructor(
    public service: ProductsService,
    public modalService: NgbModal
  ) {
    this.products$ = service.countries$;
    this.total$ = service.total$;
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

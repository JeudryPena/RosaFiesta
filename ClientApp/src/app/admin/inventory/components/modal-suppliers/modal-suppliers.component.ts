import {Component, ElementRef, Input, OnInit} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {NgbActiveModal, NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {TypeaheadMatch} from 'ngx-bootstrap/typeahead';
import {SaveModalComponent} from '@core/shared/components/save-modal/save-modal.component';
import {Status} from '@core/shared/components/save-modal/status';
import {ProductsListResponse} from '../../../../core/interfaces/Product/Response/productsListResponse';
import {SupplierDto} from '../../../../core/interfaces/Product/supplierDto';
import {ProductsService} from '../../services/products.service';
import {SuppliersService} from '../../services/suppliers.service';
import {BehaviorSubject, lastValueFrom} from "rxjs";
import {DatePipe} from "@angular/common";

@Component({
  selector: 'app-modal-suppliers',
  templateUrl: './modal-suppliers.component.html',
  styleUrls: ['./modal-suppliers.component.scss']
})
export class ModalSuppliersComponent implements OnInit {
  @Input() read: boolean = false;
  @Input() update: boolean = false;
  @Input() title: string = '';
  @Input() id: string = '';

  supplierForm$: BehaviorSubject<FormGroup<any>> = new BehaviorSubject<FormGroup<any>>(null);
  products: any[] = [];
  selected?: string;
  productsList: ProductsListResponse[] = [];

  constructor(
    public activeModal: NgbActiveModal,
    private modalService: NgbModal,
    private service: SuppliersService,
    public el: ElementRef,
    private productService: ProductsService,
    private fb: FormBuilder,
    private datePipe: DatePipe
  ) {
  }

  onSelect(event: TypeaheadMatch): void {
    this.products.push({
      id: event.item.id,
      option: {
        title: event.item.option.title
      }
    });
    this.selected = '';
  }

  ngOnInit(): void {
    this.productService.GetProductsList().subscribe({
      next: (response: ProductsListResponse[]) => {
        this.productsList = response;
      }, error: (error) => {
        console.log(error);
      }
    });
    if (!this.update && !this.read) {
      this.onCreate();
    }
    if (this.update) {
      this.onEdit();
    } else if (this.read) {
      this.onRead();
    }
  }

  onCreate() {
    this.supplierForm$.next(this.fb.group({
      name: [],
      email: [],
      phone: [],
      description: [],
      address: [],
      products: []
    }));
  }

  async onEdit() {
    const supplier$ = this.service.GetManagement(this.id);
    let response = await lastValueFrom(supplier$);
    this.products = response.products || [];
    this.supplierForm$.next(this.fb.group({
      name: response.name,
      email: response.email,
      phone: response.phone,
      description: response.description,
      address: response.address
    }));
  }

  async onRead() {
    const supplier$ = this.service.GetManagement(this.id);
    let response = await lastValueFrom(supplier$);
    this.products = response.products || [];
    const form = this.fb.group({
      name: response.name,
      email: response.email,
      phone: response.phone,
      description: response.description,
      address: response.address,
      createdAt: this.datePipe.transform(response.createdAt, 'dd-MMM-yyyy h:mm:ss a'),
      updatedAt: this.datePipe.transform(response.updatedAt, 'dd-MMM-yyyy h:mm:ss a'),
      createdBy: response.createdBy,
      updatedBy: response.updatedBy
    });
    form.disable();
    this.supplierForm$.next(form);
  }

  validate = (controlName: string, errorName: string) => {
    const form = this.supplierForm$.getValue();
    const control = form.get(controlName);
    return control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  close() {
    this.activeModal.close();
  }

  removeProduct(index: number) {
    this.products.splice(index, 1);
  }

  updateSupplier = (supplierFormValue: any) => {
    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea actualizar el suplidor?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const supplier = {...supplierFormValue};
        const supplierDto: SupplierDto = {
          name: supplier.name,
          email: supplier.email,
          phone: supplier.phone,
          description: supplier.description,
          address: supplier.address,
          supplierProducts: this.products,
        }
        this.service.Update(this.id, supplierDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = 'Suplidor actualizado!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(() => {
              this.activeModal.close(true);
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

  AddSupplier = (supplierFormValue: any) => {

    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea guardar el suplidor?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const supplier = {...supplierFormValue};

        const supplierDto: SupplierDto = {
          name: supplier.name,
          email: supplier.email,
          phone: supplier.phone,
          description: supplier.description,
          address: supplier.address,
          supplierProducts: this.products,
        }

        this.service.Add(supplierDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = 'Suplidor guardado!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(result => {
              this.activeModal.close(true);
            });
          }, error: (error) => {
            console.log(error);
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = error;
            modalRef.componentInstance.status = Status.Failed;
          }
        });
      }
    });
  }
}

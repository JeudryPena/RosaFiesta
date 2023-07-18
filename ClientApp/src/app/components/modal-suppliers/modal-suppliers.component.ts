import { Component, ElementRef, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { SaveModalComponent } from '../../helpers/save-modal/save-modal.component';
import { Status } from '../../helpers/save-modal/status';
import { ProductsListResponse } from '../../interfaces/Product/Response/productsListResponse';
import { SupplierResponse } from '../../interfaces/Product/Response/supplierResponse';
import { SupplierDto } from '../../interfaces/Product/supplierDto';
import { ProductsService } from '../../shared/services/products.service';
import { SuppliersService } from '../../shared/services/suppliers.service';

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

  supplierForm: any;
  products: any[] = [];
  selected?: string;
  updateProduct = false;
  productTitle = '';
  productsList: ProductsListResponse[] = [];

  nameFocused = false;
  emailFocused = false;
  phoneFocused = false;
  descriptionFocused = false;
  addressFocused = false;
  productsFocused = false;

  constructor(
    public activeModal: NgbActiveModal,
    private modalService: NgbModal,
    private service: SuppliersService,
    public el: ElementRef,
    private productService: ProductsService
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
    this.supplierForm = new FormGroup({
      name: new FormControl(''),
      email: new FormControl(''),
      phone: new FormControl(''),
      description: new FormControl(''),
      address: new FormControl(''),
      products: new FormControl(''),
    });
    if (this.update) {
      this.service.GetManagement(this.id).subscribe((response: SupplierResponse) => {
        this.supplierForm.patchValue({
          name: response.name,
          email: response.email,
          phone: response.phone,
          description: response.description,
          address: response.address
        });

        this.products = response.products || [];
      });
    } else if (this.read) {
      console.log(this.id);
      this.supplierForm = new FormGroup({
        name: new FormControl(''),
        email: new FormControl(''),
        phone: new FormControl(''),
        description: new FormControl(''),
        address: new FormControl(''),
        products: new FormControl(''),
        createdAt: new FormControl(''),
        createdBy: new FormControl(''),
        updatedAt: new FormControl(''),
        updatedBy: new FormControl('')
      })

      this.service.GetManagement(this.id).subscribe((response: SupplierResponse) => {

        this.supplierForm.patchValue({
          name: response.name,
          email: response.email,
          phone: response.phone,
          description: response.description,
          address: response.address,
          createdAt: response.createdAt,
          createdBy: response.createdBy,
          updatedAt: response.updatedAt,
          updatedBy: response.updatedBy,
        });

        this.products = response.products || [];
      });
    }

    this.productService.GetProductsList().subscribe({
      next: (response: ProductsListResponse[]) => {
        this.productsList = response;
      }, error: (error) => {
        console.log(error);
      }
    });
  }

  validate = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.supplierForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  close() {
    this.activeModal.close();
  }

  removeProduct(index: number) {
    this.products.splice(index, 1);
  }

  updateSupplier = (supplierFormValue: any) => {
    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea actualizar el suplidor?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const supplier = { ...supplierFormValue };
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
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Suplidor actualizado!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(() => {
              this.activeModal.close(true);
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

  AddSupplier = (supplierFormValue: any) => {

    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea guardar el suplidor?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const supplier = { ...supplierFormValue };

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
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Suplidor guardado!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(result => {
              this.activeModal.close(true);
            });
          }, error: (error) => {
            console.log(error);
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = error;
            modalRef.componentInstance.status = Status.Failed;
          }
        });
      }
    });
  }
}

import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal, NgbDateStruct, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CategoriesService } from '../../shared/services/categories.service';
import { UsersService } from '../../shared/services/users.service';
import { DiscountsService } from '../../shared/services/discounts.service';
import { FormGroup, FormControl } from '@angular/forms';
import { CategoryManagementResponse } from '../../interfaces/Product/Response/categoryManagementResponse';
import { ManagementDiscountsResponse } from '../../interfaces/Product/Response/managementDiscountsResponse';
import { SaveModalComponent } from '../../helpers/save-modal/save-modal.component';
import { Status } from '../../helpers/save-modal/status';
import { DiscountDto } from '../../interfaces/Product/discountDto';
import { ProductsDiscountDto } from '../../interfaces/Product/productsDiscountDto';

@Component({
  selector: 'app-modal-discount',
  templateUrl: './modal-discount.component.html',
  styleUrls: ['./modal-discount.component.scss']
})
export class ModalDiscountComponent implements OnInit {
  @Input() read: boolean = false;
  @Input() update: boolean = false;
  @Input() title: string = '';
  @Input() code: string = '';

  discountForm: any;
  products: any[] = [];
  productForm: any;
  model!: NgbDateStruct;
  
  updateProduct = false;
  productTitle = '';

  codeFocused = false;
  nameFocused = false;
  typeFocused = false;
  descriptionFocused = false;
  valueFocused = false;
  maxTimesApplyFocused = false;
  startFocused = false;
  endFocused = false;
  productsDiscountsFocused = false;

  productCodeFocused = false;
  optionIdFocused = false;

  constructor(
    public activeModal: NgbActiveModal,
    private modalService: NgbModal,
    private service: DiscountsService,
    private userService: UsersService
  ) { 
  }

  userName(id: string, id2: string) {
    this.userService.UserName(id).subscribe((response) => {
      this.discountForm.patchValue({
        createdBy: response.userName
      });
    });
    this.userService.UserName(id2).subscribe((response) => {
      this.discountForm.patchValue({
        updatedBy: response.userName
      });
    });
  }

  ngOnInit(): void {
    this.discountForm = new FormGroup({
      code: new FormControl(''),
      name: new FormControl(''),
      type: new FormControl(0),
      description: new FormControl(''),
      value: new FormControl(0),
      maxTimesApply: new FormControl(0), 
      start: new FormControl(''),
      end: new FormControl(''),
      productsDiscounts: new FormControl('')
    })

    if (this.update) {
      this.service.GetManagementDiscount(this.code).subscribe((response: ManagementDiscountsResponse) => {
        this.discountForm.patchValue({
          code: response.code,
          name: response.name,
          type: response.type,
          description: response.description,
          value: response.value,
          maxTimesApply: response.maxTimesApply,
          start: response.start,
          end: response.end,
        });
        this.products = response.productsDiscounts || [];
      });
    } else if (this.read) {
      this.discountForm = new FormGroup({
        code: new FormControl(''),
        name: new FormControl(''),
        type: new FormControl(0),
        description: new FormControl(''),
        value: new FormControl(0),
        maxTimesApply: new FormControl(0),
        start: new FormControl(''),
        end: new FormControl(''),
        productsDiscounts: new FormControl(''),
        createdAt: new FormControl(''),
        createdBy: new FormControl(''),
        updatedAt: new FormControl(''),
        updatedBy: new FormControl('')
      })

      this.service.GetManagementDiscount(this.code).subscribe((response: ManagementDiscountsResponse) => {
        this.discountForm.patchValue({
          code: response.code,
          name: response.name,
          type: response.type,
          description: response.description,
          value: response.value,
          maxTimesApply: response.maxTimesApply,
          start: response.start,
          end: response.end,
          createdAt: response.createdAt,
          updatedAt: response.updatedAt,
        });

        this.userName(response.createdBy, response.updatedBy);

        this.products = response.productsDiscounts || [];
      });
    }
  }

  addNewProduct(code: string) {
    this.productTitle = 'Añadir Producto a descontar'
    this.productForm = new FormGroup({
      productCode: new FormControl(code),
      optionId: new FormControl(''),
    })
    setTimeout(() => {

    }, 10);
  }

  validate = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.discountForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  validateProduct = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.productForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  close() {
    this.activeModal.close();
  }

  cancelProduct() {
    this.updateProduct = false;
    this.productForm = null;
  }

  UpdateProduct(productFormValue: any) {
    const product = { ...productFormValue };

    const productDto: ProductsDiscountDto = {
      productCode: product.productCode,
      optionId: product.optionId,
    }

    this.products[product.index] = productDto;
    this.updateProduct = false;
    this.productForm = null;
  }

  selectProduct(index: number) {
    this.updateProduct = true;
    this.productTitle = 'Modificar Descuento a descontar'
    this.productForm = new FormGroup({
      index: new FormControl(index),
      productCode: new FormControl(this.products[index].productCode),
      optionId: new FormControl(this.products[index].optionId),
    })
    if (this.read) {
      this.productForm = new FormGroup({
        index: new FormControl(index),
        productCode: new FormControl(this.products[index].productCode),
        optionId: new FormControl(this.products[index].optionId),
        createdAt: new FormControl(this.products[index].createdAt),
        updatedAt: new FormControl(this.products[index].updatedAt)
      });
    }

    setTimeout(() => {

    }, 10);
  }

  removeProduct(index: number) {
    this.products.splice(index, 1);
  }

  saveProduct(productFormValue: any) {
    const product = { ...productFormValue };
    const productDto: ProductsDiscountDto = {
      productCode: product.code,
      optionId: product.name,
    }

    this.products.push(productDto);
    this.productForm = null;
  }
  
  updateDiscount = (discountFormValue: any) => {
    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea actualizar el descuento?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const discount = { ...discountFormValue };

        const discountDto: DiscountDto = {
          code: this.code,
          name: discount.name,
          type: discount.type,
          description: discount.description,
          value: discount.value,
          maxTimesApply: discount.maxTimesApply,
          start: discount.start,
          end: discount.end,
          productsDiscounts: this.products
        }
        this.service.UpdateDiscount(this.code, discountDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Descuento actualizado!';
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

  AddDiscount = (discountFormValue: any) => {

    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea guardar el descuento?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const discount = { ...discountFormValue };

        const discountDto: DiscountDto = {
          code: this.code,
          name: discount.name,
          type: discount.type,
          description: discount.description,
          value: discount.value,
          maxTimesApply: discount.maxTimesApply,
          start: discount.start,
          end: discount.end,
          productsDiscounts: this.products
        }

        this.service.AddDiscount(discountDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Descuento guardado!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(result => {
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
}

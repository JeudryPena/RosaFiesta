import { Component, ElementRef, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { SaveModalComponent } from '../../helpers/save-modal/save-modal.component';
import { Status } from '../../helpers/save-modal/status';
import { ManagementDiscountsResponse } from '../../interfaces/Product/Response/managementDiscountsResponse';
import { OptionsListResponse } from '../../interfaces/Product/Response/options-list-response';
import { DiscountDto } from '../../interfaces/Product/discountDto';
import { DiscountsService } from '../../shared/services/discounts.service';
import { ProductsService } from '../../shared/services/products.service';
import { UsersService } from '../../shared/services/users.service';

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
  date!: Date[];
  minDate: Date;
  maxDate: Date;
  optionsList: OptionsListResponse[] = [];
  selected?: string;

  onSelect(event: TypeaheadMatch): void {
    this.products.push({
      optionId: event.item.id,
      title: event.item.title
    });
    this.selected = '';
  }

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
  optionIdFocused = false;

  constructor(
    public activeModal: NgbActiveModal,
    private modalService: NgbModal,
    private service: DiscountsService,
    private userService: UsersService,
    public el: ElementRef,
    private productService: ProductsService
  ) {
    this.minDate = new Date();
    this.maxDate = new Date();
    this.minDate.setDate(this.minDate.getDate());
    this.maxDate.setDate(this.maxDate.getDate() + 3648);
  }

  existingOption(option: any) {

    console.log(option)
  }

  changeTime(start: any, end: any) {
    this.date = this.discountForm.value.date;
    this.date[0].setUTCHours(start.getHours(), start.getMinutes(), start.getSeconds());
    this.date[1].setUTCHours(end.getHours(), end.getMinutes(), end.getSeconds());
    console.log(this.date);
    this.discountForm.patchValue({
      date: this.date
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
      date: new FormControl(''),
      start: new FormControl(''),
      end: new FormControl(''),
      productsDiscounts: new FormControl('')
    })

    if (this.update) {
      this.service.GetManagementDiscount(this.code).subscribe((response: ManagementDiscountsResponse) => {
        let start = new Date(response.start);
        let end = new Date(response.end);
        this.date = [start, end];
        this.minDate.setDate(this.date[0].getDate());
        this.discountForm.patchValue({
          id: response.id,
          name: response.name,
          type: response.type,
          description: response.description,
          value: response.value,
          maxTimesApply: response.maxTimesApply,
          start: response.start,
          end: response.end,
          date: this.date
        });
        this.products = response.productsDiscounts || [];
      });
    } else if (this.read) {

      this.discountForm = new FormGroup({
        name: new FormControl(''),
        type: new FormControl(0),
        description: new FormControl(''),
        value: new FormControl(0),
        maxTimesApply: new FormControl(0),
        start: new FormControl(''),
        end: new FormControl(''),
        date: new FormControl(''),
        productsDiscounts: new FormControl(''),
        createdAt: new FormControl(''),
        createdBy: new FormControl(''),
        updatedAt: new FormControl(''),
        updatedBy: new FormControl('')
      })

      this.service.GetManagementDiscount(this.code).subscribe((response: ManagementDiscountsResponse) => {
        let start = new Date(response.start);
        let end = new Date(response.end);
        this.date = [start, end];
        this.minDate.setDate(this.date[0].getDate());

        this.discountForm.patchValue({
          name: response.name,
          type: response.type,
          description: response.description,
          value: response.value,
          maxTimesApply: response.maxTimesApply,
          start: response.start,
          end: response.end,
          createdAt: response.createdAt,
          updatedAt: response.updatedAt,
          createdBy: response.createdBy,
          updatedBy: response.updatedBy,
          date: this.date
        });

        this.products = response.productsDiscounts || [];
      });
    }

    this.productService.GetOptions().subscribe({
      next: (response: OptionsListResponse[]) => {
        this.optionsList = response;
      }, error: (error) => {
        console.log(error);
      }
    });
  }

  validate = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.discountForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  close() {
    this.activeModal.close();
  }

  removeProduct(index: number) {
    this.products.splice(index, 1);
  }

  updateDiscount = (discountFormValue: any) => {
    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea actualizar el descuento?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const discount = { ...discountFormValue };
        const discountDto: DiscountDto = {
          name: discount.name,
          type: discount.type,
          description: discount.description,
          value: discount.value,
          maxTimesApply: discount.maxTimesApply,
          start: this.date[0].toISOString(),
          end: this.date[1].toISOString(),
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
          name: discount.name,
          type: discount.type,
          description: discount.description,
          value: discount.value,
          maxTimesApply: discount.maxTimesApply,
          start: this.date[0].toISOString(),
          end: this.date[1].toISOString(),
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

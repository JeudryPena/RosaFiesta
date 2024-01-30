import {Component, ElementRef, Input, OnInit} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {NgbActiveModal, NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {SaveModalComponent} from '@core/shared/components/save-modal/save-modal.component';
import {Status} from '@core/shared/components/save-modal/status';
import {ManagementDiscountsResponse} from '@core/interfaces/Product/Response/managementDiscountsResponse';
import {OptionsListResponse} from '@core/interfaces/Product/Response/optionsListResponse';
import {DiscountDto} from '@core/interfaces/Product/discountDto';
import {DiscountsService} from '../../services/discounts.service';
import {ProductsService} from '../../services/products.service';
import {BehaviorSubject, lastValueFrom} from "rxjs";
import {DatePipe} from "@angular/common";

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

  discountForm$ = new BehaviorSubject<FormGroup>(null);

  products: any[] = [];
  minDate!: Date;
  maxDate!: Date;
  optionsList: OptionsListResponse[] = [];
  selected?: string;

  constructor(
    private fb: FormBuilder,
    public activeModal: NgbActiveModal,
    private modalService: NgbModal,
    private service: DiscountsService,
    public el: ElementRef,
    private productService: ProductsService,
    private datePipe: DatePipe
  ) {
  }

  onSelect(event: any): void {
    this.products.push({
      optionId: event.id,
      option: {
        title: event.title,
      }
    });
    this.selected = '';
  }

  async ngOnInit() {
    this.minDate = new Date();
    this.maxDate = new Date();
    if (!this.update && !this.read) {
      this.onCreate();
    } else if (this.update) {
      this.onEdit();
    } else if (this.read) {
      this.onRead();
    }
  }

  onCreate() {
    this.maxDate.setDate(this.minDate.getDate() + 3648);
    this.maxDate.setHours(this.maxDate.getHours(), this.maxDate.getMinutes(), this.maxDate.getSeconds() + 1);
    this.navegationProperties();
    this.discountForm$.next(this.fb.group({
      value: [0],
      start: [this.minDate],
      end: [],
      productsDiscounts: [],
    }));
  }

  async onEdit() {
    const discount$ = this.service.GetManagementDiscount(this.code);
    let response: ManagementDiscountsResponse = await lastValueFrom(discount$);
    this.maxDate.setDate(this.minDate.getDate() + 3648);
    this.maxDate.setHours(this.maxDate.getHours(), this.maxDate.getMinutes(), this.maxDate.getSeconds() + 1);
    this.products = response.productsDiscounts || [];
    this.navegationProperties();
    this.discountForm$.next(this.fb.group({
      value: response.value,
      start: new Date(response.start),
      end: new Date(response.end),
      productsDiscounts: [],
    }));
  }

  async onRead() {
    const discount$ = this.service.GetManagementDiscount(this.code);
    let response: ManagementDiscountsResponse = await lastValueFrom(discount$);
    this.products = response.productsDiscounts || [];
    const form = this.fb.group({
      value: response.value,
      start: new Date(response.start),
      end: new Date(response.end),
      createdAt: this.datePipe.transform(response.createdAt, 'dd-MMM-yyyy h:mm:ss a'),
      updatedAt: this.datePipe.transform(response.updatedAt, 'dd-MMM-yyyy h:mm:ss a'),
      createdBy: response.createdBy,
      updatedBy: response.updatedBy,
    });
    form.disable();
    this.discountForm$.next(form);
  }

  navegationProperties() {
    this.productService.GetOptions().subscribe({
      next: (response: OptionsListResponse[]) => {
        this.optionsList = response;
      }, error: (error) => {
        console.log(error);
      }
    });
  }

  validate = (controlName: string, errorName: string) => {
    const form = this.discountForm$.getValue();
    const control = form.get(controlName);
    return control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  close() {
    this.activeModal.close({
      discharged: true
    });

  }

  removeProduct(index: number) {
    this.products.splice(index, 1);
  }

  updateDiscount = (discountFormValue: any) => {
    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea actualizar el descuento?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const discount = {...discountFormValue};
        const discountDto: DiscountDto = {
          value: discount.value,
          start: discount.start.toISOString(),
          end: discount.end.toISOString(),
          productsDiscounts: this.products
        }
        this.service.UpdateDiscount(this.code, discountDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = 'Descuento actualizado!';
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

  AddDiscount = (discountFormValue: any) => {

    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea guardar el descuento?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const discount = {...discountFormValue};

        const discountDto: DiscountDto = {
          value: discount.value,
          start: discount.start.toISOString(),
          end: discount.end.toISOString(),
          productsDiscounts: this.products
        }

        this.service.AddDiscount(discountDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = 'Descuento guardado!';
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

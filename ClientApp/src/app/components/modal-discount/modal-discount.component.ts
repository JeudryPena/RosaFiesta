import {Component, ElementRef, Input, OnInit} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {NgbActiveModal, NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {TypeaheadMatch} from 'ngx-bootstrap/typeahead';
import {SaveModalComponent} from '../../helpers/save-modal/save-modal.component';
import {Status} from '../../helpers/save-modal/status';
import {ManagementDiscountsResponse} from '../../interfaces/Product/Response/managementDiscountsResponse';
import {OptionsListResponse} from '../../interfaces/Product/Response/optionsListResponse';
import {DiscountDto} from '../../interfaces/Product/discountDto';
import {DiscountsService} from '../../shared/services/discounts.service';
import {ProductsService} from '../../shared/services/products.service';
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
  date!: Date[];
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

  onSelect(event: TypeaheadMatch): void {
    this.products.push({
      optionId: event.item.id,
      option: {
        title: event.item.title,
      }
    });
    this.selected = '';
  }

  changeTime(start: any, end: any) {
    const form = this.discountForm$.getValue();
    this.date = form.value.date;
    this.date[0].setUTCHours(start.getHours(), start.getMinutes(), start.getSeconds());
    this.date[1].setUTCHours(end.getHours(), end.getMinutes(), end.getSeconds());
    form.patchValue({
      date: this.date
    });
    this.discountForm$.next(form);
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
      date: [],
      start: [this.minDate],
      end: [this.maxDate],
      productsDiscounts: [],
    }));
  }

  async onEdit() {
    const discount$ = this.service.GetManagementDiscount(this.code);
    let response: ManagementDiscountsResponse = await lastValueFrom(discount$);
    let start = new Date(response.start);
    let end = new Date(response.end);
    this.date = [start, end];
    this.minDate.setDate(this.date[0].getDate());
    this.maxDate.setDate(this.minDate.getDate() + 3648);
    this.maxDate.setHours(this.maxDate.getHours(), this.maxDate.getMinutes(), this.maxDate.getSeconds() + 1);
    this.products = response.productsDiscounts || [];
    this.navegationProperties();
    this.discountForm$.next(this.fb.group({
      value: response.value,
      date: this.date,
      start: this.minDate,
      end: this.maxDate,
      productsDiscounts: [],
    }));
  }

  async onRead() {
    const discount$ = this.service.GetManagementDiscount(this.code);
    let response: ManagementDiscountsResponse = await lastValueFrom(discount$);
    let start = new Date(response.start);
    let end = new Date(response.end);
    this.date = [start, end];
    this.products = response.productsDiscounts || [];
    const form = this.fb.group({
      value: response.value,
      date: this.date,
      start: this.minDate,
      end: this.maxDate,
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
          start: this.date[0].toISOString(),
          end: this.date[1].toISOString(),
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
          start: this.date[0].toISOString(),
          end: this.date[1].toISOString(),
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

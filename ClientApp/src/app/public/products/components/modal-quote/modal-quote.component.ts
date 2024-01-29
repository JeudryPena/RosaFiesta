import {Component, Input, OnInit} from '@angular/core';
import {BehaviorSubject} from "rxjs";
import {FormBuilder, FormGroup} from "@angular/forms";
import {OptionsListResponse} from "@core/interfaces/Product/Response/optionsListResponse";
import {NgbActiveModal, NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {QuotesService} from "@intranet/services/quotes.service";
import {ProductsService} from "@admin/inventory/services/products.service";
import {SaveModalComponent} from "@core/shared/components/save-modal/save-modal.component";
import {Status} from "@core/shared/components/save-modal/status";
import {OficializeDto} from "@core/interfaces/Product/UserInteract/OficializeDto";
import {OficializeItemsDto} from "@core/interfaces/Product/UserInteract/OficializeItemsDto";

@Component({
  selector: 'app-modal-quote',
  templateUrl: './modal-quote.component.html',
  styleUrls: ['./modal-quote.component.sass']
})
export class ModalQuoteComponent implements OnInit {
  @Input() title: string = '';
  @Input() orderId: string = '';
  @Input() id: string = '';

  quoteForm$ = new BehaviorSubject<FormGroup>(null);
  products: OficializeItemsDto[] = [];
  optionsList: OptionsListResponse[] = [];
  minDate!: Date;
  maxDate!: Date;

  constructor(
    private fb: FormBuilder,
    public activeModal: NgbActiveModal,
    private modalService: NgbModal,
    private readonly quoteService: QuotesService,
    private readonly productService: ProductsService
  ) {
  }

  ngOnInit(): void {
    this.minDate = new Date();
    this.maxDate = new Date();
    this.maxDate.setDate(this.minDate.getDate() + 3648);
    this.maxDate.setHours(this.maxDate.getHours(), this.maxDate.getMinutes(), this.maxDate.getSeconds() + 1);
    this.navegationProperties();
    this.quoteForm$.next(this.fb.group({
      products: this.fb.array([]),
      shipping: [0],
      phone: [''],
      address: [''],
      description: [''],
      location: [''],
      province: [''],
      postalCode: [''],
      eventDate: [],
    }));
  }

  onSelect(event: any): void {
    this.products.push({
      optionId: event.id,
      productId: event.productId,
      quantity: 0,
      title: event.title
    });
  }

  close() {
    this.activeModal.close({
      discharged: true
    });
  }

  removeProduct(index: number) {
    this.products.splice(index, 1);
  }

  validate = (controlName: string, errorName: string) => {
    const form = this.quoteForm$.getValue();
    const control = form.get(controlName);
    return control.invalid && control.dirty && control.touched && control.hasError(errorName);
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


  AddQuote = (quoteFormValue: any) => {

    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea guardar el descuento?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const quote = {...quoteFormValue};

        const oficializeDto: OficializeDto = {
          id: this.id,
          orderId: this.orderId,
          products: this.products,
          shipping: quote.shipping,
          phone: quote.phone,
          address: quote.address,
          description: quote.description,
          location: quote.location,
          province: quote.province,
          postalCode: quote.postalCode,
          eventDate: quote.eventDate.toISOString(),
        }

        this.quoteService.oficializeQuote(oficializeDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = 'Cotización Oficializada!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(result => {
              this.activeModal.close(true);
            });
          }, error: (error) => {
            console.error(error);
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = error;
            modalRef.componentInstance.status = Status.Failed;
          }
        });
      }
    });
  }

  changeValue($event: Event, i: number) {
    const value = ($event.target as HTMLInputElement).value;
    this.products[i].quantity = parseInt(value);
  }
}

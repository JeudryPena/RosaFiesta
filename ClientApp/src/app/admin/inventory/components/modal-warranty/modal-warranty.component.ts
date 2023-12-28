import {Component, ElementRef, Input, OnInit} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {NgbActiveModal, NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {SaveModalComponent} from '@core/shared/components/save-modal/save-modal.component';
import {Status} from '@core/shared/components/save-modal/status';
import {ProductsListResponse} from '@core/interfaces/Product/Response/productsListResponse';
import {WarrantyResponse} from '@core/interfaces/Product/Response/warrantyResponse';
import {WarrantyDto} from '@core/interfaces/Product/warrantyDto';
import {ProductsService} from '../../services/products.service';
import {WarrantiesService} from '../../services/warranties.service';
import {BehaviorSubject, lastValueFrom} from "rxjs";
import {DatePipe} from "@angular/common";

@Component({
  selector: 'app-modal-warranty',
  templateUrl: './modal-warranty.component.html',
  styleUrls: ['./modal-warranty.component.scss']
})
export class ModalWarrantyComponent implements OnInit {
  @Input() read: boolean = false;
  @Input() update: boolean = false;
  @Input() title: string = '';
  @Input() id: string = '';

  warrantyForm$ = new BehaviorSubject<FormGroup>(null);
  products: any[] = [];
  selected?: string;
  productsList: ProductsListResponse[] = [];

  constructor(
    private fb: FormBuilder,
    public activeModal: NgbActiveModal,
    private modalService: NgbModal,
    private service: WarrantiesService,
    public el: ElementRef,
    private productService: ProductsService,
    private datePipe: DatePipe
  ) {
  }

  onSelect(event: any): void {
    this.products.push({
      id: event.item.id,
      option: {
        title: event.item.option.title,
      }
    });
    this.selected = '';
    console.log(event.item)
  }

  ngOnInit(): void {
    if (!this.update && !this.read) {
      this.onCreate();
    } else if (this.update) {
      this.onEdit();
    } else {
      this.onRead();
    }
    this.productService.GetProductsList().subscribe({
      next: (response: ProductsListResponse[]) => {
        this.productsList = response;
      }, error: (error) => {
        console.log(error);
      }
    });
  }

  onCreate() {
    this.warrantyForm$.next(this.fb.group({
      name: [''],
      type: [0],
      period: [0],
      description: [''],
      products: [],
    }));
  }

  async onEdit() {
    const warranty$ = this.service.GetManagementWarranty(this.id);
    let response: WarrantyResponse = await lastValueFrom(warranty$);
    this.products = response.products || [];
    this.warrantyForm$.next(this.fb.group({
      name: response.name,
      type: response.type,
      period: response.period,
      description: response.description,
      products: [],
    }));
  }

  async onRead() {
    const warranty$ = this.service.GetManagementWarranty(this.id);
    let response: WarrantyResponse = await lastValueFrom(warranty$);
    this.products = response.products || [];
    const form = this.fb.group({
      name: response.name,
      type: response.type,
      period: response.period,
      description: response.description,
      products: [],
      createdAt: this.datePipe.transform(response.createdAt, 'dd-MMM-yyyy h:mm:ss a'),
      updatedAt: this.datePipe.transform(response.updatedAt, 'dd-MMM-yyyy h:mm:ss a'),
      createdBy: response.createdBy,
      updatedBy: response.updatedBy
    });
    form.disable();
    this.warrantyForm$.next(form);
  }

  validate = (controlName: string, errorName: string) => {
    const form = this.warrantyForm$.getValue();
    const control = form.get(controlName);
    return control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  close() {
    this.activeModal.close();
  }

  removeProduct(index: number
  ) {
    this.products.splice(index, 1);
  }

  updateWarranty = (warrantyFormValue: any) => {
    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea actualizar la garantía?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const warranty = {...warrantyFormValue};
        const warrantyDto: WarrantyDto = {
          name: warranty.name,
          type: warranty.type,
          period: warranty.period,
          description: warranty.description,
          warrantyProducts: this.products,
        }
        this.service.UpdateWarranty(this.id, warrantyDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = 'Garantía actualizada!';
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

  AddWarranty = (warrantyFormValue: any) => {

    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea guardar la garantía?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const warranty = {...warrantyFormValue};

        const warrantyDto: WarrantyDto = {
          name: warranty.name,
          type: warranty.type,
          period: warranty.period,
          description: warranty.description,
          warrantyProducts: this.products,
        }

        this.service.AddWarranty(warrantyDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = 'Garantía guardada!';
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

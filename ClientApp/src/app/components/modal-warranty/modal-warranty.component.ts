import { Component, ElementRef, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { SaveModalComponent } from '../../helpers/save-modal/save-modal.component';
import { Status } from '../../helpers/save-modal/status';
import { ProductsListResponse } from '../../interfaces/Product/Response/products-list-response';
import { WarrantyResponse } from '../../interfaces/Product/Response/warrantyResponse';
import { WarrantyDto } from '../../interfaces/Product/warrantyDto';
import { ProductsService } from '../../shared/services/products.service';
import { WarrantiesService } from '../../shared/services/warranties.service';

@Component({
  selector: 'app-modal-warranty',
  templateUrl: './modal-warranty.component.html',
  styleUrls: ['./modal-warranty.component.scss']
})
export class ModalWarrantyComponent {
  @Input() read: boolean = false;
  @Input() update: boolean = false;
  @Input() title: string = '';
  @Input() id: string = '';

  warrantyForm: any;
  products: any[] = [];
  selected?: string;
  updateProduct = false;
  productTitle = '';
  productsList: ProductsListResponse[] = [];

  nameFocused = false;
  typeFocused = false;
  periodFocused = false;
  descriptionFocused = false;
  conditionsFocused = false;
  productsFocused = false;

  constructor(
    public activeModal: NgbActiveModal,
    private modalService: NgbModal,
    private service: WarrantiesService,
    public el: ElementRef,
    private productService: ProductsService
  ) {
  }

  onSelect(event: TypeaheadMatch): void {
    this.products.push({
      id: event.item.id,
      name: event.item.name
    });
    this.selected = '';
  }

  ngOnInit(): void {
    this.warrantyForm = new FormGroup({
      name: new FormControl(''),
      type: new FormControl(0),
      period: new FormControl(0),
      description: new FormControl(''),
      conditions: new FormControl(''),
      products: new FormControl(''),
    });
    if (this.update) {
      this.service.GetManagementWarranty(this.id).subscribe((response: WarrantyResponse) => {
        this.warrantyForm.patchValue({
          name: response.name,
          type: response.type,
          period: response.period,
          description: response.description,
          conditions: response.conditions,
        });

        this.products = response.products || [];
      });
    } else if (this.read) {
      this.warrantyForm = new FormGroup({
        name: new FormControl(''),
        type: new FormControl(0),
        period: new FormControl(0),
        description: new FormControl(''),
        conditions: new FormControl(''),
        products: new FormControl(''),
        createdAt: new FormControl(''),
        createdBy: new FormControl(''),
        updatedAt: new FormControl(''),
        updatedBy: new FormControl('')
      })

      this.service.GetManagementWarranty(this.id).subscribe((response: WarrantyResponse) => {

        this.warrantyForm.patchValue({
          name: response.name,
          type: response.type,
          period: response.period,
          description: response.description,
          conditions: response.conditions,
          createdAt: response.createdAt,
          updatedAt: response.updatedAt,
          createdBy: response.createdBy,
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
    const control = this.warrantyForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  close() {
    this.activeModal.close();
  }

  removeProduct(index: number) {
    this.products.splice(index, 1);
  }

  updateWarranty = (warrantyFormValue: any) => {
    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea actualizar la garantía?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const warranty = { ...warrantyFormValue };
        const warrantyDto: WarrantyDto = {
          name: warranty.name,
          type: warranty.type,
          period: warranty.period,
          description: warranty.description,
          conditions: warranty.conditions,
          warrantyProducts: this.products,
        }
        this.service.UpdateWarranty(this.id, warrantyDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Garantía actualizada!';
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

  AddWarranty = (warrantyFormValue: any) => {

    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea guardar la garantía?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const warranty = { ...warrantyFormValue };

        const warrantyDto: WarrantyDto = {
          name: warranty.name,
          type: warranty.type,
          period: warranty.period,
          description: warranty.description,
          conditions: warranty.conditions,
          warrantyProducts: this.products,
        }

        this.service.AddWarranty(warrantyDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Garantía guardado!';
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



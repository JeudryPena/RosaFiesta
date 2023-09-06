import {Component, Input, OnInit} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {NgbActiveModal, NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {SaveModalComponent} from '../../helpers/save-modal/save-modal.component';
import {Status} from '../../helpers/save-modal/status';
import {CategoryDto} from '../../interfaces/Product/categoryDto';
import {CategoriesService} from '../../shared/services/categories.service';
import {BehaviorSubject, lastValueFrom} from "rxjs";
import {DatePipe} from "@angular/common";

@Component({
  selector: 'app-modal-category',
  templateUrl: './modal-category.component.html',
  styleUrls: ['./modal-category.component.scss']
})
export class ModalCategoryComponent implements OnInit {
  @Input() read: boolean = false;
  @Input() update: boolean = false;
  @Input() title: string = '';
  @Input() categoryId: number = 0;

  categoryForm$: BehaviorSubject<FormGroup<any>> = new BehaviorSubject<FormGroup<any>>(null);

  constructor(
    private modalService: NgbModal,
    public activeModal: NgbActiveModal,
    private service: CategoriesService,
    private fb: FormBuilder,
    private datePipe: DatePipe
  ) {
  }

  ngOnInit(): void {
    if (!this.read && !this.update)
      this.onCreate();
    else if (this.update)
      this.onEdit();
    else
      this.onRead();
  }

  onCreate() {
    this.categoryForm$.next(this.fb.group({
      name: [''],
      subCategories: [],
      icon: [''],
      description: [''],
    }));
  }

  async onEdit() {
    const category$ = this.service.GetCategoryManagement(this.categoryId);
    let response = await lastValueFrom(category$);
    this.categoryForm$.next(this.fb.group({
      name: response.name,
      icon: response.icon,
      description: response.description
    }));
  }

  async onRead() {
    const product$ = this.service.GetCategoryManagement(this.categoryId);
    let response = await lastValueFrom(product$);
    const form = this.fb.group({
      name: response.name,
      icon: response.icon,
      description: response.description,
      createdAt: this.datePipe.transform(response.createdAt, 'dd-MMM-yyyy h:mm:ss a'),
      updatedAt: this.datePipe.transform(response.updatedAt, 'dd-MMM-yyyy h:mm:ss a'),
      createdBy: response.createdBy,
      updatedBy: response.updatedBy
    });
    form.disable();
    this.categoryForm$.next(form);
  }

  validate = (controlName: string, errorName: string) => {
    const form = this.categoryForm$.getValue();
    const control = form.get(controlName);
    return control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  close() {
    this.activeModal.close();
  }

  updateCategory = (categoryFormValue: any) => {
    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea actualizar la Categoría?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const category = {...categoryFormValue};

        const categoryDto: CategoryDto = {
          name: category.name,
          icon: category.icon,
          description: category.description
        }
        this.service.UpdateCategory(this.categoryId, categoryDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = 'Categoría actualizada!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(result => {
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

  AddCategory = (categoryFormValue: any) => {

    const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = '¿Desea guardar la categoría?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const category = {...categoryFormValue};

        const categoryDto: CategoryDto = {
          name: category.name,
          icon: category.icon,
          description: category.description
        }

        this.service.AddCategory(categoryDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, {size: '', scrollable: true});
            modalRef.componentInstance.title = 'Categoría guardada!';
            modalRef.componentInstance.status = Status.Success;

            modalRef.result.then(result => {
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
}

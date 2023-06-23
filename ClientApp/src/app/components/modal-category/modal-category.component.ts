import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { SaveModalComponent } from '../../helpers/save-modal/save-modal.component';
import { Status } from '../../helpers/save-modal/status';
import { CategoryManagementResponse } from '../../interfaces/Product/Response/categoryManagementResponse';
import { CategoryDto } from '../../interfaces/Product/categoryDto';
import { SubCategoryDto } from '../../interfaces/Product/subCategoryDto';
import { CategoriesService } from '../../shared/services/categories.service';
import { UsersService } from '../../shared/services/users.service';

@Component({
  selector: 'app-modal-category',
  templateUrl: './modal-category.component.html',
  styleUrls: ['./modal-category.component.scss']
})
export class ModalCategoryComponent implements OnInit {
  updateSubCategory = false;
  subCategoryTittle = '';

  @Input() read: boolean = false;
  @Input() update: boolean = false;
  @Input() title: string = '';
  @Input() categoryId: number = 0;

  titleFocused = false;
  iconFocused = false;
  subCategoriesFocused = false;
  descriptionFocused = false;

  subTitleFocused = false;
  subIconFocused = false;
  subDescriptionFocused = false;

  categoryForm: any;
  subCategories: any[] = [];
  subCategoryForm: any;

  constructor(
    private modalService: NgbModal,
    public activeModal: NgbActiveModal,
    private service: CategoriesService,
    private userService: UsersService
  ) {
  }

  userName(id: string, id2: string) {
    this.userService.UserName(id).subscribe((response) => {
      this.categoryForm.patchValue({
        createdBy: response.userName
      });
    });
    this.userService.UserName(id2).subscribe((response) => {
      this.categoryForm.patchValue({
        updatedBy: response.userName
      });
    });
  }

  ngOnInit(): void {
    this.categoryForm = new FormGroup({
      name: new FormControl(''),
      subCategories: new FormControl(''),
      icon: new FormControl(''),
      description: new FormControl('')
    })
    if (this.update) {
      this.service.GetCategory(this.categoryId).subscribe((response: CategoryManagementResponse) => {
        this.categoryForm.patchValue({
          name: response.name,
          icon: response.icon,
          description: response.description
        });
        this.subCategories = response.subCategories || [];
      });
    } else if (this.read) {
      this.categoryForm = new FormGroup({
        name: new FormControl(''),
        subCategories: new FormControl(''),
        icon: new FormControl(''),
        description: new FormControl(''),
        createdAt: new FormControl(''),
        createdBy: new FormControl(''),
        updatedAt: new FormControl(''),
        updatedBy: new FormControl('')
      })

      this.service.GetCategory(this.categoryId).subscribe((response: CategoryManagementResponse) => {
        this.categoryForm.patchValue({
          name: response.name,
          icon: response.icon,
          description: response.description,
          createdAt: response.createdAt,
          updatedAt: response.updatedAt,
        });

        this.userName(response.createdBy, response.updatedBy);

        this.subCategories = response.subCategories || [];
      });
    }
  }

  addNewSubcategory(name: string) {

    this.subCategoryTittle = 'Añadir SubCategoría'
    this.subCategoryForm = new FormGroup({
      name: new FormControl(name),
      icon: new FormControl(''),
      description: new FormControl('')
    })
    setTimeout(() => {

    }, 10);
  }

  saveSubcategory(subCategoryFormValue: any) {
    const category = { ...subCategoryFormValue };
    const subCategoryDto: SubCategoryDto = {
      name: category.name,
      icon: category.icon,
      description: category.description
    }

    this.subCategories.push(subCategoryDto);
    this.subCategoryForm = null;
  }

  updateSubCat(subCategoryFormValue: any) {
    const category = { ...subCategoryFormValue };

    const subCategoryDto: SubCategoryDto = {
      name: category.name,
      icon: category.icon,
      description: category.description
    }

    this.subCategories[category.index] = subCategoryDto;
    this.updateSubCategory = false;
    this.subCategoryForm = null;
  }

  selectSubCategory(index: number) {
    this.updateSubCategory = true;
    this.subCategoryTittle = 'Modificar SubCategoría'
    this.subCategoryForm = new FormGroup({
      index: new FormControl(index),
      name: new FormControl(this.subCategories[index].name),
      icon: new FormControl(this.subCategories[index].icon),
      description: new FormControl(this.subCategories[index].description),
    })
    setTimeout(() => {

    }, 10);
  }

  validate = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.categoryForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  validateSub = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.subCategoryForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  cancelSubCategory() {
    this.updateSubCategory = false;
    this.subCategoryForm = null;
  }

  removeSubcategory(index: number) {
    this.subCategories.splice(index, 1);
  }

  close() {
    this.activeModal.close();
  }

  updateCategory = (categoryFormValue: any) => {
    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea actualizar la Categoría?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const category = { ...categoryFormValue };

        const categoryDto: CategoryDto = {
          name: category.name,
          icon: category.icon,
          subCategories: this.subCategories,
          description: category.description
        }
        this.service.UpdateCategory(this.categoryId, categoryDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Categoría actualizada!';
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

  AddCategory = (categoryFormValue: any) => {

    const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
    modalRef.componentInstance.title = '¿Desea guardar la categoría?';
    modalRef.componentInstance.status = Status.Pending;

    modalRef.result.then(result => {
      if (result) {
        const category = { ...categoryFormValue };

        const categoryDto: CategoryDto = {
          name: category.name,
          icon: category.icon,
          subCategories: this.subCategories,
          description: category.description
        }

        this.service.AddCategory(categoryDto).subscribe({
          next: () => {
            const modalRef = this.modalService.open(SaveModalComponent, { size: '', scrollable: true });
            modalRef.componentInstance.title = 'Categoría guardada!';
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

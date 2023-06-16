import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { CategoryPreviewResponse } from '../../interfaces/Product/Response/categoryPreviewResponse';
import { CategoryDto } from '../../interfaces/Product/categoryDto';
import { SubCategoryDto } from '../../interfaces/Product/subCategoryDto';
import { CategoriesService } from '../../shared/services/categories.service';

@Component({
  selector: 'app-modal-category',
  templateUrl: './modal-category.component.html',
  styleUrls: ['./modal-category.component.scss']
})
export class ModalCategoryComponent implements OnInit {
  updateSubCategory = false;
  subCategoryTittle = '';

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
    public activeModal: NgbActiveModal,
    private service: CategoriesService,
  ) {
  }

  ngOnInit(): void {
    this.categoryForm = new FormGroup({
      name: new FormControl(''),
      subCategories: new FormControl(''),
      icon: new FormControl(''),
      description: new FormControl('')
    })
    if (this.update) {
      this.service.GetCategory(this.categoryId).subscribe((response: CategoryPreviewResponse) => {
        this.categoryForm.patchValue({
          name: response.name,
          icon: response.icon,
          description: response.description
        });
        this.subCategories = response.subCategories || [];
      });
    }
  }

  addNewSubcategory(name: string) {
    if (name) this.subTitleFocused = true;
    this.subCategoryTittle = 'Añadir SubCategoría'
    this.subCategoryForm = new FormGroup({
      name: new FormControl(name),
      icon: new FormControl(''),
      description: new FormControl('')
    })
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
      description: new FormControl(this.subCategories[index].description)
    })
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
    const category = { ...categoryFormValue };

    const categoryDto: CategoryDto = {
      name: category.name,
      icon: category.icon,
      subCategories: this.subCategories,
      description: category.description
    }

    this.service.UpdateCategory(this.categoryId, categoryDto).subscribe(() => {
      this.activeModal.close();
    });
  }

  AddCategory = (categoryFormValue: any) => {
    const category = { ...categoryFormValue };

    const categoryDto: CategoryDto = {
      name: category.name,
      icon: category.icon,
      subCategories: this.subCategories,
      description: category.description
    }

    this.service.AddCategory(categoryDto).subscribe(() => {
      this.activeModal.close();
    });
  }
}

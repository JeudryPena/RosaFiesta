import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { CategoriesService } from '../../shared/services/categories.service';
import { CategoryDto } from '../../interfaces/Product/categoryDto';

@Component({
  selector: 'app-modal-category',
  templateUrl: './modal-category.component.html',
  styleUrls: ['./modal-category.component.scss']
})
export class ModalCategoryComponent {
  titleFocused = false;
  iconFocused = false;
  subCategoriesFocused = false;
  descriptionFocused = false;

  categoryForm: any;

  constructor(
    public activeModal: NgbActiveModal,
    private service: CategoriesService,
  ) {
    this.categoryForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      icon: new FormControl('', [Validators.required]),
      subCategories: new FormControl(''),
      description: new FormControl('', [Validators.required])
    })
  }

  AddCategory = (categoryFormValue: any) => {
    if (this.categoryForm.invalid) {
      return;
    }

    const category = { ...categoryFormValue };

    const categoryDto: CategoryDto = {
      name: category.name,
      icon: category.icon,
      subCategories: category.subCategories,
      description: category.description
    }

    this.service.AddCategory(categoryDto).subscribe(() => {
      this.activeModal.close();
    });
  }
}

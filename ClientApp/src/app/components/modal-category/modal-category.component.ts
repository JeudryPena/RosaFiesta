import { Component } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

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

  constructor(public activeModal: NgbActiveModal) {

  }
}

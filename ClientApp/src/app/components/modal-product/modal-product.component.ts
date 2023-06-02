import { Component } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-modal-product',
  templateUrl: './modal-product.component.html',
  styleUrls: ['./modal-product.component.css']
})
export class ModalProductComponent {

  codeFocused = false;
  titleFocused = false;
  optionsFocused = false;
  typeFocused = false;
  categoryIdFocused = false;
  warrantyIdFocused = false;
  supplierIdFocused = false;
  selectorFocused = true;

  constructor(public activeModal: NgbActiveModal) {

  }
}

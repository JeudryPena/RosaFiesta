import { Component } from '@angular/core';
import { NgbActiveModal, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-modal-discount',
  templateUrl: './modal-discount.component.html',
  styleUrls: ['./modal-discount.component.scss']
})
export class ModalDiscountComponent {
  codeFocused = false;
  nameFocused = false;
  typeFocused = false;
  descriptionFocused = false;
  valueFocused = false;
  maxTimesApplyFocused = false;
  startFocused = false;
  endFocused = false;
  productsDiscountsFocused = false;

  model!: NgbDateStruct;

  constructor(public activeModal: NgbActiveModal) {

  }
}

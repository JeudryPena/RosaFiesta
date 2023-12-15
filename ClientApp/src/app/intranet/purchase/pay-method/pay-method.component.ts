import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-pay-method',
  templateUrl: './pay-method.component.html',
  styleUrls: ['./pay-method.component.scss']
})
export class PayMethodComponent implements OnInit {
  payMethodForm: any;

  numberFocused = false;
  ownerFocused = false;
  expirationFocused = false;
  cvvFocused = false;

  ngOnInit(): void {
    this.payMethodForm = new FormGroup({
      cardNumber: new FormControl(''),
      ownerName: new FormControl(''),
      expiration: new FormControl(''),
      cvv: new FormControl(''),
    })
  }

  payValidate = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.payMethodForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }
}

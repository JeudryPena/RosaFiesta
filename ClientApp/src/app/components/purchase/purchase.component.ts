import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.scss']
})
export class PurchaseComponent implements OnInit {
  purchaseForm: any;
  nameFocused = false;

  ngOnInit(): void {
    this.purchaseForm = new FormGroup({
      address: new 
    })

    
  }

  validate = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.purchaseForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }
}

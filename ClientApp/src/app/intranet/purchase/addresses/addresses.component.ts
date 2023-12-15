import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-addresses',
  templateUrl: './addresses.component.html',
  styleUrls: ['./addresses.component.scss']
})
export class AddressesComponent implements OnInit {
  addressForm: any;

  titleFocused = false;
  phoneFocused = false;
  nameFocused = false;
  lastNameFocused = false;
  cityFocused = false;
  stateFocused = false;
  zipFocused = false;
  extraFocused = false;

  ngOnInit(): void {
    this.addressForm = new FormGroup({
      title: new FormControl(''),
      phoneNumber: new FormControl(''),
      name: new FormControl(''),
      lastName: new FormControl(''),
      city: new FormControl(''),
      state: new FormControl(''),
      zipCode: new FormControl(''),
      extraDetail: new FormControl(''),
    })
  }

  validate = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.addressForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }
}

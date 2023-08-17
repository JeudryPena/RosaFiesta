import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ICreateOrderRequest, IPayPalConfig } from 'ngx-paypal';
import { config } from 'src/app/env/config.dev';


@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.scss']
})
export class PurchaseComponent implements OnInit {
  purchaseForm: any;
  payMethodForm: any;
  addressForm: any;

  titleFocused = false;
  phoneFocused = false;
  nameFocused = false;
  lastNameFocused = false;
  cityFocused = false;
  stateFocused = false;
  zipFocused = false;
  extraFocused = false;

  numberFocused = false;
  ownerFocused = false;
  expirationFocused = false;
  cvvFocused = false;

  current_customer_id: any;
  order_id: any;

  public payPalConfig?: IPayPalConfig;

  constructor() { }

  ngOnInit(): void {
    this.initConfig();
    this.purchaseForm = new FormGroup({
      addressId: new FormControl(''),
      payMethodId: new FormControl(''),
    })
    this.payMethodForm = new FormGroup({
      cardNumber: new FormControl(''),
      ownerName: new FormControl(''),
      expiration: new FormControl(''),
      cvv: new FormControl(''),
    })
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

  private initConfig(): void {
    this.payPalConfig = {
      currency: 'USD',
      clientId: config.payPalClientId,
      createOrderOnClient: (data: any) => <ICreateOrderRequest>{
        intent: 'CAPTURE',
        purchase_units: [{
          amount: {
            currency_code: 'USD',
            value: '9.99',
            breakdown: {
              item_total: {
                currency_code: 'USD',
                value: '9.99'
              }
            }
          },
          items: [{
            name: 'Enterprise Subscription',
            quantity: '1',
            category: 'DIGITAL_GOODS',
            unit_amount: {
              currency_code: 'USD',
              value: '9.99',
            },
          }]
        }]
      },
      advanced: {
        commit: 'true'
      },
      style: {
        label: 'paypal',
        layout: 'vertical',
      },
      onApprove: (data: any, actions: any) => {
        console.log('onApprove - transaction was approved, but not authorized', data, actions);
        actions.order.get().then((details: any) => {
          console.log('onApprove - you can get full order details inside onApprove: ', details);
        });
      },
      onClientAuthorization(authorization) {
        console.log('onClientAuthorization - you should probably inform your server about completed transaction at this point', authorization);
      },
      onCancel: (data: any, actions: any) => {
        console.log('OnCancel', data, actions);
      },
    };
  }

  validate = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.addressForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  payValidate = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.payMethodForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }
}

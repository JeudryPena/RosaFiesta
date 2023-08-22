import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { ICreateOrderRequest, IPayPalConfig } from 'ngx-paypal';
import { config } from 'src/app/env/config.dev';
import { AddressesComponent } from '../addresses/addresses.component';
import { PayMethodsListResponse } from '../../interfaces/Product/Response/pay-methods-list-response';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { AddressesListResponse } from '../../interfaces/Product/UserInteract/Response/addresses-list-response';


@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.scss']
})
export class PurchaseComponent implements OnInit {
  purchaseForm: any;

  payMethods: PayMethodsListResponse[] = [];
  payMethodSelected: string | null = null;
  payMethodForms!: PayMethodsListResponse;

  addresses: AddressesListResponse[] = [];
  addressSelected: string | null = null;
  addressForms!: AddressesListResponse;

  public payPalConfig?: IPayPalConfig;

  constructor(
    public modalService: NgbModal,
    config: NgbModalConfig
  ) { }

  ngOnInit(): void {
    this.initConfig();
    this.purchaseForm = new FormGroup({
      addressId: new FormControl(''),
      payMethodId: new FormControl(''),
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

  createAddress() {
    const modalRef = this.modalService.open(AddressesComponent, { size: 'xl', scrollable: true });
    modalRef.result.then((result) => {
      if (result)
        this.retrieveData();
    });
  }

  retrieveData() {
    
  }

  onSelect(event: TypeaheadMatch, form: string): void {
    if (form == 'address') {
      this.addressForms = event.item;
    }
    else if (form == 'payMethod') {
      this.payMethodForms = event.item;
    }
  }
}

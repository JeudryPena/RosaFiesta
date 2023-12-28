import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {ICreateOrderRequest, IPayPalConfig} from 'ngx-paypal';
import {AddressesComponent} from './addresses/addresses.component';
import {PayMethodsListResponse} from "@core/interfaces/Product/Response/pay-methods-list-response";
import {AddressesListResponse} from "@core/interfaces/Product/UserInteract/Response/addresses-list-response";
import {config} from "@env/config.dev";


@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.scss']
})
export class PurchaseComponent implements OnInit {
  purchaseForm: any;

  payMethods: PayMethodsListResponse[] = [];
  payMethodForms!: PayMethodsListResponse;

  addressSelected: string | null = null;
  addressForms!: AddressesListResponse;

  public payPalConfig?: IPayPalConfig;

  constructor(
    public modalService: NgbModal
  ) {
  }

  ngOnInit(): void {
    this.initConfig();
    this.purchaseForm = new FormGroup({
      addressId: new FormControl(''),
      payMethodId: new FormControl(''),
    })
  }

  createAddress() {
    const modalRef = this.modalService.open(AddressesComponent, {size: 'xl', scrollable: true});
    modalRef.result.then((result) => {
      if (result)
        this.retrieveData();
    });
  }

  retrieveData() {

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
}

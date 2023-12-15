import {NgModule} from '@angular/core';
import {purchaseRouter} from "../purchase/purchase-routing.module";
import {PurchaseComponent} from "../purchase/purchase.component";
import {AddressesComponent} from "../purchase/addresses/addresses.component";
import {PayMethodComponent} from "../purchase/pay-method/pay-method.component";


@NgModule({
  declarations: [
    PurchaseComponent,
    AddressesComponent,
    PayMethodComponent
  ],
  imports: [
    purchaseRouter
  ],
  exports: [],
  providers: [],
  bootstrap: [PurchaseComponent]
})
export class PurchaseModule {
}

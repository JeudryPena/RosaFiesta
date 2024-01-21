import {NgModule} from '@angular/core';
import {purchaseRouter} from "../purchase/purchase-routing.module";
import {PurchaseComponent} from "../purchase/purchase.component";
import {PayMethodComponent} from "../purchase/pay-method/pay-method.component";
import {IntranetModule} from "@intranet/intranet.module";


@NgModule({
  declarations: [
    PurchaseComponent,
    PayMethodComponent
  ],
  imports: [
    purchaseRouter,
    IntranetModule
  ],
  exports: [],
  providers: []
})
export class PurchaseModule {
}

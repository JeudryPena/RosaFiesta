import {NgModule} from '@angular/core';
import {IntranetComponent} from './intranet.component';
import {CartComponent} from "./cart/cart.component";
import {MyOrdersComponent} from "./my-orders/my-orders.component";
import {SettingsComponent} from "./settings/settings.component";
import {WishListsComponent} from "./wish-lists/wish-lists.component";
import {SharedModule} from "@core/shared/shared.module";
import {intranetRouter} from "@intranet/intranet-routing.module";


@NgModule({
  declarations: [
    IntranetComponent,
    CartComponent,
    MyOrdersComponent,
    SettingsComponent,
    WishListsComponent
  ],
  imports: [
    SharedModule,
    intranetRouter
  ],
  exports: [],
  providers: [],
  bootstrap: [IntranetComponent]
})
export class IntranetModule {
}

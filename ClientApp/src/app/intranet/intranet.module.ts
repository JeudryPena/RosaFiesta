import {NgModule} from '@angular/core';
import {IntranetComponent} from './intranet.component';
import {MyOrdersComponent} from "./my-orders/my-orders.component";
import {SettingsComponent} from "./settings/settings.component";
import {WishListsComponent} from "./wish-lists/wish-lists.component";
import {SharedModule} from "@core/shared/shared.module";
import {intranetRouter} from "@intranet/intranet-routing.module";


@NgModule({
  declarations: [
    IntranetComponent,
    MyOrdersComponent,
    SettingsComponent,
    WishListsComponent
  ],
  imports: [
    intranetRouter,
    SharedModule
  ],
  exports: [
    SharedModule,
  ],
  providers: []
})
export class IntranetModule {
}

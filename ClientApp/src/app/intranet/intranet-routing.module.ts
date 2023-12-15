import {ModuleWithProviders} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from "@core/shared/components/layout/layout/layout.component";
import {SettingsComponent} from "./settings/settings.component";
import {MyOrdersComponent} from "./my-orders/my-orders.component";
import {AuthGuard} from "@core/guards/auth.guard";
import {WishListsComponent} from "./wish-lists/wish-lists.component";

const purchaseModule = () => import('./purchase/purchase.module').then(x => x.PurchaseModule);


const routes: Routes = [
  {
    path: '', component: LayoutComponent, canActivate: [AuthGuard], children: [
      {path: 'settings', component: SettingsComponent},
      {path: 'purchase', loadChildren: purchaseModule},
      {path: 'my-orders', component: MyOrdersComponent},
      {path: 'wishlist', component: WishListsComponent}
    ]
  }
];

export const intranetRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

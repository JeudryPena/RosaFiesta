import {ModuleWithProviders} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {SettingsComponent} from "./settings/settings.component";
import {AuthGuard} from "@core/guards/auth.guard";
import {WishListsComponent} from "./wish-lists/wish-lists.component";

const purchaseModule = () => import('./purchase/purchase.module').then(x => x.PurchaseModule);


const routes: Routes = [
  {path: 'purchase', loadChildren: purchaseModule, canActivate: [AuthGuard]},
  {path: 'settings', component: SettingsComponent},
  {path: 'wishlist', component: WishListsComponent}
];

export const intranetRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

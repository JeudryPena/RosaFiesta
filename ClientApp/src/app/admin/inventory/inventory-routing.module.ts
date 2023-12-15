import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {LayoutComponent} from "@root/layout/layout/layout.component";
import {AboutUsComponent} from "@public/home/about-us/about-us.component";
import {SettingsComponent} from "@privy/settings/settings.component";
import {PurchaseComponent} from "@privy/purchase/purchase.component";
import {MyOrdersComponent} from "@privy/my-orders/my-orders.component";
import {AuthGuard} from "@core/guards/auth.guard";
import {WishListsComponent} from "@privy/wish-lists/wish-lists.component";

const routes: Routes = [
  {
    path: '', loadChildren: () => import('@admin/dashboard/dashboard.module').then(m => m.DashboardModule)
  },
  {
    path: 'inventory', loadChildren: () => import('@admin/inventory/inventory.module').then(m => m.InventoryModule)
  }
  // {
  //   path: 'admin', component: AdminLayoutComponent, children: [
  //     { path: '', component: DashboardComponent },
  //     { path: 'statistics', component: StatisticsComponent },
  //   ]
  // },
  // {
  //   path: 'inventory', component: InventoryLayoutComponent, children: [
  //     { path: '', component: InventoryComponent },
  //     { path: 'management-warranties', component: ManagementWarrantiesComponent },
  //     { path: 'management-categories', component: ManagementCategoriesComponent },
  //     { path: 'management-products', component: ManagementProductsComponent },
  //     { path: 'management-discounts', component: ManagementDiscountsComponent },
  //     { path: 'management-users', component: ManagementUsersComponent },
  //     { path: 'management-suppliers', component: ManagementSuppliersComponent }
  //   ]
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule { }

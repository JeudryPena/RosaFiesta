import {ModuleWithProviders} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {InventoryComponent} from "@admin/inventory/inventory.component";
import {
  ManagementWarrantiesComponent
} from "@admin/inventory/containers/management-warranties/management-warranties.component";
import {
  ManagementCategoriesComponent
} from "@admin/inventory/containers/management-categories/management-categories.component";
import {
  ManagementProductsComponent
} from "@admin/inventory/containers/management-products/management-products.component";
import {
  ManagementDiscountsComponent
} from "@admin/inventory/containers/management-discounts/management-discounts.component";
import {ManagementUsersComponent} from "@admin/inventory/containers/management-users/management-users.component";
import {
  ManagementSuppliersComponent
} from "@admin/inventory/containers/management-suppliers/management-suppliers.component";

const routes: Routes = [
  {path: '', component: InventoryComponent},
  {path: 'management-warranties', component: ManagementWarrantiesComponent},
  {path: 'management-categories', component: ManagementCategoriesComponent},
  {path: 'management-products', component: ManagementProductsComponent},
  {path: 'management-discounts', component: ManagementDiscountsComponent},
  {path: 'management-users', component: ManagementUsersComponent},
  {path: 'management-suppliers', component: ManagementSuppliersComponent}
];

export const inventoryRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

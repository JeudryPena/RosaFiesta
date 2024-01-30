import {ModuleWithProviders} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
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
import {AdminGuard} from "@core/guards/admin.guard";
import {AdminProductsGuard} from "@core/guards/admin-products.guard";
import {AdminMarketingGuard} from "@core/guards/admin-marketing.guard";

const routes: Routes = [
  {path: 'management-warranties', component: ManagementWarrantiesComponent, canActivate: [AdminProductsGuard]},
  {path: 'management-categories', component: ManagementCategoriesComponent, canActivate: [AdminProductsGuard]},
  {path: 'management-products', component: ManagementProductsComponent, canActivate: [AdminProductsGuard]},
  {path: 'management-discounts', component: ManagementDiscountsComponent, canActivate: [AdminMarketingGuard]},
  {path: '', component: ManagementUsersComponent, canActivate: [AdminGuard]},
  {path: 'management-suppliers', component: ManagementSuppliersComponent, canActivate: [AdminProductsGuard]}
];

export const inventoryRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

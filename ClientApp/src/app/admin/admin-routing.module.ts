import {ModuleWithProviders} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {InventoryLayoutComponent} from "@core/shared/components/layout/inventory-layout/inventory-layout.component";
import {AdminLayoutComponent} from "@core/shared/components/layout/admin-layout/admin-layout.component";

const dashboardModule = () => import('@admin/dashboard/dashboard.module').then(x => x.DashboardModule);
const inventoryModule = () => import('@admin/inventory/inventory.module').then(x => x.InventoryModule);

const routes: Routes = [
  {
    path: 'dashboard',
    component: AdminLayoutComponent,
    loadChildren: dashboardModule

  },
  {path: 'inventory', loadChildren: inventoryModule, component: InventoryLayoutComponent}
];

export const adminRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

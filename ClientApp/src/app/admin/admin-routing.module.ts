import {ModuleWithProviders} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

// Set up the dashboard module for routing.
const dashboardModule = () => import('@admin/dashboard/dashboard.module').then(x => x.DashboardModule);
// Set up the dashboard module for routing.
const inventoryModule = () => import('@admin/inventory/inventory.module').then(x => x.InventoryModule);

const routes: Routes = [
  {path: '', loadChildren: dashboardModule},
  {path: 'inventory', loadChildren: inventoryModule}
];

export const adminRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

import {ModuleWithProviders} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {DashboardComponent} from "@admin/dashboard/dashboard.component";
import {OrdersComponent} from "@admin/dashboard/containers/orders/orders.component";
import {AnalyticsComponent} from "@admin/dashboard/containers/analytics/analytics.component";
import {AdminsGeneralGuard} from "@core/guards/admins-general.guard";
import {AdminSalesGuard} from "@core/guards/admin-sales.guard";

const routes: Routes = [
  {path: '', component: DashboardComponent, canActivate: [AdminsGeneralGuard]},
  {path: 'analytics', component: AnalyticsComponent, canActivate: [AdminsGeneralGuard]},
  {path: 'orders', component: OrdersComponent, canActivate: [AdminSalesGuard]}
];

export const dashboardRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

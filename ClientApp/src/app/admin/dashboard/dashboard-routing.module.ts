import {ModuleWithProviders} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {DashboardComponent} from "@admin/dashboard/dashboard.component";
import {OrdersComponent} from "@admin/dashboard/containers/orders/orders.component";
import {AnalyticsComponent} from "@admin/dashboard/containers/analytics/analytics.component";

const routes: Routes = [
  {path: '', component: DashboardComponent},
  {path: 'analytics', component: AnalyticsComponent},
  {path: 'orders', component: OrdersComponent}
];

export const dashboardRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

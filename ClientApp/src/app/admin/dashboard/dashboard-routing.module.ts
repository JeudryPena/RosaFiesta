import {ModuleWithProviders} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {StatisticsComponent} from "@admin/dashboard/containers/statistics/statistics.component";
import {DashboardComponent} from "@admin/dashboard/dashboard.component";
import {OrdersComponent} from "@admin/dashboard/containers/orders/orders.component";

const routes: Routes = [
  {path: '', component: DashboardComponent},
  {path: 'statistics', component: StatisticsComponent},
  {path: 'orders', component: OrdersComponent}
];

export const dashboardRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

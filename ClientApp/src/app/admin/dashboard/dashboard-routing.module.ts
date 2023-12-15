import {ModuleWithProviders} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {StatisticsComponent} from "@admin/dashboard/containers/statistics/statistics.component";
import {DashboardComponent} from "@admin/dashboard/dashboard.component";

const routes: Routes = [
  {path: '', component: DashboardComponent},
  {path: 'statistics', component: StatisticsComponent}
];

export const dashboardRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

import {RouterModule, Routes} from '@angular/router';
import {AboutUsComponent} from "@public/home/containers/about-us/about-us.component";
import {ModuleWithProviders} from "@angular/core";
import {HomeComponent} from "@public/home/containers/home/home.component";

const routes: Routes = [
  {path: 'about-us', component: AboutUsComponent},
  {path: 'home', component: HomeComponent}
];

export const mainPageRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

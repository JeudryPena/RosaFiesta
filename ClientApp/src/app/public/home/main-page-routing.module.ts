import {RouterModule, Routes} from '@angular/router';
import {AboutUsComponent} from "@public/home/containers/about-us/about-us.component";
import {ModuleWithProviders} from "@angular/core";
import {HomeComponent} from "@public/home/containers/home/home.component";

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'about-us', component: AboutUsComponent}
];

export const mainPageRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

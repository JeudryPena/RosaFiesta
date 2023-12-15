import {RouterModule, Routes} from '@angular/router';
import {AboutUsComponent} from "@public/home/containers/about-us/about-us.component";
import {HomeComponent} from "@public/home/home.component";
import {ModuleWithProviders} from "@angular/core";

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'about-us', component: AboutUsComponent}
];

export const homeRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

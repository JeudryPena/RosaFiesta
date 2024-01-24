import {RouterModule, Routes} from '@angular/router';
import {AboutUsComponent} from "@public/home/containers/about-us/about-us.component";
import {ModuleWithProviders} from "@angular/core";
import {HomeComponent} from "@public/home/containers/home/home.component";
import {TermsComponent} from "@public/home/containers/terms/terms.component";
import {PrivacyComponent} from "@public/home/containers/privacy/privacy.component";

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'about-us', component: AboutUsComponent},
  {path: 'terms', component: TermsComponent},
  {path: 'privacy', component: PrivacyComponent}
];

export const mainPageRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

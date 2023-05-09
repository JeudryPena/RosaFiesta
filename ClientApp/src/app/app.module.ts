import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app-component/app.component';
import { AuthenticateComponent } from './components/authenticate/authenticate.component';
import { BodyComponent } from './components/body/body.component';
import { CoupensComponent } from './components/coupens/coupens.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MediaComponent } from './components/media/media.component';
import { PagesComponent } from './components/pages/pages.component';
import { ProductsComponent } from './components/products/products.component';
import { SettingsComponent } from './components/settings/settings.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { StatisticsComponent } from './components/statistics/statistics.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthenticateComponent,
    BodyComponent,
    SidenavComponent,
    DashboardComponent,
    ProductsComponent,
    StatisticsComponent,
    CoupensComponent,
    PagesComponent,
    MediaComponent,
    SettingsComponent,
  ],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

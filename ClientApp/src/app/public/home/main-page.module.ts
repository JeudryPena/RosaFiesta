import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
import {HomeComponent} from "@public/home/containers/home/home.component";
import {FeaturesComponent} from "@public/home/components/features/features.component";
import {HeroesComponent} from "@public/home/components/heroes/heroes.component";
import {AboutUsComponent} from "@public/home/containers/about-us/about-us.component";
import {PublicModule} from "@public/public.module";
import {ProductsModule} from "@public/products/products.module";
import {mainPageRouter} from "@public/home/main-page-routing.module";
import {MainPageComponent} from "@public/home/main-page.component";
import {TopMainComponent} from "@public/home/components/top-main/top-main.component";
import {OffersComponent} from "@public/home/components/offers/offers.component";
import {ProductsSourceComponent} from "@public/home/components/products-source/products-source.component";
import {InquiryComponent} from "@public/home/components/inquiry/inquiry.component";

@NgModule({
  declarations: [
    HomeComponent,
    FeaturesComponent,
    HeroesComponent,
    AboutUsComponent,
    MainPageComponent,
    TopMainComponent,
    OffersComponent,
    ProductsSourceComponent,
    InquiryComponent
  ],
  imports: [
    mainPageRouter,
    PublicModule,
    ProductsModule
  ],
  exports: [],
  providers: [],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class MainPageModule {
}

import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
import {HomeComponent} from "@public/home/containers/home/home.component";
import {FeaturesComponent} from "@public/home/components/features/features.component";
import {AboutUsComponent} from "@public/home/containers/about-us/about-us.component";
import {PublicModule} from "@public/public.module";
import {ProductsModule} from "@public/products/products.module";
import {mainPageRouter} from "@public/home/main-page-routing.module";
import {MainPageComponent} from "@public/home/main-page.component";
import {TopMainComponent} from "@public/home/components/top-main/top-main.component";
import {OffersComponent} from "@public/home/components/offers/offers.component";
import {ProductsSourceComponent} from "@public/home/components/products-source/products-source.component";
import {InquiryComponent} from "@public/home/components/inquiry/inquiry.component";
import {ServicesComponent} from "@public/home/components/services/services.component";
import {NewsletterComponent} from "@public/home/components/newsletter/newsletter.component";
import {PrivacyComponent} from "@public/home/containers/privacy/privacy.component";

@NgModule({
  declarations: [
    HomeComponent,
    FeaturesComponent,
    AboutUsComponent,
    MainPageComponent,
    TopMainComponent,
    OffersComponent,
    ProductsSourceComponent,
    InquiryComponent,
    ServicesComponent,
    NewsletterComponent,
    PrivacyComponent
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

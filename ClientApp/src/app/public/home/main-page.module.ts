import {NgModule} from '@angular/core';
import {HomeComponent} from "@public/home/containers/home/home.component";
import {FeaturesComponent} from "@public/home/components/features/features.component";
import {HeroesComponent} from "@public/home/components/heroes/heroes.component";
import {AboutUsComponent} from "@public/home/containers/about-us/about-us.component";
import {PublicModule} from "@public/public.module";
import {CarouselComponent} from "@public/home/components/carousel/carousel.component";
import {ProductsModule} from "@public/products/products.module";
import {mainPageRouter} from "@public/home/main-page-routing.module";
import {MainPageComponent} from "@public/home/main-page.component";

@NgModule({
  declarations: [
    HomeComponent,
    CarouselComponent,
    FeaturesComponent,
    HeroesComponent,
    AboutUsComponent,
    MainPageComponent
  ],
  imports: [
    mainPageRouter,
    PublicModule,
    ProductsModule
  ],
  exports: [],
  providers: []
})
export class MainPageModule {
}

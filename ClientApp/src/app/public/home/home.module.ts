import {NgModule} from '@angular/core';
import {homeRouter} from "@public/home/home-routing.module";
import {HomeComponent} from "@public/home/home.component";
import {CarouselComponent} from "ngx-bootstrap/carousel";
import {FeaturesComponent} from "@public/home/components/features/features.component";
import {HeroesComponent} from "@public/home/components/heroes/heroes.component";
import {AboutUsComponent} from "@public/home/containers/about-us/about-us.component";


@NgModule({
  declarations: [
    HomeComponent,
    CarouselComponent,
    FeaturesComponent,
    HeroesComponent,
    AboutUsComponent
  ],
  imports: [
    homeRouter
  ],
  exports: [],
  providers: [],
  bootstrap: [HomeComponent]
})
export class HomeModule {
}

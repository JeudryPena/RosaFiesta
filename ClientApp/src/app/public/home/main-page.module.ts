import {NgModule} from '@angular/core';
import {homeRouter} from "@public/home/home-routing.module";
import {HomeComponent} from "@public/home/home.component";
import {FeaturesComponent} from "@public/home/components/features/features.component";
import {HeroesComponent} from "@public/home/components/heroes/heroes.component";
import {AboutUsComponent} from "@public/home/containers/about-us/about-us.component";
import {PublicModule} from "@public/public.module";
import {CarouselComponent} from "@public/home/components/carousel/carousel.component";
import {ProductsModule} from "@public/products/products.module";
import { MainPageComponent } from './containers/main-page/main-page.component';


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
        homeRouter,
        PublicModule,
        ProductsModule
    ],
    exports: [],
    providers: []
})
export class HomeModule {
}

import {NgModule} from '@angular/core';
import {productsRouter} from "@public/products/products-routing.module";
import {ProductsComponent} from "@public/products/products.component";
import {CardsComponent} from "@public/products/components/cards/cards.component";
import {ModalQuoteComponent} from "@public/products/components/modal-quote/modal-quote.component";
import {ProductCardComponent} from "@public/products/components/product-card/product-card.component";
import {ProductDetailComponent} from "@public/products/containers/product-detail/product-detail.component";
import {PublicModule} from "@public/public.module";

@NgModule({
  declarations: [
    ProductsComponent,
    CardsComponent,
    ModalQuoteComponent,
    ProductCardComponent,
    ProductDetailComponent
  ],
  imports: [
    productsRouter,
    PublicModule
  ],
  exports: [
    CardsComponent
  ],
  providers: []
})
export class ProductsModule {
}

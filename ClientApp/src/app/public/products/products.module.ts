import {NgModule} from '@angular/core';
import {productsRouter} from "@public/products/products-routing.module";
import {ProductsComponent} from "@public/products/products.component";
import {CardsComponent} from "@public/products/components/cards/cards.component";
import {ModalQuoteComponent} from "@public/products/components/modal-quote/modal-quote.component";
import {ProductCardComponent} from "@public/products/components/product-card/product-card.component";
import {ProductDetailComponent} from "@public/products/containers/product-detail/product-detail.component";
import {PublicModule} from "@public/public.module";
import {FilterNavComponent} from "@public/products/components/filter-nav/filter-nav.component";
import {FilterTagsComponent} from "@public/products/components/filter-tags/filter-tags.component";
import {ProductsBlocksComponent} from "@public/products/components/products-blocks/products-blocks.component";
import {ProductsHeadComponent} from "@public/products/components/products-head/products-head.component";
import {
  ProductsPaginationComponent
} from "@public/products/components/products-pagination/products-pagination.component";

@NgModule({
  declarations: [
    ProductsComponent,
    CardsComponent,
    ModalQuoteComponent,
    ProductCardComponent,
    ProductDetailComponent,
    FilterNavComponent,
    FilterTagsComponent,
    ProductsBlocksComponent,
    ProductsHeadComponent,
    ProductsPaginationComponent
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

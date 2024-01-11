import {NgModule} from '@angular/core';
import {productsRouter} from "@public/products/products-routing.module";
import {ProductsComponent} from "@public/products/products.component";
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
import {DiscountBannerComponent} from "@public/products/components/discount-banner/discount-banner.component";
import {
  ProductDetailsTopComponent
} from "@public/products/components/product-details-top/product-details-top.component";
import {
  ProductDetailsBottomComponent
} from "@public/products/components/product-details-bottom/product-details-bottom.component";
import {DetailsSuggestComponent} from "@public/products/components/details-suggest/details-suggest.component";
import {DetailTabsComponent} from "@public/products/components/detail-tabs/detail-tabs.component";
import {
  DetailDescriptionTabComponent
} from "@public/products/components/detail-tabs/detail-description-tab/detail-description-tab.component";
import {
  DetailReviewTabComponent
} from "@public/products/components/detail-tabs/detail-review-tab/detail-review-tab.component";
import {
  DetailWarrantyTabComponent
} from "@public/products/components/detail-tabs/detail-warranty-tab/detail-warranty-tab.component";

@NgModule({
  declarations: [
    ProductsComponent,
    ModalQuoteComponent,
    ProductCardComponent,
    ProductDetailComponent,
    FilterNavComponent,
    FilterTagsComponent,
    ProductsBlocksComponent,
    ProductsHeadComponent,
    ProductsPaginationComponent,
    DiscountBannerComponent,
    ProductDetailsTopComponent,
    ProductDetailsBottomComponent,
    DetailsSuggestComponent,
    DetailTabsComponent,
    DetailDescriptionTabComponent,
    DetailReviewTabComponent,
    DetailWarrantyTabComponent
  ],
  imports: [
    productsRouter,
    PublicModule
  ],
  exports: [],
  providers: []
})
export class ProductsModule {
}

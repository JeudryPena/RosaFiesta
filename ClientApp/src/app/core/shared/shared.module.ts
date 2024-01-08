import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
import {CommonModule, CurrencyPipe, DatePipe, DecimalPipe, NgOptimizedImage, NgTemplateOutlet} from '@angular/common';
import {ActionDropdownComponent} from "@core/shared/components/action-dropdown/action-dropdown.component";
import {BreadcrumbComponent} from "@core/shared/components/breadcrumb/breadcrumb.component";
import {CheckboxComponent} from "@core/shared/components/checkbox/checkbox.component";
import {CloseButtonComponent} from "@core/shared/components/close-button/close-button.component";
import {DateSelectorComponent} from "@core/shared/components/date-selector/date-selector.component";
import {EnableModalComponent} from "@core/shared/components/enable-modal/enable-modal.component";
import {EnterIconComponent} from "@core/shared/components/enter-icon/enter-icon.component";
import {ExpandedButtonsComponent} from "@core/shared/components/expanded-buttons/expanded-buttons.component";
import {JumbotronComponent} from "@core/shared/components/jumbotron/jumbotron.component";
import {LoadingButtonComponent} from "@core/shared/components/loading-button/loading-button.component";
import {MenuDropdownComponent} from "@core/shared/components/menu-dropdown/menu-dropdown.component";
import {NotificationsComponent} from "@core/shared/components/notifications/notifications.component";
import {PaginationComponent} from "@core/shared/components/pagination/pagination.component";
import {RatingComponent} from "@core/shared/components/rating/rating.component";
import {RoundedButtonsComponent} from "@core/shared/components/rounded-buttons/rounded-buttons.component";
import {SaveModalComponent} from "@core/shared/components/save-modal/save-modal.component";
import {SelectListComponent} from "@core/shared/components/select-list/select-list.component";
import {TimePickerComponent} from "@core/shared/components/time-picker/time-picker.component";
import {FocusDirective} from "@core/shared/directives/focus.directive";
import {IsFocusDirective} from "@core/shared/directives/is-focus.directive";
import {RatingDirective} from "@core/shared/directives/rating.directive";
import {ImgPathPipe} from "@core/shared/pipes/img-path.pipe";
import {TruncatePipe} from "@core/shared/pipes/truncate.pipe";
import {RouterModule} from "@angular/router";
import {AdminLayoutComponent} from "@core/shared/components/layout/admin-layout/admin-layout.component";
import {InventoryLayoutComponent} from "@core/shared/components/layout/inventory-layout/inventory-layout.component";
import {BodyComponent} from "@core/shared/components/layout/body/body.component";
import {SidenavComponent} from "@core/shared/components/layout/sidenav/sidenav.component";
import {FooterComponent} from "@core/shared/components/layout/footer/footer.component";
import {NavbarComponent} from "@core/shared/components/layout/navbar/navbar.component";
import {LayoutComponent} from "@core/shared/components/layout/layout/layout.component";
import {NgbRatingConfig} from "@ng-bootstrap/ng-bootstrap";
import {NgxPayPalModule} from "ngx-paypal";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {NgxStarsModule} from "ngx-stars";
import {NgxChartsModule} from "@swimlane/ngx-charts";
import {NgxFileDropModule} from "ngx-file-drop";
import {CartComponent} from "@core/shared/components/layout/cart/cart.component";
import {AvatarModule} from "ngx-avatars";
import {TestComponent} from "@root/test/test.component";
import {CarouselMultipleComponent} from "@core/shared/components/carousel-multiple/carousel-multiple.component";
import {SwiperDirective} from "@core/shared/directives/swiper.directive";
import {CarouselThumbnailsComponent} from "@core/shared/components/carousel-thumbnails/carousel-thumbnails.component";
import {CarouselComponent} from "@core/shared/components/carousel/carousel.component";
import {
  RecommendProductsComponent
} from "@core/shared/components/products/recommend-products/recommend-products.component";
import {NgBootstrapModule} from "@core/shared/components/bootstrap/ng-bootstrap.module";
import {MaterialModule} from "@core/shared/components/material/material.module";
import {RelatedProductsComponent} from "@core/shared/components/products/related-products/related-products.component";

@NgModule({
  declarations: [
    TestComponent,
    AdminLayoutComponent,
    InventoryLayoutComponent,
    BodyComponent,
    CartComponent,
    SidenavComponent,
    FooterComponent,
    NavbarComponent,
    LayoutComponent,
    ActionDropdownComponent,
    BreadcrumbComponent,
    CheckboxComponent,
    CloseButtonComponent,
    DateSelectorComponent,
    EnableModalComponent,
    EnterIconComponent,
    ExpandedButtonsComponent,
    JumbotronComponent,
    LoadingButtonComponent,
    MenuDropdownComponent,
    NotificationsComponent,
    PaginationComponent,
    RatingComponent,
    RoundedButtonsComponent,
    SaveModalComponent,
    SelectListComponent,
    TimePickerComponent,
    FocusDirective,
    IsFocusDirective,
    RatingDirective,
    ImgPathPipe,
    TruncatePipe,
    CarouselMultipleComponent,
    SwiperDirective,
    CarouselThumbnailsComponent,
    CarouselComponent,
    RecommendProductsComponent,
    RelatedProductsComponent
  ],
  imports: [
    RouterModule,
    CommonModule,
    FormsModule,
    NgBootstrapModule,
    MaterialModule,
    NgxStarsModule,
    NgxChartsModule,
    NgTemplateOutlet,
    NgxFileDropModule,
    NgxPayPalModule,
    NgOptimizedImage,
    CurrencyPipe,
    DatePipe,
    DecimalPipe,
    AvatarModule
  ],
  exports: [
    TestComponent,
    AdminLayoutComponent,
    InventoryLayoutComponent,
    BodyComponent,
    CartComponent,
    SidenavComponent,
    FooterComponent,
    NavbarComponent,
    LayoutComponent,
    ActionDropdownComponent,
    BreadcrumbComponent,
    CheckboxComponent,
    CloseButtonComponent,
    DateSelectorComponent,
    EnableModalComponent,
    EnterIconComponent,
    ExpandedButtonsComponent,
    JumbotronComponent,
    LoadingButtonComponent,
    MenuDropdownComponent,
    NotificationsComponent,
    PaginationComponent,
    RatingComponent,
    RoundedButtonsComponent,
    SaveModalComponent,
    SelectListComponent,
    TimePickerComponent,
    FocusDirective,
    IsFocusDirective,
    RatingDirective,
    ImgPathPipe,
    TruncatePipe,
    CommonModule,
    RouterModule,
    FormsModule,
    MaterialModule,
    ReactiveFormsModule,
    NgBootstrapModule,
    NgxStarsModule,
    NgxChartsModule,
    NgTemplateOutlet,
    NgxFileDropModule,
    NgxPayPalModule,
    CurrencyPipe,
    DatePipe,
    DecimalPipe,
    AvatarModule,
    CarouselMultipleComponent,
    SwiperDirective,
    CarouselThumbnailsComponent,
    CarouselComponent,
    RecommendProductsComponent,
    RelatedProductsComponent
  ],
  providers: [
    NgbRatingConfig

  ],
  bootstrap: [],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class SharedModule {
}

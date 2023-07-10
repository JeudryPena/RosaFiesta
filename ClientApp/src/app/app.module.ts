import { RatingDirective } from './shared/directives/rating.directive';

// Providers


import { CommonModule, DecimalPipe, NgTemplateOutlet } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbDatepickerModule, NgbDropdownModule, NgbModalModule, NgbModule, NgbPaginationModule, NgbRatingConfig, NgbToastModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { TimepickerModule } from 'ngx-bootstrap/timepicker';
import { TypeaheadModule } from 'ngx-bootstrap/typeahead';
import { NgxStarsModule } from 'ngx-stars';
import { AppRoutingModule } from './app-routing.module';
import { NgbdSortableHeader } from './shared/directives/sortable.directive';
import { NgxFileDropModule } from 'ngx-file-drop';
import { TooltipModule } from 'ngx-bootstrap/tooltip';


import { JwtModule } from '@auth0/angular-jwt';
import { NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { AdminLayoutComponent } from './components/admin-layout/admin-layout.component';
import { AlbumComponent } from './components/album/album.component';
import { AppComponent } from './components/app-component/app.component';
import { AuthenticateComponent } from './components/authenticate/authenticate.component';
import { BodyComponent } from './components/body/body.component';
import { CardsComponent } from './components/cards/cards.component';
import { CarouselComponent } from './components/carousel/carousel.component';
import { CartComponent } from './components/cart/cart.component';
import { ChangePasswordComponent } from './components/change-password/change-password.component';
import { CoupensComponent } from './components/coupens/coupens.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { FeaturesComponent } from './components/features/features.component';
import { FinishRegisterComponent } from './components/finish-register/finish-register.component';
import { FooterComponent } from './components/footer/footer.component';
import { ForbiddenComponent } from './components/forbidden/forbidden.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { HeroesComponent } from './components/heroes/heroes.component';
import { HomeComponent } from './components/home/home.component';
import { InventoryLayoutComponent } from './components/inventory-layout/inventory-layout.component';
import { InventoryComponent } from './components/inventory/inventory.component';
import { LayoutComponent } from './components/layout/layout.component';
import { ManagementCategoriesComponent } from './components/management-categories/management-categories.component';
import { ManagementDiscountsComponent } from './components/management-discounts/management-discounts.component';
import { ManagementProductsComponent } from './components/management-products/management-products.component';
import { ManagementServicesComponent } from './components/management-services/management-services.component';
import { ManagementSuppliersComponent } from './components/management-suppliers/management-suppliers.component';
import { ManagementUsersComponent } from './components/management-users/management-users.component';
import { ManagementWarrantiesComponent } from './components/management-warranties/management-warranties.component';
import { MediaComponent } from './components/media/media.component';
import { ModalCategoryComponent } from './components/modal-category/modal-category.component';
import { ModalDiscountComponent } from './components/modal-discount/modal-discount.component';
import { ModalProductComponent } from './components/modal-product/modal-product.component';
import { ModalQuoteComponent } from './components/modal-quote/modal-quote.component';
import { MyOrdersComponent } from './components/my-orders/my-orders.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { NormalizedVerticalBarChartComponent } from './components/normalized-vertical-bar-chart/normalized-vertical-bar-chart.component';
import { PagesComponent } from './components/pages/pages.component';
import { ProductCardComponent } from './components/product-card/product-card.component';
import { ProductDetailComponent } from './components/product-detail/product-detail.component';
import { ProductWishlistComponent } from './components/product-wishlist/product-wishlist.component';
import { ProductsComponent } from './components/products/products.component';
import { PurchaseComponent } from './components/purchase/purchase.component';
import { RegisterComponent } from './components/register/register.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { SettingsComponent } from './components/settings/settings.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { SublevelMenuComponent } from './components/sidenav/sublevel-menu.component';
import { StatisticsComponent } from './components/statistics/statistics.component';
import { UploadImagesComponent } from './components/upload-images/upload-images.component';
import { WishListsComponent } from './components/wish-lists/wish-lists.component';
import { ActionDropdownComponent } from './helpers/action-dropdown/action-dropdown.component';
import { AdvanmcedPieChartComponent } from './helpers/advanmced-pie-chart/advanmced-pie-chart.component';
import { AreaChartComponent } from './helpers/area-chart/area-chart.component';
import { BreadcrumbComponent } from './helpers/breadcrumb/breadcrumb.component';
import { BubleChartComponent } from './helpers/buble-chart/buble-chart.component';
import { CheckboxComponent } from './helpers/checkbox/checkbox.component';
import { CloseButtonComponent } from './helpers/close-button/close-button.component';
import { DateSelectorComponent } from './helpers/date-selector/date-selector.component';
import { EnableModalComponent } from './helpers/enable-modal/enable-modal.component';
import { EnterIconComponent } from './helpers/enter-icon/enter-icon.component';
import { ExpandedButtonsComponent } from './helpers/expanded-buttons/expanded-buttons.component';
import { GaugeChartComponent } from './helpers/gauge-chart/gauge-chart.component';
import { GroupedHorizontalBarComponent } from './helpers/grouped-horizontal-bar/grouped-horizontal-bar.component';
import { HeartChartComponent } from './helpers/heart-chart/heart-chart.component';
import { HorizontalBarChartComponent } from './helpers/horizontal-bar-chart/horizontal-bar-chart.component';
import { JumbotronComponent } from './helpers/jumbotron/jumbotron.component';
import { LineChartComponent } from './helpers/line-chart/line-chart.component';
import { LinearGaugeChartComponent } from './helpers/linear-gauge-chart/linear-gauge-chart.component';
import { LoadingButtonComponent } from './helpers/loading-button/loading-button.component';
import { MenuDropdownComponent } from './helpers/menu-dropdown/menu-dropdown.component';
import { NormalizedAreaChartComponent } from './helpers/normalized-area-chart/normalized-area-chart.component';
import { NotificationsComponent } from './helpers/notifications/notifications.component';
import { NumberCardChartComponent } from './helpers/number-card-chart/number-card-chart.component';
import { PaginationComponent } from './helpers/pagination/pagination.component';
import { PieChartComponent } from './helpers/pie-chart/pie-chart.component';
import { PieGridChartComponent } from './helpers/pie-grid-chart/pie-grid-chart.component';
import { PolarChartComponent } from './helpers/polar-chart/polar-chart.component';
import { RatingComponent } from './helpers/rating/rating.component';
import { RoundedButtonsComponent } from './helpers/rounded-buttons/rounded-buttons.component';
import { SaveModalComponent } from './helpers/save-modal/save-modal.component';
import { SelectListComponent } from './helpers/select-list/select-list.component';
import { StackedAreaChartComponent } from './helpers/stacked-area-chart/stacked-area-chart.component';
import { StackedVerticalBarChartComponent } from './helpers/stacked-vertical-bar-chart/stacked-vertical-bar-chart.component';
import { TimePickerComponent } from './helpers/time-picker/time-picker.component';
import { ToastContainerComponent } from './helpers/toast-container/toast-container.component';
import { ToastGlobalComponent } from './helpers/toast-global/toast-global.component';
import { TreeMapChartComponent } from './helpers/tree-map-chart/tree-map-chart.component';
import { TruncatePipe } from './shared/pipes/truncate.pipe';
import { DownloadComponent } from './components/download/download.component';
import { ModalWarrantyComponent } from './components/modal-warranty/modal-warranty.component';
import { ModalSuppliersComponent } from './components/modal-suppliers/modal-suppliers.component';

export function tokenGetter() {
  return localStorage.getItem("token");
}

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
    NavbarComponent,
    HeroesComponent,
    FeaturesComponent,
    CardsComponent,
    FooterComponent,
    ActionDropdownComponent,
    MenuDropdownComponent,
    DateSelectorComponent,
    SelectListComponent,
    CheckboxComponent,
    NotificationsComponent,
    SaveModalComponent,
    EnableModalComponent,
    BreadcrumbComponent,
    RoundedButtonsComponent,
    ExpandedButtonsComponent,
    EnterIconComponent,
    LoadingButtonComponent,
    CloseButtonComponent,
    JumbotronComponent,
    AlbumComponent,
    PurchaseComponent,
    AboutUsComponent,
    CarouselComponent,
    ManagementProductsComponent,
    MyOrdersComponent,
    ProductDetailComponent,
    RatingComponent,
    RatingDirective,
    PaginationComponent,
    ModalProductComponent,
    RegisterComponent,
    SublevelMenuComponent,
    HomeComponent,
    ModalQuoteComponent,
    ProductCardComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent,
    LayoutComponent,
    ManagementSuppliersComponent,
    ManagementUsersComponent,
    ManagementWarrantiesComponent,
    ManagementCategoriesComponent,
    ManagementDiscountsComponent,
    ManagementServicesComponent,
    CartComponent,
    FinishRegisterComponent,
    ChangePasswordComponent,
    WishListsComponent,
    ProductWishlistComponent,
    ModalCategoryComponent,
    ModalDiscountComponent,
    ForbiddenComponent,
    ToastGlobalComponent,
    ToastContainerComponent,
    BubleChartComponent,
    GaugeChartComponent,
    HeartChartComponent,
    LinearGaugeChartComponent,
    NumberCardChartComponent,
    PolarChartComponent,
    TreeMapChartComponent,
    GroupedHorizontalBarComponent,
    HorizontalBarChartComponent,
    StackedVerticalBarChartComponent,
    AdvanmcedPieChartComponent,
    PieChartComponent,
    PieGridChartComponent,
    NormalizedVerticalBarChartComponent,
    AreaChartComponent,
    LineChartComponent,
    NormalizedAreaChartComponent,
    StackedAreaChartComponent,
    AdminLayoutComponent,
    InventoryLayoutComponent,
    InventoryComponent,
    TruncatePipe,
    TimePickerComponent,
    UploadImagesComponent,
    DownloadComponent,
    ModalWarrantyComponent,
    ModalSuppliersComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FontAwesomeModule,
    FormsModule,
    ReactiveFormsModule,
    NgbDropdownModule,
    NgxStarsModule,
    NgbPaginationModule,
    NgbModule,
    NgbdSortableHeader,
    NgbTypeaheadModule,
    NgbModalModule,
    CommonModule,
    NgbDatepickerModule,
    NgxChartsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:7136"],
        disallowedRoutes: []
      }
    }),
    NgbTooltipModule,
    NgbToastModule,
    NgTemplateOutlet,
    BsDatepickerModule.forRoot(),
    PopoverModule.forRoot(),
    TimepickerModule.forRoot(),
    TypeaheadModule.forRoot(),
    NgxFileDropModule,
    TooltipModule
  ],
  providers: [NgbRatingConfig, DecimalPipe
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
import {config} from './env/config.dev';
import {RatingDirective} from './shared/directives/rating.directive';

// Providers
import {
  FacebookLoginProvider,
  GoogleLoginProvider,
  GoogleSigninButtonModule,
  SocialAuthServiceConfig,
  SocialLoginModule
} from '@abacritt/angularx-social-login';
import {CommonModule, DatePipe, DecimalPipe, NgTemplateOutlet} from '@angular/common';
import {HttpClientModule} from '@angular/common/http';
import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {JwtModule} from '@auth0/angular-jwt';
import {FontAwesomeModule} from '@fortawesome/angular-fontawesome';
import {
  NgbDatepickerModule,
  NgbDropdownModule,
  NgbModalModule,
  NgbModule,
  NgbPaginationModule,
  NgbRatingConfig,
  NgbToastModule,
  NgbTooltipModule,
  NgbTypeaheadModule
} from '@ng-bootstrap/ng-bootstrap';
import {NgxChartsModule} from '@swimlane/ngx-charts';
import {BsDatepickerModule} from 'ngx-bootstrap/datepicker';
import {PopoverModule} from 'ngx-bootstrap/popover';
import {TimepickerModule} from 'ngx-bootstrap/timepicker';
import {TooltipModule} from 'ngx-bootstrap/tooltip';
import {TypeaheadModule} from 'ngx-bootstrap/typeahead';
import {NgxFileDropModule} from 'ngx-file-drop';
import {NgxStarsModule} from 'ngx-stars';
import {AppRoutingModule} from './app-routing.module';
import {NgxPayPalModule} from 'ngx-paypal';

import {NgbdSortableHeader} from './shared/directives/sortable.directive';
import {AvatarModule} from 'ngx-avatar';
import {AboutUsComponent} from './feature/public/about-us/about-us.component';
import {AdminLayoutComponent} from './feature/admin/admin-layout/admin-layout.component';
import {AlbumComponent} from './feature/public/album/album.component';
import {AppComponent} from './app.component';
import {AuthenticateComponent} from './feature/private/authenticate/authenticate.component';
import {BodyComponent} from './layout/body/body.component';
import {CardsComponent} from './feature/public/products/cards/cards.component';
import {CarouselComponent} from './feature/public/carousel/carousel.component';
import {CartComponent} from './feature/private/cart/cart.component';
import {ChangePasswordComponent} from './feature/private/change-password/change-password.component';
import {CoupensComponent} from './feature/public/coupens/coupens.component';
import {DashboardComponent} from './feature/admin/dashboard/dashboard.component';
import {DownloadComponent} from './feature/admin/inventory/products/download/download.component';
import {FeaturesComponent} from './feature/public/home/features/features.component';
import {FinishRegisterComponent} from './feature/public/finish-register/finish-register.component';
import {FooterComponent} from './layout/footer/footer.component';
import {ForbiddenComponent} from './feature/public/forbidden/forbidden.component';
import {ForgotPasswordComponent} from './feature/public/forgot-password/forgot-password.component';
import {HeroesComponent} from './feature/public/home/heroes/heroes.component';
import {HomeComponent} from './feature/public/home/home.component';
import {InventoryLayoutComponent} from './feature/admin/inventory/inventory-layout/inventory-layout.component';
import {InventoryComponent} from './feature/admin/inventory/inventory.component';
import {LayoutComponent} from './feature/public/layout/layout.component';
import {ManagementCategoriesComponent} from './feature/admin/inventory/categories/management-categories/management-categories.component';
import {ManagementDiscountsComponent} from './feature/admin/inventory/discounts/management-discounts/management-discounts.component';
import {ManagementProductsComponent} from './feature/admin/inventory/products/management-products/management-products.component';
import {ManagementSuppliersComponent} from './feature/admin/inventory/suppliers/management-suppliers/management-suppliers.component';
import {ManagementUsersComponent} from './feature/admin/inventory/users/management-users/management-users.component';
import {ManagementWarrantiesComponent} from './feature/admin/inventory/warranties/management-warranties/management-warranties.component';
import {MediaComponent} from './components/media/media.component';
import {ModalCategoryComponent} from './feature/admin/inventory/categories/modal-category/modal-category.component';
import {ModalDiscountComponent} from './feature/admin/inventory/discounts/modal-discount/modal-discount.component';
import {ModalProductComponent} from './feature/admin/inventory/products/modal-product/modal-product.component';
import {ModalQuoteComponent} from './feature/public/modal-quote/modal-quote.component';
import {ModalSuppliersComponent} from './feature/admin/inventory/suppliers/modal-suppliers/modal-suppliers.component';
import {ModalUserComponent} from './feature/admin/inventory/users/modal-user/modal-user.component';
import {ModalWarrantyComponent} from './feature/admin/inventory/warranties/modal-warranty/modal-warranty.component';
import {MyOrdersComponent} from './feature/private/my-orders/my-orders.component';
import {NavbarComponent} from './layout/navbar/navbar.component';
import {
  NormalizedVerticalBarChartComponent
} from './shared/components/normalized-vertical-bar-chart/normalized-vertical-bar-chart.component';
import {PagesComponent} from './components/pages/pages.component';
import {ProductCardComponent} from './feature/public/products/product-card/product-card.component';
import {ProductDetailComponent} from './feature/public/products/product-detail/product-detail.component';
import {ProductWishlistComponent} from './components/product-wishlist/product-wishlist.component';
import {ProductsComponent} from './feature/public/products/products.component';
import {PurchaseComponent} from './feature/private/purchase/purchase.component';
import {RegisterComponent} from './feature/public/register/register.component';
import {ResetPasswordComponent} from './feature/public/reset-password/reset-password.component';
import {SettingsComponent} from './feature/private/settings/settings.component';
import {SidenavComponent} from './layout/sidenav/sidenav.component';
import {StatisticsComponent} from './feature/admin/dashboard/statistics/statistics.component';
import {UploadImagesComponent} from './feature/admin/inventory/products/upload-images/upload-images.component';
import {WishListsComponent} from './feature/private/wish-lists/wish-lists.component';
import {ActionDropdownComponent} from './shared/components/action-dropdown/action-dropdown.component';
import {AdvanmcedPieChartComponent} from './shared/components/advanmced-pie-chart/advanmced-pie-chart.component';
import {AreaChartComponent} from './shared/components/area-chart/area-chart.component';
import {BreadcrumbComponent} from './shared/components/breadcrumb/breadcrumb.component';
import {BubleChartComponent} from './shared/components/buble-chart/buble-chart.component';
import {CheckboxComponent} from './shared/components/checkbox/checkbox.component';
import {CloseButtonComponent} from './shared/components/close-button/close-button.component';
import {DateSelectorComponent} from './shared/components/date-selector/date-selector.component';
import {EnableModalComponent} from './shared/components/enable-modal/enable-modal.component';
import {EnterIconComponent} from './shared/components/enter-icon/enter-icon.component';
import {ExpandedButtonsComponent} from './shared/components/expanded-buttons/expanded-buttons.component';
import {GaugeChartComponent} from './shared/components/gauge-chart/gauge-chart.component';
import {GroupedHorizontalBarComponent} from './shared/components/grouped-horizontal-bar/grouped-horizontal-bar.component';
import {HeartChartComponent} from './shared/components/heart-chart/heart-chart.component';
import {HorizontalBarChartComponent} from './shared/components/horizontal-bar-chart/horizontal-bar-chart.component';
import {JumbotronComponent} from './shared/components/jumbotron/jumbotron.component';
import {LineChartComponent} from './shared/components/line-chart/line-chart.component';
import {LinearGaugeChartComponent} from './shared/components/linear-gauge-chart/linear-gauge-chart.component';
import {LoadingButtonComponent} from './shared/components/loading-button/loading-button.component';
import {MenuDropdownComponent} from './shared/components/menu-dropdown/menu-dropdown.component';
import {NormalizedAreaChartComponent} from './shared/components/normalized-area-chart/normalized-area-chart.component';
import {NotificationsComponent} from './shared/components/notifications/notifications.component';
import {NumberCardChartComponent} from './shared/components/number-card-chart/number-card-chart.component';
import {PaginationComponent} from './shared/components/pagination/pagination.component';
import {PieChartComponent} from './shared/components/pie-chart/pie-chart.component';
import {PieGridChartComponent} from './shared/components/pie-grid-chart/pie-grid-chart.component';
import {PolarChartComponent} from './shared/components/polar-chart/polar-chart.component';
import {RatingComponent} from './shared/components/rating/rating.component';
import {RoundedButtonsComponent} from './shared/components/rounded-buttons/rounded-buttons.component';
import {SaveModalComponent} from './shared/components/save-modal/save-modal.component';
import {SelectListComponent} from './shared/components/select-list/select-list.component';
import {StackedAreaChartComponent} from './shared/components/stacked-area-chart/stacked-area-chart.component';
import {
  StackedVerticalBarChartComponent
} from './shared/components/stacked-vertical-bar-chart/stacked-vertical-bar-chart.component';
import {TimePickerComponent} from './shared/components/time-picker/time-picker.component';
import {ToastContainerComponent} from './shared/components/toast-container/toast-container.component';
import {ToastGlobalComponent} from './shared/components/toast-global/toast-global.component';
import {TreeMapChartComponent} from './shared/components/tree-map-chart/tree-map-chart.component';
import {ImgPathPipe} from './shared/pipes/img-path.pipe';
import {TruncatePipe} from './shared/pipes/truncate.pipe';
import {PayMethodComponent} from './feature/private/pay-method/pay-method.component';
import {AddressesComponent} from './feature/private/addresses/addresses.component';
import {FocusDirective} from './shared/directives/focus.directive';
import {IsFocusDirective} from './shared/directives/is-focus.directive';

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
        ModalSuppliersComponent,
        ModalUserComponent,
        ImgPathPipe,
        PayMethodComponent,
        AddressesComponent,
        FocusDirective,
        IsFocusDirective,

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
        TooltipModule,
        SocialLoginModule,
        GoogleSigninButtonModule,
        AvatarModule,
        NgxPayPalModule,

    ],
    providers: [
        DatePipe,
        NgbRatingConfig,
        DecimalPipe,
        ImgPathPipe,
        {
            provide: 'SocialAuthServiceConfig',
            useValue: {
                autoLogin: false,
                providers: [
                    {
                        id: GoogleLoginProvider.PROVIDER_ID,
                        provider: new GoogleLoginProvider(
                            `${config.googleClientId}`, {
                                scopes: 'email',
                            }
                        )
                    },
                    {
                        id: FacebookLoginProvider.PROVIDER_ID,
                        provider: new FacebookLoginProvider(
                            `${config.facebookClientId}`, {
                                scope: 'email',
                            }
                        )
                    }
                ],
                onError: (err) => {
                    console.error(err);
                }
            } as SocialAuthServiceConfig
        }
    ],
    bootstrap: [AppComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {
}

import { RatingDirective } from './shared/directives/rating.directive';

// Providers


import { HttpClientModule } from '@angular/common/http';
import { CommonModule, DecimalPipe } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbDatepickerModule, NgbDropdownModule, NgbModalModule, NgbModule, NgbPaginationModule, NgbRatingConfig, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { NgxStarsModule } from 'ngx-stars';
import { AppRoutingModule } from './app-routing.module';
import { NgbdSortableHeader } from './shared/directives/sortable.directive';

import { AboutUsComponent } from './components/about-us/about-us.component';
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
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { HeroesComponent } from './components/heroes/heroes.component';
import { HomeComponent } from './components/home/home.component';
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
import { WishListsComponent } from './components/wish-lists/wish-lists.component';
import { ActionDropdownComponent } from './helpers/action-dropdown/action-dropdown.component';
import { BreadcrumbComponent } from './helpers/breadcrumb/breadcrumb.component';
import { CheckboxComponent } from './helpers/checkbox/checkbox.component';
import { CloseButtonComponent } from './helpers/close-button/close-button.component';
import { DateSelectorComponent } from './helpers/date-selector/date-selector.component';
import { EnableModalComponent } from './helpers/enable-modal/enable-modal.component';
import { EnterIconComponent } from './helpers/enter-icon/enter-icon.component';
import { ExpandedButtonsComponent } from './helpers/expanded-buttons/expanded-buttons.component';
import { JumbotronComponent } from './helpers/jumbotron/jumbotron.component';
import { LoadingButtonComponent } from './helpers/loading-button/loading-button.component';
import { MenuDropdownComponent } from './helpers/menu-dropdown/menu-dropdown.component';
import { NotificationsComponent } from './helpers/notifications/notifications.component';
import { PaginationComponent } from './helpers/pagination/pagination.component';
import { RatingComponent } from './helpers/rating/rating.component';
import { RoundedButtonsComponent } from './helpers/rounded-buttons/rounded-buttons.component';
import { SaveModalComponent } from './helpers/save-modal/save-modal.component';
import { SelectListComponent } from './helpers/select-list/select-list.component';


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
    ModalDiscountComponent

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
    HttpClientModule
  ],
  providers: [NgbRatingConfig, DecimalPipe
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
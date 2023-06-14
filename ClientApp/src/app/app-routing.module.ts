import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { AlbumComponent } from './components/album/album.component';
import { AuthenticateComponent } from './components/authenticate/authenticate.component';
import { CarouselComponent } from './components/carousel/carousel.component';
import { CoupensComponent } from './components/coupens/coupens.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { HomeComponent } from './components/home/home.component';
import { LayoutComponent } from './components/layout/layout.component';
import { ManagementProductsComponent } from './components/management-products/management-products.component';
import { MediaComponent } from './components/media/media.component';
import { ModalProductComponent } from './components/modal-product/modal-product.component';
import { ModalQuoteComponent } from './components/modal-quote/modal-quote.component';
import { MyOrdersComponent } from './components/my-orders/my-orders.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { PagesComponent } from './components/pages/pages.component';
import { ProductCardComponent } from './components/product-card/product-card.component';
import { ProductDetailComponent } from './components/product-detail/product-detail.component';
import { ProductsComponent } from './components/products/products.component';
import { PurchaseComponent } from './components/purchase/purchase.component';
import { RegisterComponent } from './components/register/register.component';
import { SettingsComponent } from './components/settings/settings.component';
import { StatisticsComponent } from './components/statistics/statistics.component';
import { ManagementUsersComponent } from './components/management-users/management-users.component';
import { ActionDropdownComponent } from './helpers/action-dropdown/action-dropdown.component';
import { CartComponent } from './components/cart/cart.component';
import { ManagementCategoriesComponent } from './components/management-categories/management-categories.component';
import { ManagementDiscountsComponent } from './components/management-discounts/management-discounts.component';
import { AuthGuard } from './shared/guards/auth.guard';
import { ToastGlobalComponent } from './helpers/toast-global/toast-global.component';
import { AdminLayoutComponent } from './components/admin-layout/admin-layout.component';
import { InventoryLayoutComponent } from './components/inventory-layout/inventory-layout.component';
import { InventoryComponent } from './components/inventory/inventory.component';

const routes: Routes = [
  {
    path: '', component: LayoutComponent, children: [
      { path: '', component: HomeComponent },
      { path: 'products', component: ProductsComponent },
      { path: 'coupens', component: CoupensComponent },
      { path: 'pages', component: PagesComponent },
      { path: 'media', component: MediaComponent },
      { path: 'settings', component: SettingsComponent },
      { path: 'dropdown', component: ActionDropdownComponent },
      { path: 'album', component: AlbumComponent },
      { path: 'purchase', component: PurchaseComponent },
      { path: 'about-us', component: AboutUsComponent },
      { path: 'carousel', component: CarouselComponent },
      { path: 'orders', component: MyOrdersComponent },
      { path: 'product-detail', component: ProductDetailComponent },
      { path: 'product-card', component: ProductCardComponent },
      { path: 'my-orders', component: MyOrdersComponent, canActivate: [AuthGuard] },
      { path: 'cart', component: CartComponent },
      { path: 'toast', component: ToastGlobalComponent },
    ]
  },
  {
    path: 'admin', component: AdminLayoutComponent, children: [
      { path: '', component: DashboardComponent },
      { path: 'statistics', component: StatisticsComponent },
    ]
  },
  {
    path: 'inventory', component: InventoryLayoutComponent, children: [
      { path: '', component: InventoryComponent },
      { path: 'management-categories', component: ManagementCategoriesComponent },
      { path: 'management-products', component: ManagementProductsComponent },
      { path: 'management-discounts', component: ManagementDiscountsComponent },
      { path: 'management-user', component: ManagementUsersComponent },
      { path: 'modal-product', component: ModalProductComponent },
      { path: 'modal-quote', component: ModalQuoteComponent },
      { path: 'modal-categories', component: ManagementCategoriesComponent}
    ]
  },
  { path: 'register', component: RegisterComponent },
  { path: 'authenticate', component: AuthenticateComponent },
  { path: 'forgot-password', component: ForgotPasswordComponent },
  { path: 'navbar', component: NavbarComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }

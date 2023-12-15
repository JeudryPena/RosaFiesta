import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsComponent } from './feature/public/about-us/about-us.component';
import { AdminLayoutComponent } from './feature/admin/admin-layout/admin-layout.component';
import { AlbumComponent } from './feature/public/album/album.component';
import { AuthenticateComponent } from './feature/private/authenticate/authenticate.component';
import { CarouselComponent } from './feature/public/carousel/carousel.component';
import { CartComponent } from './feature/private/cart/cart.component';
import { CoupensComponent } from './feature/public/coupens/coupens.component';
import { DashboardComponent } from './feature/admin/dashboard/dashboard.component';
import { ForgotPasswordComponent } from './feature/public/forgot-password/forgot-password.component';
import { HomeComponent } from './feature/public/home/home.component';
import { InventoryLayoutComponent } from './feature/admin/inventory/inventory-layout/inventory-layout.component';
import { InventoryComponent } from './feature/admin/inventory/inventory.component';
import { LayoutComponent } from './feature/public/layout/layout.component';
import { ManagementCategoriesComponent } from './feature/admin/inventory/categories/management-categories/management-categories.component';
import { ManagementDiscountsComponent } from './feature/admin/inventory/discounts/management-discounts/management-discounts.component';
import { ManagementProductsComponent } from './feature/admin/inventory/products/management-products/management-products.component';
import { ManagementSuppliersComponent } from './feature/admin/inventory/suppliers/management-suppliers/management-suppliers.component';
import { ManagementUsersComponent } from './feature/admin/inventory/users/management-users/management-users.component';
import { ManagementWarrantiesComponent } from './feature/admin/inventory/warranties/management-warranties/management-warranties.component';
import { MediaComponent } from './components/media/media.component';
import { MyOrdersComponent } from './feature/private/my-orders/my-orders.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { PagesComponent } from './components/pages/pages.component';
import { ProductCardComponent } from './feature/public/products/product-card/product-card.component';
import { ProductDetailComponent } from './feature/public/products/product-detail/product-detail.component';
import { ProductsComponent } from './feature/public/products/products.component';
import { PurchaseComponent } from './feature/private/purchase/purchase.component';
import { RegisterComponent } from './feature/public/register/register.component';
import { ResetPasswordComponent } from './feature/public/reset-password/reset-password.component';
import { SettingsComponent } from './feature/private/settings/settings.component';
import { StatisticsComponent } from './feature/admin/dashboard/statistics/statistics.component';
import { WishListsComponent } from './feature/private/wish-lists/wish-lists.component';
import { ActionDropdownComponent } from './shared/components/action-dropdown/action-dropdown.component';
import { ToastGlobalComponent } from './shared/components/toast-global/toast-global.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  {
    path: '', component: LayoutComponent, children: [
      { path: '', component: HomeComponent },
      { path: 'products', component: ProductsComponent },
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
      { path: 'wishlist', component: WishListsComponent },
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
      { path: 'management-warranties', component: ManagementWarrantiesComponent },
      { path: 'management-categories', component: ManagementCategoriesComponent },
      { path: 'management-products', component: ManagementProductsComponent },
      { path: 'management-discounts', component: ManagementDiscountsComponent },
      { path: 'management-users', component: ManagementUsersComponent },
      { path: 'management-suppliers', component: ManagementSuppliersComponent }
    ]
  },
  { path: 'register', component: RegisterComponent },
  { path: 'authenticate', component: AuthenticateComponent },
  { path: 'forgot-password', component: ForgotPasswordComponent },
  { path: 'reset-password', component: ResetPasswordComponent },
  { path: 'navbar', component: NavbarComponent },
  { path: 'coupens', component: CoupensComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }

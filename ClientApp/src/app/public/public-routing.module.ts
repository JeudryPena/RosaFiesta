import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsComponent } from '../public/about-us/about-us.component';
import { AdminLayoutComponent } from './layout/admin-layout/admin-layout.component';
import { AlbumComponent } from '../public/album/album.component';
import { AuthenticateComponent } from '../auth/authenticate/authenticate.component';
import { CarouselComponent } from '../public/home/carousel/carousel.component';
import { CartComponent } from '../privy/cart/cart.component';
import { CoupensComponent } from '../public/coupens/coupens.component';
import { DashboardComponent } from '../admin/dashboard/dashboard.component';
import { ForgotPasswordComponent } from '../auth/forgot-password/forgot-password.component';
import { HomeComponent } from '../public/home/home.component';
import { InventoryLayoutComponent } from './layout/inventory-layout/inventory-layout.component';
import { InventoryComponent } from '../admin/inventory/inventory.component';
import { LayoutComponent } from './layout/layout/layout.component';
import { ManagementCategoriesComponent } from '../admin/inventory/pages/management-categories/management-categories.component';
import { ManagementDiscountsComponent } from '../admin/inventory/pages/management-discounts/management-discounts.component';
import { ManagementProductsComponent } from '../admin/inventory/pages/management-products/management-products.component';
import { ManagementSuppliersComponent } from '../admin/inventory/pages/management-suppliers/management-suppliers.component';
import { ManagementUsersComponent } from '../admin/inventory/pages/management-users/management-users.component';
import { ManagementWarrantiesComponent } from '../admin/inventory/warranties/management-warranties/management-warranties.component';
import { MediaComponent } from './components/media/media.component';
import { MyOrdersComponent } from '../privy/my-orders/my-orders.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { PagesComponent } from './components/pages/pages.component';
import { ProductCardComponent } from '../public/products/product-card/product-card.component';
import { ProductDetailComponent } from '../public/products/product-detail/product-detail.component';
import { ProductsComponent } from '../public/products/products.component';
import { PurchaseComponent } from '../privy/purchase/purchase.component';
import { RegisterComponent } from '../auth/register/register.component';
import { ResetPasswordComponent } from '../auth/reset-password/reset-password.component';
import { SettingsComponent } from '../privy/settings/settings.component';
import { StatisticsComponent } from '../admin/dashboard/statistics/statistics.component';
import { WishListsComponent } from '../privy/wish-lists/wish-lists.component';
import { ActionDropdownComponent } from '../shared/components/action-dropdown/action-dropdown.component';
import { ToastGlobalComponent } from '../shared/components/toast-global/toast-global.component';
import { AuthGuard } from '../core/guards/auth.guard';

const routes: Routes = [
  {
    path: 'auth', loadChildren: () => import('@auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: '', loadChildren: () => import('@public/public.module').then(m => m.PublicModule)
  },
  {
    path: 'privy', loadChildren: () => import('@privy/privy.module').then(m => m.PrivyModule)
  },
  {
    path: 'admin', loadChildren: () => import('@admin/admin.module').then(m => m.AdminModule)
  },
  {
    path: 'shared', loadChildren: () => import('@shared/shared.module').then(m => m.SharedModule)
  },
  // {
  //   path: '', component: LayoutComponent, children: [
  //     { path: '', component: HomeComponent },
  //     { path: 'products', component: ProductsComponent },
  //     { path: 'pages', component: PagesComponent },
  //     { path: 'media', component: MediaComponent },
  //     { path: 'settings', component: SettingsComponent },
  //     { path: 'dropdown', component: ActionDropdownComponent },
  //     { path: 'album', component: AlbumComponent },
  //     { path: 'purchase', component: PurchaseComponent },
  //     { path: 'about-us', component: AboutUsComponent },
  //     { path: 'carousel', component: CarouselComponent },
  //     { path: 'orders', component: MyOrdersComponent },
  //     { path: 'product-detail', component: ProductDetailComponent },
  //     { path: 'product-card', component: ProductCardComponent },
  //     { path: 'my-orders', component: MyOrdersComponent, canActivate: [AuthGuard] },
  //     { path: 'cart', component: CartComponent },
  //     { path: 'toast', component: ToastGlobalComponent },
  //     { path: 'wishlist', component: WishListsComponent },
  //   ]
  // },
  // {
  //   path: 'admin', component: AdminLayoutComponent, children: [
  //     { path: '', component: DashboardComponent },
  //     { path: 'statistics', component: StatisticsComponent },
  //   ]
  // },
  // {
  //   path: 'inventory', component: InventoryLayoutComponent, children: [
  //     { path: '', component: InventoryComponent },
  //     { path: 'management-warranties', component: ManagementWarrantiesComponent },
  //     { path: 'management-categories', component: ManagementCategoriesComponent },
  //     { path: 'management-products', component: ManagementProductsComponent },
  //     { path: 'management-discounts', component: ManagementDiscountsComponent },
  //     { path: 'management-users', component: ManagementUsersComponent },
  //     { path: 'management-suppliers', component: ManagementSuppliersComponent }
  //   ]
  // },
  // { path: 'register', component: RegisterComponent },
  // { path: 'authenticate', component: AuthenticateComponent },
  // { path: 'forgot-password', component: ForgotPasswordComponent },
  // { path: 'reset-password', component: ResetPasswordComponent },
  // { path: 'navbar', component: NavbarComponent },
  // { path: 'coupens', component: CoupensComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }

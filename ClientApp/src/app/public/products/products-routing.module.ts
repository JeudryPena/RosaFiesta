import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {LayoutComponent} from "@root/layout/layout/layout.component";
import {AboutUsComponent} from "@public/home/about-us/about-us.component";

const routes: Routes = [
  {
    path: '', component: LayoutComponent, children: [
      {
        path: '', loadChildren: () => import('@public/home/home.module').then(m => m.HomeModule)
      },
      {
        path: 'products', loadChildren: () => import('@public/products/products.module').then(m => m.ProductsModule)
      },
      { path: 'about-us', component: AboutUsComponent },
    ]
  }
  //     { path: 'pages', component: PagesComponent },
  //     { path: 'media', component: MediaComponent },
  //     { path: 'settings', component: SettingsComponent },
  //     { path: 'dropdown', component: ActionDropdownComponent },
  //     { path: 'album', component: AlbumComponent },
  //     { path: 'purchase', component: PurchaseComponent },
  //     { path: 'carousel', component: CarouselComponent },
  //     { path: 'orders', component: MyOrdersComponent },
  //     { path: 'product-detail', component: ProductDetailComponent },
  //     { path: 'product-card', component: ProductCardComponent },
  //     { path: 'my-orders', component: MyOrdersComponent, canActivate: [AuthGuard] },
  //     { path: 'cart', component: CartComponent },
  //     { path: 'toast', component: ToastGlobalComponent },
  //     { path: 'wishlist', component: WishListsComponent },
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
  // { path: 'navbar', component: NavbarComponent },
  // { path: 'coupens', component: CoupensComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class PublicRoutingModule { }

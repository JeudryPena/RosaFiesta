import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { AlbumComponent } from './components/album/album.component';
import { AuthenticateComponent } from './components/authenticate/authenticate.component';
import { BodyComponent } from './components/body/body.component';
import { CarouselComponent } from './components/carousel/carousel.component';
import { CoupensComponent } from './components/coupens/coupens.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ManagmentProductsComponent } from './components/managment-products/managment-products.component';
import { MediaComponent } from './components/media/media.component';
import { MyOrdersComponent } from './components/my-orders/my-orders.component';
import { PagesComponent } from './components/pages/pages.component';
import { ProductDetailComponent } from './components/product-detail/product-detail.component';
import { ProductsComponent } from './components/products/products.component';
import { PurchaseComponent } from './components/purchase/purchase.component';
import { SettingsComponent } from './components/settings/settings.component';
import { StatisticsComponent } from './components/statistics/statistics.component';
import { UserManagmentComponent } from './components/user-managment/user-managment.component';
import { ActionDropdownComponent } from './helpers/action-dropdown/action-dropdown.component';
import { HomeComponent } from './components/home/home.component';
import { ModalProductComponent } from './components/modal-product/modal-product.component';
import { ModalQuoteComponent } from './components/modal-quote/modal-quote.component';
import { ProductCardComponent } from './components/product-card/product-card.component';
import { RegisterComponent } from './components/register/register.component';

const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'statistics', component: StatisticsComponent },
  { path: 'register', component: RegisterComponent},
  { path: 'authenticate', component: AuthenticateComponent },
  { path: 'coupens', component: CoupensComponent },
  { path: 'pages', component: PagesComponent },
  { path: 'media', component: MediaComponent },
  { path: 'settings', component: SettingsComponent },
  { path: 'dropdown', component: ActionDropdownComponent },
  { path: 'home', component: HomeComponent },
  { path: 'album', component: AlbumComponent },
  { path: 'purchase', component: PurchaseComponent },
  { path: 'about-us', component: AboutUsComponent },
  { path: 'carousel', component: CarouselComponent },
  { path: 'products-managment', component: ManagmentProductsComponent },
  { path: 'orders', component: MyOrdersComponent },
  { path: 'product-detail', component: ProductDetailComponent },
  { path: 'coupens', component: CoupensComponent },
  { path: 'user-managment', component: UserManagmentComponent },
  { path: 'modal-product', component: ModalProductComponent },
  { path: 'modal-quote', component: ModalQuoteComponent },
  { path: 'product-card', component: ProductCardComponent },
  { path: 'my-orders', component: MyOrdersComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

import {ModuleWithProviders} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ProductsComponent} from "@public/products/products.component";
import {ProductDetailComponent} from "@public/products/containers/product-detail/product-detail.component";

const routes: Routes = [
  {path: '', component: ProductsComponent},
  {path: 'product-detail', component: ProductDetailComponent}
];

export const productsRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

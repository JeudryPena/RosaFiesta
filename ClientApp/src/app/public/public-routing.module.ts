import {ModuleWithProviders} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from "@core/shared/components/layout/layout/layout.component";

const mainPageModule = () => import('@public/home/main-page.module').then(x => x.MainPageModule);
const productsModule = () => import('@public/products/products.module').then(x => x.ProductsModule);


const routes: Routes = [
  {path: 'products', loadChildren: productsModule, component: LayoutComponent},
  {path: 'main-page', loadChildren: mainPageModule, component: LayoutComponent},
];

export const publicRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

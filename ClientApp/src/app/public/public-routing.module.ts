import {ModuleWithProviders} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from "@core/shared/components/layout/layout/layout.component";
import {AboutUsComponent} from "@public/home/containers/about-us/about-us.component";

const routes: Routes = [
  {
    path: '', component: LayoutComponent, children: [
      {
        path: '', loadChildren: () => import('@public/home/home.module').then(m => m.HomeModule)
      },
      {
        path: 'products', loadChildren: () => import('@public/products/products.module').then(m => m.ProductsModule)
      },
      {path: 'about-us', component: AboutUsComponent},
    ]
  }
];

export const publicRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

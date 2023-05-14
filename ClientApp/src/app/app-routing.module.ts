import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticateComponent } from './components/authenticate/authenticate.component';
import { ProductsComponent } from './components/products/products.component';

const routes: Routes = [
  {
    path: '**',
    redirectTo: 'home',
    pathMatch: 'full',
  },
  { path: 'authenticate', component: AuthenticateComponent },
  { path: 'products', component: ProductsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

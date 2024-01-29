import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from "@core/shared/components/layout/layout/layout.component";
import {AuthGuard} from "@core/guards/auth.guard";

const adminModule = () => import('@admin/admin.module').then(x => x.AdminModule);
const authModule = () => import('@auth/auth.module').then(x => x.AuthModule);
const publicModule = () => import('@public/public.module').then(x => x.PublicModule);
const intranetModule = () => import('@intranet/intranet.module').then(x => x.IntranetModule);
const sharedModule = () => import('@core/shared/shared.module').then(x => x.SharedModule);

const routes: Routes = [
  {
    path: '',
    redirectTo: 'main-page',
    pathMatch: 'full'
  },
  {path: '', loadChildren: publicModule},
  {path: 'admin', loadChildren: adminModule, canActivate: [AuthGuard]},
  {path: 'auth', loadChildren: authModule},
  {path: 'intranet', loadChildren: intranetModule, component: LayoutComponent, canActivate: [AuthGuard]},
  {path: '**', redirectTo: 'main-page'}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {
}

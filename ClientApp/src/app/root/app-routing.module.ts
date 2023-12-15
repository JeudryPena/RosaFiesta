import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

const adminModule = () => import('@admin/admin.module').then(x => x.AdminModule);
const authModule = () => import('@auth/auth.module').then(x => x.AuthModule);
const publicModule = () => import('@public/public.module').then(x => x.PublicModule);
const intranetModule = () => import('../intranet/intranet.module').then(x => x.IntranetModule);
const sharedModule = () => import('@core/shared/shared.module').then(x => x.SharedModule);

const routes: Routes = [
  {
    path: '',
    redirectTo: '',
    pathMatch: 'full',
  },
  {
    path: '',
    children: [
      {path: 'admin', loadChildren: adminModule},
      {path: 'auth', loadChildren: authModule},
      {path: '', loadChildren: publicModule},
      {path: 'privy', loadChildren: intranetModule},
      {path: 'shared', loadChildren: sharedModule}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}

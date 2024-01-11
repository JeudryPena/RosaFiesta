import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {TestComponent} from "@root/test/test.component";

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
  {path: 'admin', loadChildren: adminModule},
  {path: 'auth', loadChildren: authModule},
  {path: 'intranet', loadChildren: intranetModule},
  {path: 'shared', loadChildren: sharedModule},
  {path: 'test', component: TestComponent},
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

import {ModuleWithProviders} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ResetPasswordComponent} from "@auth/containers/reset-password/reset-password.component";
import {ForgotPasswordComponent} from "@auth/containers/forgot-password/forgot-password.component";
import {RegisterComponent} from "@auth/containers/register/register.component";
import {AuthenticateComponent} from "@auth/containers/authenticate/authenticate.component";

const routes: Routes = [
  {path: 'register', component: RegisterComponent},
  {path: '', component: AuthenticateComponent},
  {path: 'forgot-password', component: ForgotPasswordComponent},
  {path: 'reset-password', component: ResetPasswordComponent}
];

export const authRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

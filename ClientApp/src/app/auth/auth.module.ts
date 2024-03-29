import {NgModule} from '@angular/core';
import {AuthenticateComponent} from "@auth/containers/authenticate/authenticate.component";
import {ReactiveFormsModule} from "@angular/forms";
import {ChangePasswordComponent} from "@auth/containers/change-password/change-password.component";
import {FinishRegisterComponent} from "@auth/containers/finish-register/finish-register.component";
import {ForgotPasswordComponent} from "@auth/containers/forgot-password/forgot-password.component";
import {RegisterComponent} from "@auth/containers/register/register.component";
import {ResetPasswordComponent} from "@auth/containers/reset-password/reset-password.component";
import {authRouter} from "@auth/auth-routing.module";
import {AuthComponent} from './auth.component';
import {SharedModule} from "@core/shared/shared.module";
import {GoogleSigninButtonModule} from "@abacritt/angularx-social-login";

@NgModule({
    declarations: [
        AuthComponent,
        AuthenticateComponent,
        ChangePasswordComponent,
        FinishRegisterComponent,
        ForgotPasswordComponent,
        RegisterComponent,
        ResetPasswordComponent,
    ],
    imports: [
        authRouter,
        SharedModule,
        ReactiveFormsModule,
        GoogleSigninButtonModule,
    ],
    exports: [],
    providers: []
})
export class AuthModule {
}

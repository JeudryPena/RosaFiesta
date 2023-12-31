import {HttpClientModule} from '@angular/common/http';
import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {ForbiddenComponent} from './forbidden/forbidden.component';
import {CommonModule, DecimalPipe} from "@angular/common";
import {JwtModule} from "@auth0/angular-jwt";
import {
  FacebookLoginProvider,
  GoogleLoginProvider,
  SocialAuthServiceConfig,
  SocialLoginModule
} from "@abacritt/angularx-social-login";
import {config} from "@env/config.dev";
import {ToastContainerComponent} from "@root/toast-container/toast-container.component";
import {NgbToastModule} from "@ng-bootstrap/ng-bootstrap";
import {RouterModule} from "@angular/router";

export function tokenGetter() {
  return localStorage.getItem("token");
}

@NgModule({
  declarations: [
    AppComponent,
    ForbiddenComponent,
    ToastContainerComponent,
  ],
  imports: [
    DecimalPipe,
    NgbToastModule,
    RouterModule,
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    SocialLoginModule,
    JwtModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:7136"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [
    DecimalPipe,
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              `${config.googleClientId}`, {
                scopes: 'email',
              }
            )
          },
          {
            id: FacebookLoginProvider.PROVIDER_ID,
            provider: new FacebookLoginProvider(
              `${config.facebookClientId}`, {
                scope: 'email',
              }
            )
          }
        ],
        onError: (err) => {
          console.error(err);
        }
      } as SocialAuthServiceConfig
    }
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {
}

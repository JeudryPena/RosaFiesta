import { FacebookLoginProvider, GoogleLoginProvider, SocialAuthService, SocialUser } from "@abacritt/angularx-social-login";
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subject } from 'rxjs';
import { config } from '@env/config';
import { LoginResponse } from '../../core/interfaces/Security/Response/loginResponse';
import { ExternalAuthDto } from '../../core/interfaces/Security/external-auth-dto';
import { LogingDto } from '../../core/interfaces/Security/logingDto';
import { RegisterDto } from '../../core/interfaces/Security/registerDto';
import { ResetPasswordDto } from '../../core/interfaces/Security/resetPasswordDto';
import { CustomEncoder } from '../../core/classes/custom-encoder';

@Injectable({
  providedIn: 'root'
})
export class AuthenticateService {
  public isExternalAuth: boolean;
  private apiUrl = `${config.apiURL}authenticate/`
  private authChangeSub = new Subject<boolean>()
  public authChanged = this.authChangeSub.asObservable();
  private extAuthChangeSub = new Subject<SocialUser>();
  public extAuthChanged = this.extAuthChangeSub.asObservable();

  constructor(
    private http: HttpClient,
    private jwtHelper: JwtHelperService,
    private externalAuthService: SocialAuthService,
    private router: Router
  ) {
    this.externalAuthService.authState.subscribe((user) => {
      this.externalLogin();
      this.extAuthChangeSub.next(user);
      this.isExternalAuth = true;
    })
  }

  currentUser() {
    return this.http.get(`${this.apiUrl}currentUser`);
  }

  externalLogin = () => {


    this.extAuthChanged.subscribe(user => {
      const externalAuth: ExternalAuthDto = {
        provider: user.provider,
        idToken: user.idToken
      }
      this.validateExternalAuth(externalAuth);
    })
  }

  public externalLoginx = (body: ExternalAuthDto) => {
    return this.http.post<LoginResponse>(`${this.apiUrl}external`, body);
  }

  public signInWithGoogle = () => {
    this.externalAuthService.signIn(GoogleLoginProvider.PROVIDER_ID);
  }

  public signInWithFacebook = () => {
    this.externalAuthService.signIn(FacebookLoginProvider.PROVIDER_ID);
  }

  public signOutExternal = () => {
    this.externalAuthService.signOut();
  }

  register = (body: RegisterDto) => {
    return this.http.post(`${this.apiUrl}register`, body);
  }

  confirmEmail(token: string, email: string) {
    let params = new HttpParams({ encoder: new CustomEncoder() })
    params = params.append('token', token);
    params = params.append('email', email);
    return this.http.get(`${this.apiUrl}confirm-email`, { params });
  }

  resetPassword(reset: ResetPasswordDto, token: string, email: string) {
    let params = new HttpParams({ encoder: new CustomEncoder() })
    params = params.append('token', token);
    params = params.append('email', email);
    return this.http.post(`${this.apiUrl}reset-password`, reset, { params });
  }

  forgotPassword(email: string) {
    return this.http.get(`${this.apiUrl}forgot-password/${email}`);
  }

  login = (body: LogingDto) => {
    return this.http.post<LoginResponse>(`${this.apiUrl}login`, body);
  }

  sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this.authChangeSub.next(isAuthenticated);
  }

  public isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("token");
    return Boolean(token && !this.jwtHelper.isTokenExpired(token))
  }

  public isUserAdmin = (): boolean => {
    const token = localStorage.getItem("token");
    const decodedToken = this.jwtHelper.decodeToken(token!);
    const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    return role === 'Admin';
  }

  public logout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("refreshToken");
    this.sendAuthStateChangeNotification(false);
  }

  private validateExternalAuth(externalAuth: ExternalAuthDto) {
    this.externalLoginx(externalAuth)
      .subscribe({
        next: (res) => {
          localStorage.setItem("token", res.token);
          this.sendAuthStateChangeNotification(res.isAuthSuccessful);
          if (this.router.url === '/')
            window.location.reload();
          else
            this.router.navigate(['']);
        },
        error: (err: any) => {
          this.signOutExternal();
        }
      });
  }
}

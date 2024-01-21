import {
  FacebookLoginProvider,
  GoogleLoginProvider,
  SocialAuthService,
  SocialUser
} from "@abacritt/angularx-social-login";
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Router} from '@angular/router';
import {JwtHelperService} from '@auth0/angular-jwt';
import {Observable, Subject} from 'rxjs';
import {config} from "@env/config.dev";
import {ExternalAuthDto} from "@core/interfaces/Security/external-auth-dto";
import {LoginResponse} from "@core/interfaces/Security/Response/loginResponse";
import {RegisterDto} from "@core/interfaces/Security/registerDto";
import {CustomEncoder} from "@core/classes/custom-encoder";
import {ResetPasswordDto} from "@core/interfaces/Security/resetPasswordDto";
import {LogingDto} from "@core/interfaces/Security/logingDto";
import {CurrentUserResponse, UserResponse} from "@core/interfaces/Security/Response/userResponse";
import {ChangePasswordDto} from "@core/interfaces/Security/changePasswordDto";

@Injectable({
  providedIn: 'root'
})
export class AuthenticateService {
  public isExternalAuth: boolean;
  private apiUrl = `${config.apiURL}authenticate/`
  private authChangeSub = new Subject<boolean>()
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

  deleteMyAccount() {
    return this.http.delete(`${this.apiUrl}delete-user`);
  }

  paypalTest(id: string) {
    return this.http.get(`https://api-m.sandbox.paypal.com/v2/checkout/orders/${id}`);
  }

  changePromotionalPreference() {
    return this.http.get(`${this.apiUrl}change-promotional-emails`);
  }

  changePassword(changeDto: ChangePasswordDto) {
    return this.http.put(`${this.apiUrl}change-password`, changeDto);
  }

  getCurrentDetailUser(): Observable<UserResponse> {
    return this.http.get<UserResponse>(`${this.apiUrl}get-current-user`);
  }

  currentUser(): CurrentUserResponse {
    const token = localStorage.getItem("token");
    const decodedToken = this.jwtHelper.decodeToken(token!);
    const user: CurrentUserResponse = {
      id: decodedToken.nameid,
      userName: decodedToken.unique_name,
      role: decodedToken.role
    }
    return user;
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
    let params = new HttpParams({encoder: new CustomEncoder()})
    params = params.append('token', token);
    params = params.append('email', email);
    return this.http.get(`${this.apiUrl}confirm-email`, {params});
  }

  resetPassword(reset: ResetPasswordDto, token: string, email: string) {
    let params = new HttpParams({encoder: new CustomEncoder()})
    params = params.append('token', token);
    params = params.append('email', email);
    return this.http.post(`${this.apiUrl}reset-password`, reset, {params});
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
    this.router.navigate(['/']).then(() => {
      window.location.reload();
    });
  }

  public generatePaypalToken() {
    const url = 'https://api-m.sandbox.paypal.com/v1/oauth2/token';
    const headers = new HttpHeaders({
      'Authorization': 'Basic ' + btoa(`${config.payPalClientId}:${config.payPalSecret}`),
      'Content-Type': 'application/x-www-form-urlencoded'
    });
    const body = 'grant_type=client_credentials';
    return this.http.post<any>(url, body, {headers});
  }

  orderDetails(accessToken: string, orderId: string) {
    const url = `https://api-m.sandbox.paypal.com/v2/checkout/orders/${orderId}`;
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${accessToken}`
    });
    this.http.get<any>(url, {headers})
      .subscribe(response => {
        console.log(response);
      }, error => {
        console.error(error);
      });
  }

  transactionCaptures(transactionId: string) {
    // this.http.get<any>(url, {headers})
    //   .subscribe(response => {
    //     console.log(response);
    //   }, error => {
    //     console.error(error);
    //   });
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
          console.error(err);
          this.signOutExternal();
        }
      });
  }
}

import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subject } from 'rxjs';
import { config } from '../../env/config.dev';
import { LoginResponse } from '../../interfaces/Security/Response/loginResponse';
import { LogingDto } from '../../interfaces/Security/logingDto';
import { RegisterDto } from '../../interfaces/Security/registerDto';
import { CustomEncoder } from '../custom-encoder';
import { ResetPasswordDto } from '../../interfaces/Security/resetPasswordDto';

@Injectable({
  providedIn: 'root'
})
export class AuthenticateService {
  private apiUrl = `${config.apiURL}authenticate/`
  private authChangeSub = new Subject<boolean>()
  public authChanged = this.authChangeSub.asObservable();

  constructor(
    private http: HttpClient,
    private jwtHelper: JwtHelperService
  ) { }

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
}

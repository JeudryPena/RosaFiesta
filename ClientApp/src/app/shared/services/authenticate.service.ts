import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subject } from 'rxjs';
import { config } from '../../env/config.dev';
import { LoginResponse } from '../../interfaces/Security/Response/loginResponse';
import { LogingDto } from '../../interfaces/Security/logingDto';
import { RegisterResponse } from '../../interfaces/Security/Response/registerResponse';
import { RegisterDto } from '../../interfaces/Security/registerDto';

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

  public register = (body: RegisterDto) => {
    return this.http.post(`${this.apiUrl}preRegister`, body);
  }

  public login = (body: LogingDto) => {
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

import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Injectable} from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import {LoginResponse} from '../interfaces/Security/Response/loginResponse';
import {AuthenticateService} from '@auth/services/authenticate.service';
import {config} from '@env/config.dev';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard  {

    apiUrl = config.apiURL;

    constructor(private authService: AuthenticateService, private router: Router, private http: HttpClient) {
    }

    async canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        const token = localStorage.getItem("token") || '{}';
        if (this.authService.isUserAuthenticated()) {
            return true;
        }

        const isRefreshSuccess = await this.tryRefreshingTokens(token);
        if (!isRefreshSuccess) {
            this.router.navigate([''], {queryParams: {returnUrl: state.url}});
        }
        return isRefreshSuccess;
    }

    private async tryRefreshingTokens(token: string): Promise<boolean> {
        const refreshToken: string = localStorage.getItem("refreshToken") || '{}';
        if (!token || !refreshToken) {
            return false;
        }

        const credentials = JSON.stringify({accessToken: token, refreshToken: refreshToken});
        let isRefreshSuccess: boolean;
        const refreshRes = await new Promise<LoginResponse>((resolve, reject) => {
            this.http.post<LoginResponse>(this.apiUrl + "Token/refresh", credentials, {
                headers: new HttpHeaders({
                    "Content-Type": "application/json"
                })
            }).subscribe({
                next: (res: LoginResponse) => resolve(res),
                error: (_) => {
                    reject;
                    isRefreshSuccess = false;
                }
            });
        });
        if (refreshRes.token && refreshRes.refreshToken) {
            localStorage.setItem("token", refreshRes.token);
            localStorage.setItem("refreshToken", refreshRes.refreshToken);
        }
        isRefreshSuccess = true;
        return isRefreshSuccess;
    }
}

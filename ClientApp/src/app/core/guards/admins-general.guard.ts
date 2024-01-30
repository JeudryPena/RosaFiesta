import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';
import {AuthenticateService} from '@auth/services/authenticate.service';

@Injectable({
  providedIn: 'root'
})
export class AdminsGeneralGuard implements CanActivate {
  constructor(private authService: AuthenticateService, private router: Router) {
  }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (this.authService.isUserAdmin() || this.authService.isUserMarketingManager() || this.authService.isUserProductsManager() || this.authService.isUserSalesManager())
      return true;

    this.router.navigate(['/forbidden'], {queryParams: {returnUrl: state.url}});
    return false;
  }
}

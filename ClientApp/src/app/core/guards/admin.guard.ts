import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';
import {AuthenticateService} from '../../auth/services/authenticate.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {

  constructor(private authService: AuthenticateService, private router: Router) {
  }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (this.authService.isUserAdmin())
      return true;
    if (this.authService.isUserMarketingManager()) {
      this.router.navigate(['/admin/inventory/management-discounts']);
      return true;
    }
    if (this.authService.isUserProductsManager()) {
      this.router.navigate(['/admin/inventory/management-products']);
      return true;
    }

    this.router.navigate(['/forbidden'], {queryParams: {returnUrl: state.url}});
    return false;
  }
}

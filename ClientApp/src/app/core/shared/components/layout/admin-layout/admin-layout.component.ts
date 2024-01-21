import {Component, Input} from '@angular/core';
import {Layout} from '../sidenav/layout';
import {CurrentUserResponse} from "@core/interfaces/Security/Response/userResponse";
import {AuthenticateService} from "@auth/services/authenticate.service";

interface SidenavToggle {
  screenWidth: number;
  collapsed: boolean;
}

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.scss']
})
export class AdminLayoutComponent {
  layout = Layout.Dashboard;
  isSideNavCollapsed = false;
  screenWidth = 0;
  main = true;
  @Input() collapsed = false;

  user: CurrentUserResponse;

  constructor(
    private readonly authService: AuthenticateService,
  ) {
  }

  onToggleSidenav(data: SidenavToggle): void {
    this.screenWidth = data.screenWidth;
    this.isSideNavCollapsed = data.collapsed;
  }

  ngOnInit(): void {
    this.screenWidth = window.innerWidth;
    this.Authenticate();
  }

  Authenticate() {
    if (this.authService.isUserAuthenticated()) {
      this.user = this.authService.currentUser();
    }
  }

  logout() {
    this.authService.logout();
    if (this.authService.isExternalAuth)
      this.authService.signOutExternal();
  }
}

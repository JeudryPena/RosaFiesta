import {Component, Input, OnInit} from '@angular/core';
import {Layout} from "@core/shared/components/layout/sidenav/layout";
import {AuthenticateService} from "@auth/services/authenticate.service";
import {CurrentUserResponse} from "@core/interfaces/Security/Response/userResponse";

interface SidenavToggle {
  screenWidth: number;
  collapsed: boolean;
}

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {

  layout = Layout.Dashboard;
  screenWidth = 0;
  main = true;
  @Input() collapsed = false;

  user: CurrentUserResponse;

  constructor(
    private readonly authService: AuthenticateService,
  ) {
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

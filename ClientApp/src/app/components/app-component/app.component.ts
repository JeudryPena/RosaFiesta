import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticateService } from '../../shared/services/authenticate.service';

interface SidenavToggle {
  screenWidth: number;
  collapsed: boolean;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  isSideNavCollapsed = false;
  screenWidth = 0;
  constructor(private authService: AuthenticateService, private router: Router) {
    
  }

  ngOnInit(): void {
    this.authService.sendAuthStateChangeNotification(true);
  }

  onToggleSidenav(data: SidenavToggle): void {
    this.screenWidth = data.screenWidth;
    this.isSideNavCollapsed = data.collapsed;
  }
}

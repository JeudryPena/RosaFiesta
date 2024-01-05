import {Component} from '@angular/core';
import {Layout} from "@core/shared/components/layout/sidenav/layout";

interface SidenavToggle {
  screenWidth: number;
  collapsed: boolean;
}

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent {

  layout = Layout.Dashboard;

  isSideNavCollapsed = false;
  screenWidth = 0;
  main = true;

  onToggleSidenav(data: SidenavToggle): void {
    this.screenWidth = data.screenWidth;
    this.isSideNavCollapsed = data.collapsed;
  }
}

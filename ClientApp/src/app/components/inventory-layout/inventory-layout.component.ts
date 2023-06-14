import { Component } from '@angular/core';
import { Layout } from '../sidenav/layout';

interface SidenavToggle {
  screenWidth: number;
  collapsed: boolean;
}

@Component({
  selector: 'app-inventory-layout',
  templateUrl: './inventory-layout.component.html',
  styleUrls: ['./inventory-layout.component.scss']
})
export class InventoryLayoutComponent {
  layout = Layout.Inventory;
  isSideNavCollapsed = false;
  screenWidth = 0;

  onToggleSidenav(data: SidenavToggle): void {
    this.screenWidth = data.screenWidth;
    this.isSideNavCollapsed = data.collapsed;
  }
}

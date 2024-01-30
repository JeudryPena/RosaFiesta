import {animate, keyframes, style, transition, trigger} from '@angular/animations';
import {Component, EventEmitter, HostListener, Input, OnDestroy, OnInit, Output} from '@angular/core';
import {Router} from '@angular/router';
import {Subscription} from 'rxjs';
import {CategoriesService} from '@admin/inventory/services/categories.service';
import {SidenavService} from '../../../services/side-nav.service';
import {encrypt} from '../../../util/util-encrypt';
import {dashboardData} from './dashboard-data';
import {inventoryData} from './inventory-data';
import {Layout} from './layout';
import {CategoryPreviewResponse} from "@core/interfaces/Product/category";
import {CurrentUserResponse} from "@core/interfaces/Security/Response/userResponse";
import {AuthenticateService} from "@auth/services/authenticate.service";

interface SidenavToggle {
  screenWidth: number;
  collapsed: boolean;
}

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss'],
  animations: [
    trigger('fadeInOut', [
      transition(':enter', [
        style({opacity: 0}),
        animate('350ms',
          style({opacity: 1})
        )
      ]),
      transition(':leave', [
        style({opacity: 1}),
        animate('350ms',
          style({opacity: 0})
        )
      ])
    ]),
    trigger('rotate', [
      transition(':enter', [
        animate('600ms',
          keyframes([
            style({transform: 'rotate(0deg)', offset: '0'}),
            style({transform: 'rotate(1turn)', offset: '1'})
          ])
        )
      ])
    ])
  ]
})
export class SidenavComponent implements OnDestroy, OnInit {
  @Output() onToggleSidenav: EventEmitter<SidenavToggle> = new EventEmitter();
  @Input() layout: Layout = Layout.Normal;
  collapsed = false;
  screenWidth = 0;
  navData: any[];
  multiple: boolean = false;
  user: CurrentUserResponse;
  private subscription: Subscription;

  constructor(
    private categoryService: CategoriesService,
    private sidenavService: SidenavService,
    private router: Router,
    private readonly authService: AuthenticateService
  ) {
    this.subscription = this.sidenavService.toggleSidenav$.subscribe(() => {
      this.toggleCollapsed();
    });
  }

  ngOnInit(): void {
    this.authenticate();
    this.screenWidth = window.innerWidth;
    this.collapsed = false;
    if (this.layout === Layout.Normal) {
      this.GetData();
    } else if (this.layout === Layout.Dashboard) {
      this.navData = dashboardData;
    } else if (this.layout === Layout.Inventory) {
      this.navData = inventoryData;
    }
  }

  authenticate(): void {
    if (this.authService.isUserAuthenticated()) {
      this.user = this.authService.currentUser();
    }
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  GetData(): void {
    this.categoryService.GetCategories().subscribe((data: CategoryPreviewResponse[]) => {
      this.navData = data;
    });
  }

  Navigate(id: any): void {
    if (this.layout === Layout.Normal) {
      const categoryId = encrypt(id.toString());
      this.router.navigate([`/products/search`], {queryParams: {categoryId}});
    } else if (this.layout === Layout.Dashboard) {
      this.router.navigate([`admin/dashboard/${id}`]);
    } else if (this.layout === Layout.Inventory) {
      this.router.navigate([`admin/inventory/${id}`]);
    }
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: any): void {
    this.screenWidth = window.innerWidth;
    if (this.screenWidth <= 768) {
      this.collapsed = false;
      this.onToggleSidenav.emit({collapsed: this.collapsed, screenWidth: this.screenWidth})
    }
  }

  toggleCollapsed(): void {
    this.collapsed = !this.collapsed;
    this.onToggleSidenav.emit({collapsed: this.collapsed, screenWidth: this.screenWidth})
  }

  closeSidenav(): void {
    this.collapsed = false;
    this.onToggleSidenav.emit({collapsed: this.collapsed, screenWidth: this.screenWidth})
  }

  handleClick(item: CategoryPreviewResponse): void {
    if (!this.multiple) {
      for (let modelItem of this.navData) {
        if (item !== modelItem && modelItem.expanded) {
          modelItem.expanded = false;
        }
      }
    }
  }
}

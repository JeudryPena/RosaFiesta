import { animate, keyframes, style, transition, trigger } from '@angular/animations';
import { Component, EventEmitter, HostListener, OnDestroy, OnInit, Output } from '@angular/core';
import { INavbarData } from './helper';
import { navbarData } from './nav-data';
import { CategoryPreviewResponse } from '../../interfaces/Product/Response/categoryPreviewResponse';
import { CategoriesService } from '../../shared/services/categories.service';
import { SidenavService } from '../../shared/services/side-nav.service';
import { Subscription } from 'rxjs';

interface SidenavToggle{
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
        style({ opacity: 0 }),
        animate('350ms',
          style({ opacity: 1 })
        )
      ]),
      transition(':leave', [
        style({ opacity: 1 }),
        animate('350ms',
          style({ opacity: 0 })
        )
      ])
    ]),
    trigger('rotate', [
      transition(':enter', [
        animate('600ms',
          keyframes([
            style({ transform: 'rotate(0deg)', offset: '0'}),
            style({ transform: 'rotate(1turn)', offset: '1'})
         ])
        )
      ])
    ])
  ]
})
export class SidenavComponent implements OnDestroy {
  private subscription: Subscription;

  ngOnInit(): void {
    this.screenWidth = window.innerWidth;
    this.collapsed = false;
  }
  
  @Output() onToggleSidenav: EventEmitter<SidenavToggle> = new EventEmitter();

  collapsed = false;
  screenWidth = 0;
  navData: CategoryPreviewResponse[] = [];
  multiple: boolean = false;

  constructor(
    private categoryService: CategoriesService,
    private sidenavService: SidenavService
  ) {
    this.GetData();
    this.subscription = this.sidenavService.toggleSidenav$.subscribe(() => {
      this.toggleCollapsed();
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  GetData(): void {
    this.categoryService.GetCategories().subscribe((data: CategoryPreviewResponse[]) => {
      this.navData = data;
    });
  }

  Navigate(id: number): void {
    
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
      for (let modelItem of this.navData){
        if (item !== modelItem && modelItem.expanded) {
          modelItem.expanded = false;
        }
      }
    }
    item.expanded = !item.expanded;
  }
}

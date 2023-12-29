import {Component, HostListener, Input, OnInit, ViewChild} from '@angular/core';
import {AuthenticateService} from '@auth/services/authenticate.service';
import {CartsService} from '@intranet/services/carts.service';
import {SidenavService} from '../../../services/side-nav.service';
import {SidenavComponent} from '../sidenav/sidenav.component';
import {Router} from "@angular/router";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.sass']
})
export class NavbarComponent implements OnInit {
  @ViewChild(SidenavComponent) sidenav!: SidenavComponent;
  userName: string;
  viewCart: boolean = false;
  @Input() main;

  isSearchInputFocused = false;
  isAuthenticated = false;
  lastScrollTop = 0;
  navbar: any;
  totalItems: number = 0;

  isFocused = false;

  constructor(
    public service: CartsService,
    private authService: AuthenticateService,
    private sidenavService: SidenavService,
    private router: Router
  ) {
    this.Authenticate();

  }

  onFocus() {
    this.isFocused = true;
  }

  onBlur() {
    this.isFocused = false;
  }

  Authenticate() {
    this.isAuthenticated = this.authService.isUserAuthenticated();
    if (this.isAuthenticated) {
      this.authService.currentUser().subscribe((data: any) => {
        this.userName = data.userName;
      });
    }
  }

  total(event: any) {
    this.totalItems = event;
  }

  redirectTo(route: string) {
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
      this.router.navigate([]);
    });
  }

  ToggleCollapsed(): void {
    this.sidenavService.toggleCollapsed();
  }

  onToggleCart() {
    this.viewCart = !this.viewCart
  };

  @HostListener('window:scroll', ['$event'])
  onWindowScroll(event: any) {
    const scrollTop = window.pageYOffset || document.documentElement.scrollTop;
    this.navbar = document.getElementById("navbar");
    if (scrollTop > this.lastScrollTop) {
      this.navbar.style.top = "-50px";
    } else {
      this.navbar.style.top = "0";
    }
    this.lastScrollTop = scrollTop;
  }

  Logout() {
    this.authService.logout();
    if (this.authService.isExternalAuth)
      this.authService.signOutExternal();
    window.location.reload();
  }

  ngOnInit() {

  }
}

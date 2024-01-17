import {Component, HostListener, Input, OnInit, ViewChild} from '@angular/core';
import {AuthenticateService} from '@auth/services/authenticate.service';
import {CartsService} from '@intranet/services/carts.service';
import {SidenavService} from '../../../services/side-nav.service';
import {SidenavComponent} from '../sidenav/sidenav.component';
import {Router} from "@angular/router";
import {FormBuilder, FormGroup} from "@angular/forms";
import {SearchProducts} from "@core/interfaces/searchProducts";
import {encrypt} from "@core/shared/util/util-encrypt";
import {CategoriesService} from "@admin/inventory/services/categories.service";
import {Observable} from "rxjs";
import {CategoryPreviewResponse} from "@core/interfaces/Product/category";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.sass']
})
export class NavbarComponent implements OnInit {
  @ViewChild(SidenavComponent) sidenav!: SidenavComponent;
  userName: string;
  @Input() main;
  categories$: Observable<CategoryPreviewResponse[]> = new Observable<CategoryPreviewResponse[]>();

  isAuthenticated = false;
  lastScrollTop = 0;
  navbar: any;
  totalItems: number = 0;
  searchForm: FormGroup;

  constructor(
    public service: CartsService,
    private authService: AuthenticateService,
    private sidenavService: SidenavService,
    private router: Router,
    private fb: FormBuilder,
    private categoryService: CategoriesService
  ) {
    this.Authenticate();

  }

  ngOnInit(): void {
    this.retrieveCategories();
    this.searchForm = this.fb.group({
      search: [''],
      categoryId: [0]
    });
  }

  retrieveCategories() {
    this.categories$ = this.categoryService.GetCategories();
  }

  searchProducts(searchFormValue: any) {
    const searchForm = {...searchFormValue};
    const searchObject: SearchProducts = {
      searchValue: searchForm.search,
      categoryId: searchForm.categoryId > 0 ? searchForm.categoryId : null
    }
    const searchEncrypted = encrypt(JSON.stringify(searchObject));
    this.router.navigate(['/products/search'], {queryParams: {searchProduct: searchEncrypted}});
  }

  Authenticate() {
    this.isAuthenticated = this.authService.isUserAuthenticated();
    if (this.isAuthenticated) {
      const user = this.authService.currentUser();
      this.userName = user.userName;
    }
  }

  total(event: any) {
    this.totalItems = event;
  }

  ToggleCollapsed(): void {
    this.sidenavService.toggleCollapsed();
  }

  @HostListener('window:scroll', ['$event'])
  onWindowScroll(event: any) {
    const scrollTop = window.pageYOffset || document.documentElement.scrollTop;
    this.navbar = document.getElementById("navbar");

    if (scrollTop > this.lastScrollTop) {
      this.navbar.style.top = "-58px";
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

}

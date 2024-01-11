import {Component, OnInit} from '@angular/core';
import {CategoriesService} from "@admin/inventory/services/categories.service";
import {CategoryPreviewResponse} from "@core/interfaces/Product/category";
import {Observable} from "rxjs";
import {Router} from "@angular/router";
import {AuthenticateService} from "@auth/services/authenticate.service";
import {Card} from "@core/interfaces/card";
import {encrypt} from "@core/shared/util/util-encrypt";

@Component({
  selector: 'app-top-main',
  templateUrl: './top-main.component.html',
  styleUrl: './top-main.component.sass'
})
export class TopMainComponent implements OnInit {

  images: Card[] = [];
  isAuthenticated: boolean = false;
  categories$: Observable<CategoryPreviewResponse[]> = new Observable<CategoryPreviewResponse[]>();
  total$: Observable<number> = new Observable<number>();

  constructor(
    private readonly categoryService: CategoriesService,
    private readonly router: Router,
    private readonly authService: AuthenticateService
  ) {
    this.isAuthenticated = this.authService.isUserAuthenticated();
    this.retrieveCategories();
  }

  ngOnInit() {
    this.images = [
      {
        title: 'Llena de vida tu cumpleaños',
        description: 'Plasmamos tus ideas',
        url: 'assets/img/banner3.jpg',
      },
      {
        title: 'Aprovecha nuestras ofertas',
        description: 'Pide desde tu casa',
        url: 'assets/img/banner2.jpg',
      },
      {
        title: 'Dale un toque especial a tu fiesta',
        description: 'Ofrecemos una gran variedad de productos',
        url: 'assets/img/inquiry-img.jpg',
      },
      {
        title: 'Aprovecha nuestras ofertas',
        description: 'Impresiona a tus invitados',
        url: 'assets/img/banner4.jpg',
      }
    ]
  }

  retrieveCategories() {
    this.categories$ = this.categoryService.GetCategories();
    this.total$ = this.categoryService.total$;
  }

  selectCategory(categoryId: number) {
    const data = {id: categoryId};
    const encryptedCategoryId = encrypt(JSON.stringify(data));
    this.router.navigate([`/products/search`], {queryParams: {categoryId: encryptedCategoryId}});
  }

  isAuth() {
    this.isAuthenticated = this.authService.isUserAuthenticated();
  }
}

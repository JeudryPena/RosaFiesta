import {Component, OnInit} from '@angular/core';
import {CategoriesService} from "@admin/inventory/services/categories.service";
import {CategoryPreviewResponse} from "@core/interfaces/Product/category";
import {Observable} from "rxjs";
import {Router} from "@angular/router";

@Component({
  selector: 'app-top-main',
  templateUrl: './top-main.component.html',
  styleUrl: './top-main.component.sass'
})
export class TopMainComponent implements OnInit {

  categories$: Observable<CategoryPreviewResponse[]> = new Observable<CategoryPreviewResponse[]>();
  total$: Observable<number> = new Observable<number>();

  constructor(
    private readonly categoryService: CategoriesService,
    private readonly router: Router
  ) {
    this.retrieveCategories();
  }

  ngOnInit() {

  }

  retrieveCategories() {
    this.categoryService.RetrieveData();
    this.categories$ = this.categoryService.categories$;
    this.total$ = this.categoryService.total$;
  }

  selectCategory(categoryId: number) {
    this.router.navigate([`/products/search`], {state: {data: categoryId}});
  }
}

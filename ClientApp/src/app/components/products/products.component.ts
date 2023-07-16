import { Component } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { decrypt } from '../../shared/util/util-encrypt';
import { CategoriesService } from '../../shared/services/categories.service';
import { CategoryResponse } from '../../interfaces/Product/Response/categoryResponse';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent {
  url: string = "assets/backgrounds/loginBG.jpg";
  category!: CategoryResponse;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private categoryService: CategoriesService
  ) { 
    this.route.queryParams.subscribe((params: Params) => {
      const categoryId = decrypt<number>(params['categoryId']);
      if(categoryId)
        this.categoryService.GetCategory(categoryId).subscribe((data) => {
          this.category = data;
        }); 
      else
        this.router.navigate(['/']);
    });
  }
}

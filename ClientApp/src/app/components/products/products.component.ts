import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Observable, catchError } from 'rxjs';
import { CategoryResponse } from '../../interfaces/Product/Response/categoryResponse';
import { CategoriesService } from '../../shared/services/categories.service';
import { decrypt } from '../../shared/util/util-encrypt';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  category$!: Observable<CategoryResponse>;
  hasError: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private categoryService: CategoriesService
  ) {

  }

  ngOnInit(): void {
    this.Retrieve();
  }

  async Retrieve() {
    this.route.queryParams.subscribe((params: Params) => {
      const categoryId = decrypt<number>(params['categoryId']);
      if (categoryId) {
        this.category$ = this.categoryService.GetCategory(categoryId).pipe(catchError(err => { 
          this.router.navigate(['/']);
          throw err;
        }));
      }
      else
        this.router.navigate(['/']);
    });
  }
}

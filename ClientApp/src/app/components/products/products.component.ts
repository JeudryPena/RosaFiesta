import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Observable, catchError, map } from 'rxjs';
import { CategoryResponse } from '../../interfaces/Product/Response/categoryResponse';
import { CategoriesService } from '../../shared/services/categories.service';
import { decrypt, encrypt } from '../../shared/util/util-encrypt';
import { forEach } from 'mathjs';
import { ReviewsService } from '../../shared/services/reviews.service';
import { DiscountsService } from '../../shared/services/discounts.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ProductsComponent implements OnInit {
  category$!: Observable<CategoryResponse>;
  hasError: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private categoryService: CategoriesService,
    private reviewService: ReviewsService,
    private discountService: DiscountsService
  ) {

  }

  ngOnInit(): void {
    this.Retrieve();
  }

  ProductDetail(id: string) {
    const productId = encrypt(id.toString());
    console.log(productId)
    this.router.navigate([`/product-detail`], { queryParams: { productId } });
  }

  async Retrieve() {
    this.route.queryParams.subscribe((params: Params) => {
      const categoryId = decrypt<number>(params['categoryId']);
      if (categoryId) {
        this.category$ = this.categoryService.GetCategory(categoryId).pipe(
          catchError(err => { 
          this.router.navigate(['/']);
          throw err;
          }),
          map((category: CategoryResponse) => {
            if(category.products != null )
              category.products.forEach(product => {
                this.reviewService.GetReviews(product.option.id).subscribe((reviews:any) => {
                  product.option.reviews = reviews;
                  product.option.averageRating = reviews.reduce((acc: any, review: any) => acc + review.rating, 0) / reviews.length;
                });
                this.discountService.GetOptionDiscount(product.option.id).subscribe((discount: any) => {
                  product.option.discount = discount;
                  product.option.offerPrice = product.option.price - (product.option.price * (discount.value / 100));
                });
              });
            return category;
          }) 
        );
        
      }
      else
        this.router.navigate(['/']);
    });
  }
}

import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {catchError, map, Observable} from 'rxjs';
import {CategoriesService} from '@admin/inventory/services/categories.service';
import {DiscountsService} from '@admin/inventory/services/discounts.service';
import {ReviewsService} from '@intranet/services/reviews.service';
import {decrypt} from '@core/shared/util/util-encrypt';
import {ProductsService} from '@admin/inventory/services/products.service';
import {CategoryPreviewResponse, CategoryResponse} from "@core/interfaces/Product/category";
import {ProductPreviewResponse} from "@core/interfaces/Product/Response/productPreviewResponse";

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  hasError: boolean = false;
  categories$: Observable<CategoryPreviewResponse[]> = new Observable<CategoryPreviewResponse[]>();
  products$: Observable<ProductPreviewResponse[]>;
  selectedCategory: CategoryPreviewResponse;

  selectedCondition: string;
  selectedRating: number;
  startValue = 0;
  endValue = 0;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private categoryService: CategoriesService,
    private reviewService: ReviewsService,
    private discountService: DiscountsService,
    private productsService: ProductsService
  ) {

  }

  ngOnInit(): void {
    this.retrieveCategories();
    this.Retrieve();
  }

  retrieveCategories() {
    this.categories$ = this.categoryService.GetCategories();
  }

  Retrieve() {
    this.route.queryParams.subscribe(async (params: Params) => {
      const categoryId = params['categoryId'];
      if (categoryId) {
        const idObject = decrypt<{ id: number }>(categoryId);
        this.categoryProducts(idObject.id);
      } else
        await this.retrieveRecommendProducts();
    });
  }

  async retrieveRecommendProducts(): Promise<void> {
    this.products$ = this.productsService.GetRecommendProducts().pipe(
      catchError(err => {
        console.log(err);
        return [];
      }),
      map((products: ProductPreviewResponse[]) => {
        products.map((product: ProductPreviewResponse) => {
          this.reviewService.GetReviewsPreview(product.option.id).subscribe((reviews: any) => {
            product.option.reviews = reviews;
            product.option.averageRating = reviews.reduce((acc: any, review: any) => acc + review.rating, 0) / reviews.length;
          });
          this.discountService.GetOptionDiscount(product.option.id).subscribe((discount: any) => {
            if (discount) {
              product.option.discount = discount;
              product.option.offerPrice = product.option.price - (product.option.price * (discount.value / 100));
            }
          });
        });
        return products;
      })
    )
  }

  selectRating(rating: number) {
    this.selectedRating = rating;
  }

  selectStartPrice(start: number) {
    this.startValue = start;
  }

  selectEndPrice(end: number) {
    this.endValue = end;
  }

  selectCondition(condition: string) {
    this.selectedCondition = condition;
  }

  removeCondition() {
    this.selectedCondition = null;
  }

  removeRating() {
    this.selectedRating = null;
  }

  removeStartValue() {
    this.startValue = 0;
  }

  removeEndValue() {
    this.endValue = 0;
  }

  private categoryProducts(categoryId: number) {
    this.products$ = this.categoryService.GetCategory(categoryId).pipe(
      catchError(err => {
        this.router.navigate(['/main-page']).then(
          () => console.error(err)
        );
        throw err
      }),
      map((category: CategoryResponse) => {
        if (category.products != null)
          category.products.forEach(product => {
            this.reviewService.GetReviewsPreview(product.option.id).subscribe((reviews: any) => {
              product.option.reviews = reviews;
              product.option.averageRating = reviews.reduce((acc: any, review: any) => acc + review.rating, 0) / reviews.length;
            });
            this.discountService.GetOptionDiscount(product.option.id).subscribe((discount: any) => {
              product.option.discount = discount;
              product.option.offerPrice = product.option.price - (product.option.price * (discount.value / 100));
            });
          });
        this.selectedCategory = {
          id: category.id,
          name: category.name,
          description: category.description,
          icon: ''
        }
        return category.products;
      })
    );
  }
}

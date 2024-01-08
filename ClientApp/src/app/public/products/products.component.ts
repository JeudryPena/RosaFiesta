import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {catchError, map, Observable} from 'rxjs';
import {CategoriesService} from '@admin/inventory/services/categories.service';
import {DiscountsService} from '@admin/inventory/services/discounts.service';
import {ReviewsService} from '@intranet/services/reviews.service';
import {decrypt, encrypt} from '@core/shared/util/util-encrypt';
import {ProductsService} from '@admin/inventory/services/products.service';
import {CategoryResponse} from "@core/interfaces/Product/category";

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
    private categoryService: CategoriesService,
    private reviewService: ReviewsService,
    private discountService: DiscountsService,
    private productsService: ProductsService
  ) {

  }

  ngOnInit(): void {
    this.Retrieve();
  }

  productDetail() {
    const data = {id: '1e03fcc6-230f-4220-830a-fd59a96cae9f'};
    const productId = encrypt(JSON.stringify(data));
    this.router.navigate([`/products/detail`], {queryParams: {productId}});
  }

  async Retrieve() {
    this.route.queryParams.subscribe((params: Params) => {
      const categoryId = decrypt<number>(params['categoryId']);
      if (categoryId)
        this.categoryProducts(categoryId);
      else
        this.allProducts();
    });
  }

  private allProducts() {
    this.productsService.GetProductsPreview().subscribe((products: any) => {
      products.forEach((product: any) => {
        this.reviewService.GetReviewsPreview(product.option.id).subscribe((reviews: any) => {
          product.option.reviews = reviews;
          product.option.averageRating = reviews.reduce((acc: any, review: any) => acc + review.rating, 0) / reviews.length;
        });
        this.discountService.GetOptionDiscount(product.option.id).subscribe((discount: any) => {
          product.option.discount = discount;
          product.option.offerPrice = product.option.price - (product.option.price * (discount.value / 100));
        });
      });
    });
  }

  private categoryProducts(categoryId: number) {
    this.category$ = this.categoryService.GetCategory(categoryId).pipe(
      catchError(err => {
        this.router.navigate(['/']);
        throw err;
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
        return category;
      })
    );
  }
}

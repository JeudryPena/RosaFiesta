import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {BehaviorSubject, lastValueFrom} from 'rxjs';
import {ProductDetailResponse} from '@core/interfaces/Product/Response/productDetailResponse';
import {CartsService} from '@intranet/services/carts.service';
import {DiscountsService} from '@admin/inventory/services/discounts.service';
import {ProductsService} from '@admin/inventory/services/products.service';
import {ReviewsService} from '@intranet/services/reviews.service';
import {decrypt} from "@core/shared/util/util-encrypt";
import {catchError} from "rxjs/operators";
import {AuthenticateService} from "@auth/services/authenticate.service";

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.sass']
})
export class ProductDetailComponent implements OnInit {
  product$: BehaviorSubject<ProductDetailResponse> = new BehaviorSubject<ProductDetailResponse>(null);

  isAuthenticated = false;
  userId: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: ProductsService,
    private reviewService: ReviewsService,
    private discountService: DiscountsService,
    private cartService: CartsService,
    private authService: AuthenticateService
  ) {
    this.Authenticate();
  }

  Authenticate() {
    this.isAuthenticated = this.authService.isUserAuthenticated();
    if (this.isAuthenticated) {
      const user = this.authService.currentUser();
      this.userId = user.id;
    }
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(async (params: Params) => {
      const productId = decrypt<{ id: string }>(params['productId']);
      this.service.increaseView(productId.id).subscribe();
      if (productId) {
        const productResponse = this.service.GetProductDetail(productId.id).pipe(
          catchError(err => {
            this.router.navigate(['/']);
            throw err;
          })
        );
        const product = await lastValueFrom(productResponse);
        const reviewResponse = this.reviewService.GetReviewsDetail(product.option.id);
        const discountResponse = this.discountService.GetOptionDiscount(product.option.id);
        const reviewsPromise = lastValueFrom(reviewResponse);
        const discountPromise = lastValueFrom(discountResponse);
        await Promise.all([reviewsPromise, discountPromise]).then(([reviews, discount]) => {
          product.option.reviews = reviews;
          if (reviews.length == 0)
            product.option.averageRating = 0;
          else
            product.option.averageRating = reviews.reduce((acc: any, review: any) => acc + review.rating, 0) / reviews.length
          if (discount != null) {
            product.option.discount = discount;
            product.option.offerPrice = product.option.price - (product.option.price * (discount.value / 100));
          }
        });

        this.product$.next(product);
      } else
        await this.router.navigate(['/main-page']);
    });
  }

  refreshReviews() {
    const currentValue = this.product$.getValue();
    const response = this.reviewService.GetReviewsDetail(currentValue.option.id);
    const reviewsPromises = lastValueFrom(response);
    reviewsPromises.then(reviews => {
      currentValue.option.reviews = reviews;
      if (reviews.length == 0)
        currentValue.option.averageRating = 0;
      else
        currentValue.option.averageRating = reviews.reduce((acc: any, review: any) => acc + review.rating, 0) / reviews.length
      this.product$.next(currentValue);
    });
  }
}

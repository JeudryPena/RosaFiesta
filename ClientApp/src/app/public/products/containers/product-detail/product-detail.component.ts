import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {map, Observable} from 'rxjs';
import {ProductDetailResponse} from '@core/interfaces/Product/Response/productDetailResponse';
import {CartsService} from '@intranet/services/carts.service';
import {DiscountsService} from '@admin/inventory/services/discounts.service';
import {ProductsService} from '@admin/inventory/services/products.service';
import {ReviewsService} from '@intranet/services/reviews.service';
import {decrypt} from "@core/shared/util/util-encrypt";
import {catchError} from "rxjs/operators";

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.sass']
})
export class ProductDetailComponent implements OnInit {
  product$!: Observable<ProductDetailResponse>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: ProductsService,
    private reviewService: ReviewsService,
    private discountService: DiscountsService,
    private cartService: CartsService
  ) {

  }

  ngOnInit(): void {
    this.route.queryParams.subscribe((params: Params) => {
      const productId = decrypt<{ id: string }>(params['productId']);
      this.service.increaseView(productId.id).subscribe();
      if (productId) {
        this.product$ = this.service.GetProductDetail(productId.id).pipe(
          catchError(err => {
            this.router.navigate(['/']);
            throw err;
          }),
          map((product: ProductDetailResponse) => {
            this.reviewService.GetReviewsPreview(product.option.id).subscribe((reviews: any) => {
              product.option.reviews = reviews;
              product.option.averageRating = reviews.reduce((acc: any, review: any) => acc + review.rating, 0) / reviews.length;
            });
            this.discountService.GetOptionDiscount(product.option.id).subscribe((discount: any) => {
              if (discount != null) {
                product.option.discount = discount;
                product.option.offerPrice = product.option.price - (product.option.price * (discount.value / 100));
              }
            });
            return product;
          }));
      } else
        this.router.navigate(['/main-page']);
    });
  }
}

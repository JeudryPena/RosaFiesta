import {Component, Input, OnInit} from '@angular/core';
import {catchError} from "rxjs/operators";
import {map, Observable} from "rxjs";
import {ProductPreviewResponse} from "@core/interfaces/Product/Response/productPreviewResponse";
import {ProductsService} from "@admin/inventory/services/products.service";
import {ReviewsService} from "@intranet/services/reviews.service";
import {DiscountsService} from "@admin/inventory/services/discounts.service";

@Component({
  selector: 'app-details-suggest',
  templateUrl: './details-suggest.component.html',
  styleUrl: './details-suggest.component.sass'
})
export class DetailsSuggestComponent implements OnInit {

  @Input() categoryId: number;
  products$: Observable<ProductPreviewResponse[]> = new Observable<ProductPreviewResponse[]>();

  constructor(
    private readonly productService: ProductsService,
    private readonly reviewService: ReviewsService,
    private readonly discountService: DiscountsService
  ) {
  }

  async ngOnInit() {
    await this.retrieveRecommendProducts();
  }

  async retrieveRecommendProducts(): Promise<void> {
    this.products$ = this.productService.GetRelatedProducts(this.categoryId).pipe(
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
}

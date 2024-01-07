import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {Observable} from 'rxjs';
import {ProductDetailResponse} from '@core/interfaces/Product/Response/productDetailResponse';
import {PurchaseDetailDto} from '@core/interfaces/Product/UserInteract/purchaseDetailDto';
import {CartsService} from '@intranet/services/carts.service';
import {DiscountsService} from '@admin/inventory/services/discounts.service';
import {ProductsService} from '@admin/inventory/services/products.service';
import {ReviewsService} from '@intranet/services/reviews.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {
  cartForm: any;
  optionId: string = '';
  productId: string = '';
  product$!: Observable<ProductDetailResponse>;
  colorCode = "#ff0000";
  tuhna = '0 0 0 2px #fff, 0 0 0 4px #ff0000';
  isActive = true;
  rating: number = 3.5;
  hasError: boolean = false;

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

    // this.cartForm = new FormGroup({
    //   quantity: new FormControl(1)
    // });
    // this.route.queryParams.subscribe((params: Params) => {
    //   const productId = decrypt<{ id: string }>(params['productId']);
    //   if (productId) {
    //     this.productId = productId.id;
    //     this.product$ = this.service.GetProductDetail(productId.id).pipe(
    //       catchError(err => {
    //         this.router.navigate(['/']);
    //         throw err;
    //       }),
    //       map((product: ProductDetailResponse) => {
    //         this.optionId = product.option.id;
    //         this.reviewService.GetReviewsPreview(product.option.id).subscribe((reviews: any) => {
    //           product.option.reviews = reviews;
    //           product.option.averageRating = reviews.reduce((acc: any, review: any) => acc + review.rating, 0) / reviews.length;
    //         });
    //         this.discountService.GetOptionDiscount(product.option.id).subscribe((discount: any) => {
    //           product.option.discount = discount;
    //           product.option.offerPrice = product.option.price - (product.option.price * (discount.value / 100));
    //         });
    //         return product;
    //       })
    //     );
    //   } else
    //     this.router.navigate(['/']);
    // });
  }

  AddToCart(cartFormValue: any) {
    const cart = {...cartFormValue};

    const cartDto: PurchaseDetailDto = {
      productId: this.productId,
      quantity: cart.quantity,
      optionId: this.optionId
    }
    console.log(cartDto)
    this.cartService.AddProductToCart(cartDto).subscribe({
      next: () => {
        this.router.navigate(['']);
      }, error: (err) => {
        this.hasError = true;
        console.log(err);
      }
    });
  }
}

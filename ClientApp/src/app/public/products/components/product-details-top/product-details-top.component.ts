import {Component, Input, OnInit} from '@angular/core';
import {ProductDetailResponse} from "@core/interfaces/Product/Response/productDetailResponse";
import {FormControl, FormGroup} from "@angular/forms";
import {PurchaseDetailDto} from "@core/interfaces/Product/UserInteract/purchaseDetailDto";
import {CartsService} from "@intranet/services/carts.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-product-details-top',
  templateUrl: './product-details-top.component.html',
  styleUrl: './product-details-top.component.sass'
})
export class ProductDetailsTopComponent implements OnInit {
  isActive = true;
  cartForm!: FormGroup;

  @Input() product: ProductDetailResponse;
  @Input() isAuthenticated = false;

  constructor(
    private readonly cartService: CartsService,
    private readonly router: Router
  ) {

  }

  ngOnInit(): void {
    this.cartForm = new FormGroup({
      quantity: new FormControl(1)
    });
  }

  AddToCart(cartFormValue: any) {
    const cart = {...cartFormValue};

    const cartDto: PurchaseDetailDto = {
      productId: this.product.id,
      quantity: cart.quantity,
      optionId: this.product.optionId
    }
    console.log(cartDto)
    this.cartService.AddProductToCart(cartDto).subscribe({
      next: () => {
        this.router.navigate(['']);
      }, error: (err) => {
        console.error(err);
      }
    });
  }

}

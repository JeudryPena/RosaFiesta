import {Component, Input} from '@angular/core';
import {ProductPreviewResponse} from "@core/interfaces/Product/Response/productPreviewResponse";
import {WisheslistService} from "@intranet/services/wisheslist.service";
import {Router} from "@angular/router";
import {encrypt} from "@core/shared/util/util-encrypt";

@Component({
  selector: 'app-product-cards',
  templateUrl: './product-cards.component.html',
  styleUrl: './product-cards.component.sass'
})
export class ProductCardsComponent {
  @Input() products: ProductPreviewResponse[];

  constructor(
    private readonly wishlistService: WisheslistService,
    private readonly router: Router
  ) {
  }

  productDetail(id: string) {
    const data = {id: id};
    const productId = encrypt(JSON.stringify(data));
    this.router.navigate([`/products/detail`], {queryParams: {productId}});
  }

  addToWishList(optionId: string) {
    this.wishlistService.addToWishList(optionId).subscribe((res: any) => {

    });
  }
}

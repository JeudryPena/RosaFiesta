import {Component, Input, OnInit} from '@angular/core';
import {HotestProductsResponse} from "@core/interfaces/Product/Response/discountResponse";
import {encrypt} from "@core/shared/util/util-encrypt";
import {Router} from "@angular/router";

@Component({
  selector: 'app-carousel-multiple',
  templateUrl: './carousel-multiple.component.html',
  styleUrl: './carousel-multiple.component.sass',
})
export class CarouselMultipleComponent implements OnInit {
  @Input() productsDiscounts: HotestProductsResponse[] = [];
  @Input() slidesPerView = 3;
  productsToShow: HotestProductsResponse[] = [];


  constructor(
    private readonly router: Router,
  ) {
  }

  productDetail(productId: string, optionId: string) {
    const data = {id: productId, optionId: optionId};
    const dataEncrypted = encrypt(JSON.stringify(data));
    this.router.navigate([`/products/detail`], {queryParams: {product: dataEncrypted}});
  }

  ngOnInit() {
    this.productsToShow = this.productsDiscounts.filter((product) => product.option.image !== null && product.option.image !== undefined);
  }
}

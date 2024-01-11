import {Component, Input} from '@angular/core';
import {ProductDetailResponse} from "@core/interfaces/Product/Response/productDetailResponse";

@Component({
  selector: 'app-product-details-bottom',
  templateUrl: './product-details-bottom.component.html',
  styleUrl: './product-details-bottom.component.sass'
})
export class ProductDetailsBottomComponent {

  @Input() product: ProductDetailResponse;
  

}

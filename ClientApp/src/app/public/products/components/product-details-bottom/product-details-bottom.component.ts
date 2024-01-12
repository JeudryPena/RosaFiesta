import {Component, EventEmitter, Input, Output} from '@angular/core';
import {ProductDetailResponse} from "@core/interfaces/Product/Response/productDetailResponse";

@Component({
  selector: 'app-product-details-bottom',
  templateUrl: './product-details-bottom.component.html',
  styleUrl: './product-details-bottom.component.sass'
})
export class ProductDetailsBottomComponent {
  @Output() refreshReviews: EventEmitter<any> = new EventEmitter();

  @Input() product: ProductDetailResponse;
  @Input() isAuthenticated = false;
  @Input() userId: string;

}

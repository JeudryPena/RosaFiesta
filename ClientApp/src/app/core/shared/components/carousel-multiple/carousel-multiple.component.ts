import {AfterViewInit, Component, Input} from '@angular/core';
import {HotestProductsResponse} from "@core/interfaces/Product/Response/discountResponse";

@Component({
  selector: 'app-carousel-multiple',
  templateUrl: './carousel-multiple.component.html',
  styleUrl: './carousel-multiple.component.sass',
})
export class CarouselMultipleComponent implements AfterViewInit {
  @Input() productsDiscounts: HotestProductsResponse[] = [];
  @Input() slidesPerView = 3;

  constructor() {
  }

  ngAfterViewInit() {

  }
}

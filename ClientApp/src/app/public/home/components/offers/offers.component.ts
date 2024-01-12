import {Component, OnInit} from '@angular/core';
import {catchError, map, Observable} from "rxjs";
import {DiscountsService} from "@admin/inventory/services/discounts.service";
import {DiscountResponse} from "@core/interfaces/Product/Response/discountResponse";

@Component({
  selector: 'app-offers',
  templateUrl: './offers.component.html',
  styleUrl: './offers.component.sass'
})
export class OffersComponent implements OnInit {

  discount$: Observable<DiscountResponse> = new Observable<DiscountResponse>()

  constructor(
    private readonly discountService: DiscountsService,
  ) {
  }

  ngOnInit() {
    this.retrieveData()
  }

  retrieveData() {
    this.discount$ = this.discountService.getHotOffers().pipe(
      catchError(err => {
        console.error(err)
        throw err
      }),
      map((discountResponse: DiscountResponse) => {
        if (!discountResponse) return null
        for (let product of discountResponse.productsDiscounts) {
          product.option.offerPrice = product.option.price - (product.option.price * discountResponse.value)
        }
        return discountResponse;
      })
    );
  }

}

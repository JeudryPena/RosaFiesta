import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {catchError, map, Observable, takeWhile, timer} from "rxjs";
import {DiscountsService} from "@admin/inventory/services/discounts.service";
import {DiscountResponse} from "@core/interfaces/Product/Response/discountResponse";
import {ReviewsService} from "@intranet/services/reviews.service";

@Component({
  selector: 'app-offers',
  templateUrl: './offers.component.html',
  styleUrl: './offers.component.sass'
})
export class OffersComponent implements OnInit {

  discount$: Observable<DiscountResponse> = new Observable<DiscountResponse>()
  timeRemaining$: Observable<number>;

  constructor(
    private readonly discountService: DiscountsService,
    private changeDetector: ChangeDetectorRef,
    private readonly reviewService: ReviewsService
  ) {
  }

  ngOnInit() {
    this.retrieveData()
  }

  elapsedTime(date: Date) {
    let totalSeconds = Math.floor((new Date().getTime() - date.getTime()) / 1000);

    let hours = 0;
    let minutes = 0;
    let seconds = 0;

    if (totalSeconds >= 3600) {
      hours = Math.floor(totalSeconds / 3600);
      totalSeconds -= 3600 * hours;
    }

    if (totalSeconds >= 60) {
      minutes = Math.floor(totalSeconds / 60);
      totalSeconds -= 60 * minutes;
    }

    seconds = totalSeconds;

    return {
      hours: hours,
      minutes: minutes,
      seconds: seconds
    };
  }

  retrieveTimeRemaining(date: any) {
    let newDate = new Date(date);

    let totalSeconds = Math.floor((newDate.getTime() - new Date().getTime()) / 1000);

    this.timeRemaining$ = timer(0, 1000).pipe(
      map(n => (totalSeconds - n) * 1000),
      takeWhile(n => n >= 0),
    );
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
          product.option.offerPrice = product.option.price - (product.option.price * (discountResponse.value / 100));
          this.reviewService.GetReviewsPreview(product.option.id).subscribe((reviews: any) => {
            product.option.reviews = reviews;
            product.option.averageRating = reviews.reduce((acc: any, review: any) => acc + review.rating, 0) / reviews.length;
          });
        }
        this.retrieveTimeRemaining(discountResponse.end)
        return discountResponse;
      })
    );
  }
}

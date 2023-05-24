import { Directive, Input, OnChanges, SimpleChanges } from '@angular/core';
import { StarRating } from '../../helpers/rating/StarRating';

@Directive({
  selector: '[appRating]'
})
export class RatingDirective implements OnChanges {

  @Input() appStarRating!: StarRating;

  fullStars!: number[];
  halfStar!: boolean;

  ngOnChanges(changes: SimpleChanges): void {
    const rating = this.appStarRating.rating;
    this.fullStars = Array(Math.floor(rating)).fill(0).map((x, i) => i);
    this.halfStar = rating % 1 !== 0;
  }
}

import {Component, EventEmitter, Input, OnChanges, Output, SimpleChanges, ViewChild} from '@angular/core';
import {NgxStarsComponent} from "ngx-stars";

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.scss']
})
export class RatingComponent implements OnChanges {
  @ViewChild(NgxStarsComponent)
  starsComponent: NgxStarsComponent;


  @Input() rating: number = 0;
  @Input() readonly = true;
  @Output() ratingChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() size = '24px';

  heartIcons = {
    empty: '../../../assets/icons/star-regular.svg',
    half: '../../../assets/icons/star-half-stroke-solid.svg',
    full: '../../../assets/icons/star-solid.svg',
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['rating'] && !changes['rating'].firstChange) {
      this.starsComponent.setRating(this.rating);
    }
  }
}

import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.scss']
})
export class RatingComponent {

  @Input() rating: number = 0;

  heartIcons = {
    empty: '../../../assets/icons/star-regular.svg',
    half: '../../../assets/icons/star-half-stroke-solid.svg',
    full: '../../../assets/icons/star-solid.svg',
  }
}

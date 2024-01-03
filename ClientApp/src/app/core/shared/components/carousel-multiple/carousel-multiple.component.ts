import {AfterViewInit, Component, Input} from '@angular/core';
import {Card} from "@core/interfaces/card";

@Component({
  selector: 'app-carousel-multiple',
  templateUrl: './carousel-multiple.component.html',
  styleUrl: './carousel-multiple.component.sass',
})
export class CarouselMultipleComponent implements AfterViewInit {
  @Input() images: Card[] = [];
  @Input() slidesPerView = 3;

  constructor() {
  }

  ngAfterViewInit() {

  }
}

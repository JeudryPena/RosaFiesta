import {AfterViewInit, Component, Input} from '@angular/core';
import {Card} from "@core/interfaces/card";

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.sass']
})
export class CarouselComponent implements AfterViewInit {
  @Input() images: Card[] = [];

  constructor() {
  }

  ngAfterViewInit() {

  }
}

import {AfterViewInit, Component, ElementRef, Input, OnInit, ViewChild} from '@angular/core';
import {SwiperContainer} from "swiper/swiper-element";
import {Card} from "@core/interfaces/card";
import {SwiperOptions} from "swiper/types";

@Component({
  selector: 'app-carousel-thumbnails',
  templateUrl: './carousel-thumbnails.component.html',
  styleUrl: './carousel-thumbnails.component.sass'
})
export class CarouselThumbnailsComponent implements OnInit, AfterViewInit {
  @ViewChild('swiper') swiper!: ElementRef<SwiperContainer>;
  @ViewChild('swiperThumbs') swiperThumbs!: ElementRef<SwiperContainer>;

  @Input() images: Card[] = [];

  index = 0;

  // Swiper
  swiperConfig: SwiperOptions = {
    spaceBetween: 10,
    navigation: true,
  }

  swiperThumbsConfig: SwiperOptions = {
    spaceBetween: 10,
    slidesPerView: 4,
    freeMode: true,
    watchSlidesProgress: true,
  }

  ngOnInit() {

  }

  ngAfterViewInit() {
    this.swiper.nativeElement.swiper.activeIndex = this.index;
    this.swiperThumbs.nativeElement.swiper.activeIndex = this.index;
  }

  slideChange(swiper: any) {
    this.index = swiper.detail[0].activeIndex;
  }
}

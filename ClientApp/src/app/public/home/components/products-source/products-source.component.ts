import {Component, OnInit} from '@angular/core';
import {Card} from "@core/interfaces/card";

@Component({
  selector: 'app-products-source',
  templateUrl: './products-source.component.html',
  styleUrl: './products-source.component.sass'
})
export class ProductsSourceComponent implements OnInit {
  images: Card[] = [];

  constructor() {
  }

  ngOnInit() {
    this.images = [
      {
        title: 'Computer',
        description: 'Description about computer...',
        url: 'assets/img/banner.png',
      },
      {
        title: 'Building',
        description: 'Building description...',
        url: 'assets/img/banner2.jpg',
      },
      {
        title: 'Glass over a computer',
        description: 'Description of a glass over a computer',
        url: 'assets/img/inquiry-img.jpg',
      },
      {
        title: 'Computer',
        description: 'Description about computer...',
        url: 'assets/img/banner.png',
      },
      {
        title: 'Building',
        description: 'Building description...',
        url: 'assets/img/banner2.jpg',
      },
      {
        title: 'Glass over a computer',
        description: 'Description of a glass over a computer',
        url: 'assets/img/inquiry-img.jpg',
      },
      {
        title: 'Computer',
        description: 'Description about computer...',
        url: 'assets/img/banner.png',
      },
      {
        title: 'Building',
        description: 'Building description...',
        url: 'assets/img/banner2.jpg',
      },
      {
        title: 'Glass over a computer',
        description: 'Description of a glass over a computer',
        url: 'assets/img/inquiry-img.jpg',
      }
    ]
  }
}

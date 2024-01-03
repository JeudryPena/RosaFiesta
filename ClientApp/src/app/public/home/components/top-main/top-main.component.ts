import {Component, OnInit} from '@angular/core';
import {Card} from "@core/interfaces/card";

@Component({
  selector: 'app-top-main',
  templateUrl: './top-main.component.html',
  styleUrl: './top-main.component.sass'
})
export class TopMainComponent implements OnInit {

  images: Card[] = [];
  thumbImages: Card[] = [];

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
      }
    ]
  }


}

import { Component } from '@angular/core';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent {
  url: string = "assets/backgrounds/loginBG.jpg";
  imageChange(event: any) {
    this.url = event.target.src;
  }
}

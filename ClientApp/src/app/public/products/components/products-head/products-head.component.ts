import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-products-head',
  templateUrl: './products-head.component.html',
  styleUrl: './products-head.component.sass'
})
export class ProductsHeadComponent {
  @Input() total = 0;

  @Input() categoryName: string;
}

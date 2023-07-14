import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {
  colorCode = "#ff0000";
  tuhna = '0 0 0 2px #fff, 0 0 0 4px #ff0000';
  isActive = true;
  rating: number = 3.5;

  images = [
    'https://via.placeholder.com/400x300',
    'https://via.placeholder.com/400x300',
    'https://via.placeholder.com/400x300',
    'https://via.placeholder.com/400x300',
  ];

  ngOnInit(): void {

  }
}

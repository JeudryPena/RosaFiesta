import { Component, OnInit } from '@angular/core';
import { ProductDetailResponse } from '../../interfaces/Product/Response/productDetailResponse';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoriesService } from '../../shared/services/categories.service';
import { DiscountsService } from '../../shared/services/discounts.service';
import { ReviewsService } from '../../shared/services/reviews.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

  product$!: Observable<ProductDetailResponse>;
  colorCode = "#ff0000";
  tuhna = '0 0 0 2px #fff, 0 0 0 4px #ff0000';
  isActive = true;
  rating: number = 3.5;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private categoryService: CategoriesService,
    private reviewService: ReviewsService,
    private discountService: DiscountsService
  ) { 
    
  } 

  images = [
    'https://via.placeholder.com/400x300',
    'https://via.placeholder.com/400x300',
    'https://via.placeholder.com/400x300',
    'https://via.placeholder.com/400x300',
  ];

  ngOnInit(): void {

  }
}

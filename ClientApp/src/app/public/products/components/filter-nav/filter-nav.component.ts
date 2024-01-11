import {Component, EventEmitter, Input, Output} from '@angular/core';
import {CategoryPreviewResponse} from "@core/interfaces/Product/category";
import {encrypt} from "@core/shared/util/util-encrypt";
import {Router} from "@angular/router";

@Component({
  selector: 'app-filter-nav',
  templateUrl: './filter-nav.component.html',
  styleUrl: './filter-nav.component.sass'
})
export class FilterNavComponent {

  @Input() selectedCondition: string;
  conditions: string[] = ['Nuevo', 'Usado', 'Restaurado'];

  @Input() selectedRating: number;
  ratings: number[] = [1, 2, 3, 4, 5];

  @Input() startValue = 0;
  @Input() endValue = 0;
  step = 100;
  max = 10000;
  min = 0;

  @Input() categories: CategoryPreviewResponse[];
  @Input() selectedCategory: CategoryPreviewResponse;

  @Output() selectRatingEvent: EventEmitter<number> = new EventEmitter<number>();
  @Output() selectStartPriceEvent: EventEmitter<number> = new EventEmitter();
  @Output() selectEndPriceEvent: EventEmitter<number> = new EventEmitter();
  @Output() selectConditionEvent: EventEmitter<string> = new EventEmitter<string>();

  constructor(
    private readonly router: Router
  ) {
  }

  selectCategory(categoryId: number) {
    const data = {id: categoryId};
    const encryptedCategoryId = encrypt(JSON.stringify(data));
    this.router.navigate([`/products/search`], {queryParams: {categoryId: encryptedCategoryId}});
  }

  selectRating(rating: number) {
    this.selectRatingEvent.emit(rating);
  }

  selectStartPrice(start: number) {
    this.selectStartPriceEvent.emit(start);
  }

  selectEndPrice(end: number) {
    this.selectEndPriceEvent.emit(end);
  }

  selectCondition(condition: string) {
    this.selectConditionEvent.emit(condition);
  }
}

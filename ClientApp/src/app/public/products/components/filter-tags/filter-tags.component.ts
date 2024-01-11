import {Component, EventEmitter, Input, Output} from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-filter-tags',
  templateUrl: './filter-tags.component.html',
  styleUrl: './filter-tags.component.sass'
})
export class FilterTagsComponent {
  @Input() selectedCondition: string;
  @Input() selectedRating: number;
  @Input() startValue = 0;
  @Input() endValue = 0;
  @Input() categoryName: string;

  @Output() removeCondition: EventEmitter<any> = new EventEmitter<any>();
  @Output() removeRating: EventEmitter<any> = new EventEmitter<any>();
  @Output() removeStartValue: EventEmitter<any> = new EventEmitter<any>();
  @Output() removeEndValue: EventEmitter<any> = new EventEmitter<any>();

  constructor(
    private readonly router: Router
  ) {

  }

  cleanFilters() {
    if (this.categoryName) {
      this.router.navigate([`/products/search`]).then(() => {
        window.location.reload();
      });
    }
    this.selectedCondition = null;
    this.selectedRating = null;
    this.startValue = 0;
    this.endValue = 0;
  }

  removeFilter() {
    this.router.navigate([`/products/search`]).then(() => {
      window.location.reload();
    });
  }
}

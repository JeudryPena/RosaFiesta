import {Component, EventEmitter, Input, Output} from '@angular/core';
import {Router} from "@angular/router";
import {Condition} from "@core/interfaces/conditions";

@Component({
  selector: 'app-filter-tags',
  templateUrl: './filter-tags.component.html',
  styleUrl: './filter-tags.component.sass'
})
export class FilterTagsComponent {
  @Input() selectedCondition: Condition;
  @Input() selectedRating: number;
  @Input() startValue = 0;
  @Input() endValue = 0;
  @Input() categoryName: string;

  @Output() removeCondition: EventEmitter<any> = new EventEmitter<any>();
  @Output() removeRating: EventEmitter<any> = new EventEmitter<any>();
  @Output() removeRangeValue: EventEmitter<any> = new EventEmitter<any>();
  @Output() search: EventEmitter<any> = new EventEmitter<any>();
  @Output() removeCategory: EventEmitter<any> = new EventEmitter<any>();

  constructor(
    private readonly router: Router
  ) {

  }

  selectConditionValue() {
    switch (this.selectedCondition) {
      case Condition.New:
        return 'Nuevo';
      case Condition.Used:
        return 'Usado';
      case Condition.Restored:
        return 'Restaurado';
    }
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
}

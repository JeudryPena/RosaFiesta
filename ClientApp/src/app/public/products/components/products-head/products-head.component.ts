import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-products-head',
  templateUrl: './products-head.component.html',
  styleUrl: './products-head.component.sass'
})
export class ProductsHeadComponent implements OnInit {
  @Input() total = 0;

  @Input() categoryName: string;
  searchForm: FormGroup;

  @Output() search = new EventEmitter<string>();

  constructor(
    private readonly fb: FormBuilder,
  ) {
  }

  ngOnInit(): void {
    this.searchForm = this.fb.group({
      search: [''],
    });
  }

  searchProducts(searchFormValue: any) {
    const searchForm = {...searchFormValue};
    this.search.emit(searchForm.search);
  }
}

import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {
  NgbDatepickerModule,
  NgbDropdownModule,
  NgbModalModule,
  NgbModule,
  NgbPaginationModule,
  NgbTooltipModule,
  NgbTypeaheadModule
} from "@ng-bootstrap/ng-bootstrap";
import {NgbdSortableHeader} from "@core/shared/directives/sortable.directive";


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    NgbDropdownModule,
    NgbTooltipModule,
    NgbPaginationModule,
    NgbModule,
    NgbdSortableHeader,
    NgbTypeaheadModule,
    NgbModalModule,
    NgbDatepickerModule
  ],
  exports: [
    NgbDropdownModule,
    NgbTooltipModule,
    NgbPaginationModule,
    NgbModule,
    NgbdSortableHeader,
    NgbTypeaheadModule,
    NgbModalModule,
    NgbDatepickerModule
  ]
})
export class NgBootstrapModule {
}

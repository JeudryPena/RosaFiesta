import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {MatTabsModule} from "@angular/material/tabs";
import {MatRadioModule} from '@angular/material/radio';
import {MatSliderModule} from "@angular/material/slider";
import {MatPaginatorModule} from "@angular/material/paginator";
import {MatTableModule} from "@angular/material/table";
import {MatExpansionModule} from "@angular/material/expansion";


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatTabsModule,
    MatRadioModule,
    MatSliderModule,
    MatPaginatorModule,
    MatTableModule,
    MatExpansionModule
  ],
  exports: [
    MatTabsModule,
    MatRadioModule,
    MatSliderModule,
    MatPaginatorModule,
    MatTableModule,
    MatExpansionModule
  ]
})
export class MaterialModule {
}

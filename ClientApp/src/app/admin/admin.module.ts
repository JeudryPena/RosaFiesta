import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {adminRouter} from "@admin/admin-routing.module";
import {AdminComponent} from "@admin/admin.component";

@NgModule({
  declarations: [
    AdminComponent
  ],
  imports: [
    CommonModule,
    adminRouter
  ],
  exports: [],
  providers: [],
  bootstrap: [AdminComponent]
})
export class AdminModule {
}

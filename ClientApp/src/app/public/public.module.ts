import {NgModule} from '@angular/core';
import {publicRouter} from "@public/public-routing.module";
import {PublicComponent} from '@public/public.component';
import {SharedModule} from "@core/shared/shared.module";

@NgModule({
  declarations: [
    PublicComponent
  ],
  imports: [
    SharedModule,
    publicRouter
  ],
  exports: [],
  providers: [],
  bootstrap: [PublicComponent]
})
export class PublicModule {
}

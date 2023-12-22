import {NgModule} from '@angular/core';
import {publicRouter} from "@public/public-routing.module";
import {PublicComponent} from '@public/public.component';
import {SharedModule} from "@core/shared/shared.module";
import {ReactiveFormsModule} from "@angular/forms";

@NgModule({
    declarations: [
        PublicComponent
    ],
    imports: [
        publicRouter,
        SharedModule,
        ReactiveFormsModule
    ],
    exports: [
        SharedModule,
        ReactiveFormsModule
    ],
    providers: []
})
export class PublicModule {
}

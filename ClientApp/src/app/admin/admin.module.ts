import {NgModule} from '@angular/core';
import {adminRouter} from "@admin/admin-routing.module";
import {AdminComponent} from "@admin/admin.component";
import {SharedModule} from "@core/shared/shared.module";

@NgModule({
    declarations: [
        AdminComponent
    ],
    imports: [
        adminRouter,
        SharedModule,
    ],
    exports: [
        SharedModule
    ],
    providers: []
})
export class AdminModule {
}

import {RouterModule, Routes} from '@angular/router';
import {AboutUsComponent} from "@public/home/containers/about-us/about-us.component";
import {ModuleWithProviders} from "@angular/core";
import {BodyComponent} from "@core/shared/components/layout/body/body.component";
import {HomeComponent} from "@public/home/home.component";

const routes: Routes = [
    {
        path: '', component: HomeComponent, children: [
            {path: '', component: BodyComponent},
            {path: 'about-us', component: AboutUsComponent}
        ]
    }

];

export const homeRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

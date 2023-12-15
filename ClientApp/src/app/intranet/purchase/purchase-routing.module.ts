import {ModuleWithProviders} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {PurchaseComponent} from "../purchase/purchase.component";

const routes: Routes = [
  {path: '', component: PurchaseComponent}
];

export const purchaseRouter: ModuleWithProviders<RouterModule> = RouterModule.forChild(routes);

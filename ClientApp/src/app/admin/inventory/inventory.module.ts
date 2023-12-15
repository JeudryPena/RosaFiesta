import {NgModule} from '@angular/core';
import {inventoryRouter} from "@admin/inventory/inventory-routing.module";
import {InventoryComponent} from "@admin/inventory/inventory.component";
import {DownloadComponent} from "@admin/inventory/components/download/download.component";
import {ModalCategoryComponent} from "@admin/inventory/components/modal-category/modal-category.component";
import {ModalDiscountComponent} from "@admin/inventory/components/modal-discount/modal-discount.component";
import {ModalProductComponent} from "@admin/inventory/components/modal-product/modal-product.component";
import {ModalSuppliersComponent} from "@admin/inventory/components/modal-suppliers/modal-suppliers.component";
import {ModalUserComponent} from "@admin/inventory/components/modal-user/modal-user.component";
import {UploadImagesComponent} from "@admin/inventory/components/upload-images/upload-images.component";
import {
  ManagementCategoriesComponent
} from "@admin/inventory/containers/management-categories/management-categories.component";
import {
  ManagementDiscountsComponent
} from "@admin/inventory/containers/management-discounts/management-discounts.component";
import {
  ManagementProductsComponent
} from "@admin/inventory/containers/management-products/management-products.component";
import {
  ManagementSuppliersComponent
} from "@admin/inventory/containers/management-suppliers/management-suppliers.component";
import {ManagementUsersComponent} from "@admin/inventory/containers/management-users/management-users.component";
import {
  ManagementWarrantiesComponent
} from "@admin/inventory/containers/management-warranties/management-warranties.component";
import {ModalWarrantyComponent} from "@admin/inventory/components/modal-warranty/modal-warranty.component";

@NgModule({
  declarations: [
    InventoryComponent,
    DownloadComponent,
    ModalCategoryComponent,
    ModalDiscountComponent,
    ModalProductComponent,
    ModalSuppliersComponent,
    ModalUserComponent,
    ModalWarrantyComponent,
    UploadImagesComponent,
    ManagementCategoriesComponent,
    ManagementDiscountsComponent,
    ManagementProductsComponent,
    ManagementSuppliersComponent,
    ManagementUsersComponent,
    ManagementWarrantiesComponent
  ],
  imports: [
    inventoryRouter
  ],
  exports: [],
  providers: [],
  bootstrap: [InventoryComponent]
})
export class InventoryModule {
}

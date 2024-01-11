import {Component, Input} from '@angular/core';
import {WarrantyResponse} from "@core/interfaces/Product/Response/warrantyResponse";

@Component({
  selector: 'app-detail-warranty-tab',
  templateUrl: './detail-warranty-tab.component.html',
  styleUrl: './detail-warranty-tab.component.sass'
})
export class DetailWarrantyTabComponent {
  @Input() warranty: WarrantyResponse
}

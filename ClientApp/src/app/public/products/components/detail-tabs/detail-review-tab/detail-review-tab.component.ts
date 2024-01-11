import {Component, Input, OnInit} from '@angular/core';
import {OptionPreviewResponse} from "@core/interfaces/Product/Response/optionPreviewResponse";

@Component({
  selector: 'app-detail-review-tab',
  templateUrl: './detail-review-tab.component.html',
  styleUrl: './detail-review-tab.component.sass'
})
export class DetailReviewTabComponent implements OnInit {

  @Input() options: OptionPreviewResponse[] = [];

  ngOnInit(): void {

  }

}

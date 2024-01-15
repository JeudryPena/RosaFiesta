import {Component, Input} from '@angular/core';
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-share-buttons',
  templateUrl: './share-buttons.component.html',
  styleUrl: './share-buttons.component.sass'
})
export class ShareButtonsComponent {
  @Input() title: any;
  @Input() shareUrl: string;
  @Input() productTitle: string;

  constructor(public activeModal: NgbActiveModal) {
  }

  Close() {
    this.activeModal.close();
  }
}

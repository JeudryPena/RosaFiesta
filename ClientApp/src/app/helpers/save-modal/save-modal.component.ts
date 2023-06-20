import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Status } from './status';

@Component({
  selector: 'app-save-modal',
  templateUrl: './save-modal.component.html',
  styleUrls: ['./save-modal.component.scss']
})
export class SaveModalComponent {
  @Input() title: any;
  @Input() status: Status = Status.Pending;
  saved: boolean = false;
  
  constructor(public activeModal: NgbActiveModal) { }

  Status() {
    if (this.status === Status.Pending) {
      return true;
    } else {
      return false;
    }
  }

  getIconClass() {
    if (this.status === Status.Pending) {
      return 'bi-question-circle text-warning'
    } else if (this.status === Status.Success) {
      return 'bi-check-circle text-success';
    } else if (this.status === Status.Failed) {
      return 'bi-exclamation-circle text-danger';
    } else {
      return ''
    }
  }

  Save() {
    this.saved = true;
    this.activeModal.close(this.saved);
  }

  Close() {
    this.activeModal.close();
  }
}

import { Component } from '@angular/core';
import { NgbActiveModal, NgbTimeStruct } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-time-picker',
  templateUrl: './time-picker.component.html',
  styleUrls: ['./time-picker.component.scss']
})
export class TimePickerComponent {
  time!: NgbTimeStruct;

  constructor(
    public activeModal: NgbActiveModal,
  ) { 

  }

  
}

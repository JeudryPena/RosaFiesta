import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-rounded-buttons',
  templateUrl: './rounded-buttons.component.html',
  styleUrls: ['./rounded-buttons.component.scss']
})
export class RoundedButtonsComponent {

  @Input() color!: string;
  @Input() size!: string;
  @Input() icon!: string;
  @Output() onClick = new EventEmitter();

  get classes() {
    return {
      'btn': true,
      [`btn-${this.color}`]: !!this.color,
      [`btn-${this.size}`]: !!this.size,
      'btn-icon': !!this.icon
    };
  }

}

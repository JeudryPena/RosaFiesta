import {Component, EventEmitter, Input, Output} from '@angular/core';
import {CurrentUserResponse} from "@core/interfaces/Security/Response/userResponse";

@Component({
  selector: 'app-main-sidenav',
  templateUrl: './main-sidenav.component.html',
  styleUrl: './main-sidenav.component.sass'
})
export class MainSidenavComponent {
  @Output() toggleSideNav: EventEmitter<any> = new EventEmitter<any>();
  @Output() logout: EventEmitter<any> = new EventEmitter<any>();
  @Input() user: CurrentUserResponse;

  constructor() {
  }
}

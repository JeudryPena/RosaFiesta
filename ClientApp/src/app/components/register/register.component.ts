import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  userFocused = false;
  emailFocused = false;
  passwordFocused = false;
  confirmPasswordFocused = false;
}

import { Component } from '@angular/core';

@Component({
  selector: 'app-modal-quote',
  templateUrl: './modal-quote.component.html',
  styleUrls: ['./modal-quote.component.scss']
})
export class ModalQuoteComponent {
  firstNameFocused = false;
  lastNameFocused = false;
  emailFocused = false;
  messageFocused = false;
}

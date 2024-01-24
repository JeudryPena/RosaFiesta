import {Component} from '@angular/core';
import {config} from "@env/config.dev";
import {CurrentUserResponse} from "@core/interfaces/Security/Response/userResponse";
import {AuthenticateService} from "@auth/services/authenticate.service";

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent {

  user: CurrentUserResponse;

  constructor(
    private readonly authService: AuthenticateService
  ) {
    if (this.authService.isUserAuthenticated()) {
      this.user = this.authService.currentUser();
    }
  }

  messageWhatsapp() {
    let user;
    if (this.user) {
      user = this.user;
    }
    const phone = config.whatsappNumber;

    const mensaje = `Buenas! ${user ? `soy ${user.userName}. Y` : ''} quisiera comunicarme con ustedes.`;
    const link = `https://api.whatsapp.com/send?phone=${phone}&text=${encodeURI(mensaje)}`;
    window.open(link, '_blank');
  }
}

import {Component, OnDestroy, OnInit} from '@angular/core';
import {config} from "@env/config.dev";
import {CurrentUserResponse} from "@core/interfaces/Security/Response/userResponse";
import {AuthenticateService} from "@auth/services/authenticate.service";

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.sass']
})
export class AboutUsComponent implements OnInit, OnDestroy {

  options: google.maps.MapOptions = {
    center: {lat: 40, lng: -20},
    zoom: 4
  };

  config = config;

  myClass = document.getElementById('main');
  user: CurrentUserResponse;

  constructor(private readonly authService: AuthenticateService) {

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

  ngOnInit(): void {
    this.myClass.classList.add('about-us-main');
    if (this.authService.isUserAuthenticated()) {
      this.user = this.authService.currentUser();
    }
  }

  ngOnDestroy() {
    this.myClass.classList.remove('about-us-main');
  }
}

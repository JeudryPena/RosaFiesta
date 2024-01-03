import {AfterViewInit, Component, OnInit} from '@angular/core';
import {AuthenticateService} from '@auth/services/authenticate.service';
import {register} from "swiper/element/bundle";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],

})
export class AppComponent implements OnInit, AfterViewInit {

  constructor(private authService: AuthenticateService) {

  }

  ngOnInit(): void {
    this.authService.sendAuthStateChangeNotification(true);
  }


  ngAfterViewInit(): void {
    register();
  }
}

import {Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {config} from "@env/config.dev";
import {CurrentUserResponse} from "@core/interfaces/Security/Response/userResponse";
import {AuthenticateService} from "@auth/services/authenticate.service";
import {MapInfoWindow, MapMarker} from "@angular/google-maps";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.sass']
})
export class AboutUsComponent implements OnInit, OnDestroy {
  @ViewChild(MapInfoWindow) infoWindow: MapInfoWindow;

  direction: google.maps.LatLngLiteral = {lat: 18.408969038725395, lng: -70.10919130614657};

  // markers
  markerOptions: google.maps.MarkerOptions = {draggable: false};
  markerPositions: google.maps.LatLngLiteral[] = [this.direction];

  north = this.direction.lat + 3 / 111.1;
  south = this.direction.lat - 3 / 111.1;
  east = this.direction.lng + 3 / (111.1 * Math.cos(this.direction.lat));
  west = this.direction.lng - 3 / (111.1 * Math.cos(this.direction.lat));

  // Google maps
  height = "100%"
  width = "100%"
  display: google.maps.LatLngLiteral;
  options: google.maps.MapOptions = {
    center: this.direction,
    zoom: 16,
    // gestureHandling: 'none',
    clickableIcons: true,
    keyboardShortcuts: true,
    // mapTypeId: 'satellite',
    restriction: {
      latLngBounds: {
        north: this.north,
        south: this.south,
        east: this.east,
        west: this.west
      },
      strictBounds: true
    },
  };

  config = config;
  myClass = document.getElementById('main');
  user: CurrentUserResponse;

  constructor(private readonly authService: AuthenticateService, private http: HttpClient) {

  }

  addMarker(event: google.maps.MapMouseEvent) {
    this.markerPositions.push(event.latLng.toJSON());
  }

  openInfoWindow(marker: MapMarker) {
    console.log(marker)
    this.infoWindow.open(marker);
  }

  moveMap(event: google.maps.MapMouseEvent) {
    this.options.center = (event.latLng.toJSON());
  }

  move(event: google.maps.MapMouseEvent) {
    this.display = event.latLng.toJSON();
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

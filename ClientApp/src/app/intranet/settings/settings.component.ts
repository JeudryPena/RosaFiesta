import {Component, OnInit} from '@angular/core';
import {AuthenticateService} from "@auth/services/authenticate.service";
import {UserResponse} from "@core/interfaces/Security/Response/userResponse";
import {Observable} from "rxjs";
import {SwalService} from "@core/shared/services/swal.service";
import {SweetAlertOptions} from "sweetalert2";

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.sass']
})
export class SettingsComponent implements OnInit {

  $user: Observable<UserResponse>;
  swalOptions: SweetAlertOptions = {icon: 'info'};

  constructor(
    private authService: AuthenticateService,
    private swalService: SwalService
  ) {

  }

  ngOnInit(): void {
    this.Authenticate();
  }

  changePromotionalPreference() {
    this.authService.changePromotionalPreference().subscribe({
      next: () => {
        this.swalOptions.icon = 'success';
        this.swalOptions.html = 'Se ha cambiado la preferencia de recibir promociones correctamente';
        this.swalOptions.title = 'Preferencia Cambiada';
        this.swalService.show(this.swalOptions);
      },
      error: err => {
        this.swalService.error();
        console.error(err);
      }
    });
  }

  Authenticate() {
    if (this.authService.isUserAuthenticated()) {
      this.$user = this.authService.getCurrentDetailUser();
    }
  }
}

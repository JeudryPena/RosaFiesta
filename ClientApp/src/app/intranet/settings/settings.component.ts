import {Component, OnInit} from '@angular/core';
import {AuthenticateService} from "@auth/services/authenticate.service";
import {UserResponse} from "@core/interfaces/Security/Response/userResponse";
import {Observable} from "rxjs";
import Swal from "sweetalert2";
import {Router} from "@angular/router";

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.sass']
})
export class SettingsComponent implements OnInit {

  $user: Observable<UserResponse>;

  constructor(
    private authService: AuthenticateService,
    private router: Router
  ) {

  }

  ngOnInit(): void {
    this.Authenticate();
  }

  deleteMyAccount() {
    Swal.fire({
      icon: 'question',
      title: 'Eliminar Usuario',
      html: `Esta seguro de que desea eliminar su usuario? esta acción no se puede deshacer`,
      showConfirmButton: true,
      showCancelButton: true
    }).then((result) => {
      if (result.isConfirmed) {
        this.authService.deleteMyAccount().subscribe({
          next: () => {
            Swal.fire({
              icon: 'success',
              html: 'Se ha eliminado la cuenta correctamente',
              title: 'Cuenta Eliminada'
            });
            this.authService.logout();
            this.router.navigate(['/main-page']);
          },
          error: (err) => {
            Swal.fire({
              icon: 'error',
              title: 'Error',
              text: err.message
            });
            console.error(err);
          }
        });
      }
    });
  }

  changePromotionalPreference() {
    this.authService.changePromotionalPreference().subscribe({
      next: () => {
        Swal.fire({
          icon: 'success',
          html: 'Se ha cambiado la preferencia de recibir promociones correctamente',
          title: 'Preferencia Cambiada'
        });
      },
      error: err => {
        Swal.fire({
          icon: 'error',
          title: 'Error',
          text: 'No se ha podido cambiar la preferencia, porfavor contacte con el administrador'
        });
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

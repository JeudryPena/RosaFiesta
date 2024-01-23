import {Component, OnInit} from '@angular/core';
import {AuthenticateService} from "@auth/services/authenticate.service";
import {UserResponse} from "@core/interfaces/Security/Response/userResponse";
import {Observable} from "rxjs";
import {SwalConfirmItem, SwalService} from "@core/shared/services/swal.service";
import {SweetAlertOptions} from "sweetalert2";
import {Router} from "@angular/router";

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.sass']
})
export class SettingsComponent implements OnInit {

  $user: Observable<UserResponse>;
  swalOptions: SweetAlertOptions = {icon: 'info'};
  public confirmItem: SwalConfirmItem = {
    fnConfirm: this.confirmDelete,
    confirmData: null,
    context: this
  };

  constructor(
    private authService: AuthenticateService,
    private swalService: SwalService,
    private router: Router
  ) {

  }

  ngOnInit(): void {
    this.Authenticate();
  }

  deleteMyAccount() {
    this.swalOptions.icon = 'question';
    this.swalOptions.title = 'Eliminar Usuario';
    this.swalOptions.html = `Esta seguro de que desea eliminar su usuario? esta acción no se puede deshacer`;
    this.swalOptions.showConfirmButton = true;
    this.swalOptions.showCancelButton = true;
    this.confirmItem.fnConfirm = this.confirmDelete;
    this.swalService.setConfirm(this.confirmItem);
    this.swalService.show(this.swalOptions);
  }

  confirmDelete(isConfirm: string, data: any, context: any) {
    context.authService.deleteMyAccount().subscribe({
      next: () => {
        this.swalOptions.icon = 'success';
        this.swalOptions.html = 'Se ha eliminado la cuenta correctamente';
        this.swalOptions.title = 'Cuenta Eliminada';
        this.swalService.show(this.swalOptions);
        this.swalOptions.showCancelButton = false; //just need to show the OK button
        context.confirmItem.fnConfirm = null;//reset the confirm function to avoid call this function again and again.
        context.authService.logout();
        context.router.navigate(['/main-page']);
        this.swalService.setConfirm(context.confirmItem);
      },
      error: (err) => {
        this.swalService.error();
        console.error(err);
      }
    });
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

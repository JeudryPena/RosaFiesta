import {Component, OnInit} from '@angular/core';
import {AuthenticateService} from "@auth/services/authenticate.service";
import {ToastService} from "@core/services/toast.service";
import {Router} from "@angular/router";
import {FormControl, FormGroup} from "@angular/forms";
import {ChangePasswordDto} from "@core/interfaces/Security/changePasswordDto";

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {
  changeForm: any;

  constructor(
    private authService: AuthenticateService,
    private toastService: ToastService,
    private router: Router
  ) {

  }

  ngOnInit(): void {
    this.changeForm = new FormGroup({
      oldPassword: new FormControl(''),
      password: new FormControl(''),
      confirmPassword: new FormControl('')
    })
  }

  validate = (controlName: string, errorName: string) => {
    const control = this.changeForm.get(controlName);
    return control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  changePassword = (changeFormValue: any) => {
    const reset = {...changeFormValue};

    const resetPasswordDto: ChangePasswordDto = {
      oldPassword: reset.oldPassword,
      newPassword: reset.password,
      confirmPassword: reset.confirmPassword
    }
    this.authService.changePassword(resetPasswordDto)
      .subscribe({
        next: () => {
          this.toastService.show(null, 'Contraseña restablecida!', {
            classname: 'bg-success text-light',
            delay: 5000
          });
          this.router.navigate(['auth']);
        },
        error: (error) => {
          console.error(error);
          this.toastService.show('Error!', `${error}`, {classname: 'bg-danger text-light', delay: 5000});
        }
      })
  }
}

import {Component} from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {ResetPasswordDto} from '@core/interfaces/Security/resetPasswordDto';
import {AuthenticateService} from '../../services/authenticate.service';
import {ToastService} from '@core/services/toast.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent {
  passwordFocused = false;
  confirmPasswordFocused = false;
  resetForm: any;

  constructor(
    private authService: AuthenticateService,
    private toastService: ToastService,
    private router: Router,
    private route: ActivatedRoute
  ) {

    this.resetForm = new FormGroup({
      password: new FormControl(''),
      confirmPassword: new FormControl(''),
    })
  }

  validate = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.resetForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  resetPassword = (resetFormValue: any) => {
    const reset = {...resetFormValue};

    const resetPasswordDto: ResetPasswordDto = {
      password: reset.password,
      confirmPassword: reset.confirmPassword
    }
    const token = this.route.snapshot.queryParams['token'];
    const email = this.route.snapshot.queryParams['email'];
    this.authService.resetPassword(resetPasswordDto, token, email)
      .subscribe({
        next: () => {
          this.toastService.show(null, 'Contraseña restablecida!', {
            classname: 'bg - success text - light',
            delay: 5000
          });
          this.router.navigate(['authenticate']);
        },
        error: (error) => {
          this.toastService.show('Error!', `${error}`, {classname: 'bg-danger text-light', delay: 5000});
        }
      })
  }
}

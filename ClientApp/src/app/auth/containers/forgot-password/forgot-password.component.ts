import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {AuthenticateService} from '../../services/authenticate.service';
import {ToastService} from '@core/services/toast.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {
  emailFocused: boolean = false;
  forgotForm: any;

  constructor(
    private service: AuthenticateService,
    private toastService: ToastService,
  ) {
    this.forgotForm = new FormGroup({
      email: new FormControl('')
    })
  }

  ngOnInit(): void {

  }

  validate = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.forgotForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  forgotPassword(forgotFormValue: any) {
    const forgot = {...forgotFormValue};
    this.service.forgotPassword(forgot.email).subscribe({
      next: (res: any) => {
        this.toastService.show(null, 'Se ha enviado un correo electrónico para restablecer la contraseña!', {
          classname: 'bg-success text-light',
          delay: 10000
        });
      },
      error: (error: any) => {
        console.log(error);
      }
    });
  }
}

import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbDateParserFormatter, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { RegisterDto } from '../../interfaces/Security/registerDto';
import { AuthenticateService } from '../../shared/services/authenticate.service';
import { ToastService } from '../../shared/services/toast.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  userFocused = false;
  emailFocused = false;
  passwordFocused = false;
  confirmPasswordFocused = false;
  birthDateFocused = false;
  nameFocused = false;
  lastNameFocused = false;
  model!: NgbDateStruct;
  registerForm: any;

  constructor(
    private authService: AuthenticateService,
    private toastService: ToastService,
    private router: Router,
    private parserFormatter: NgbDateParserFormatter
  ) {
    this.registerForm = new FormGroup({
      email: new FormControl(''),
      userName: new FormControl(''),
      password: new FormControl(''),
      confirmPassword: new FormControl(''),
      birthDate: new FormControl(''),
      name: new FormControl(''),
      lastName: new FormControl(''),
      promotionalMails: new FormControl('')
    })
  }

  validate = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.registerForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  registerUser = (registerFormValue: any) => {
    const register = { ...registerFormValue };

    const userForRegister: RegisterDto = {
      userName: register.userName,
      name: register.name,
      lastName: register.lastName,
      promotionalMails: register.promotionalMails,
      password: register.password,
      email: register.email,
      confirmPassword: register.confirmPassword,
      birthDate: this.parserFormatter.format(register.birthDate)
    }

    this.authService.register(userForRegister)
      .subscribe({
        next: () => {
          this.toastService.show('Registro exitoso!', 'Revisa tu email para confirmarlo', { classname: 'bg - success text - light', delay: 10000 });
          this.router.navigate(['authenticate']);
        },
        error: (error) => {
          this.toastService.show('Error!', `${error}`, { classname: 'bg-danger text-light', delay: 5000 });
        }
      })
  }
}

import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginResponse } from '../../interfaces/Security/Response/loginResponse';
import { LogingDto } from '../../interfaces/Security/logingDto';
import { AuthenticateService } from '../../shared/services/authenticate.service';
import { ToastService } from '../../shared/services/toast.service';
import { RegisterDto } from '../../interfaces/Security/registerDto';
import { NgbDateParserFormatter, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

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
  model!: NgbDateStruct;
  registerForm: any;

  constructor(
    private authService: AuthenticateService,
    private toastService: ToastService,
    private router: Router,
    private parserFormatter: NgbDateParserFormatter
  ) {
    this.registerForm = new FormGroup({
      email: new FormControl('', [Validators.required]),
      userName: new FormControl('', [Validators.required]),
      password: new FormControl('', Validators.required),
      confirmPassword: new FormControl('', Validators.required),
      birthDate: new FormControl('', Validators.required)
    })
  }



  registerUser = (registerFormValue: any) => {

    if (this.registerForm.invalid) {
      this.toastService.show('Por favor, ingrese usuario y contraseña', { classname: 'bg-danger text-light', delay: 3000 });
      return;
    }

    const register = { ...registerFormValue };

    const userForRegister: RegisterDto = {
      userName: register.userName,
      password: register.password,
      email: register.email,
      confirmPassword: register.confirmPassword,
      birthDate: this.parserFormatter.format(register.birthDate)
    }

    this.authService.register(userForRegister)
      .subscribe({
        next: () => {
          this.toastService.show('Registro exitoso!', { classname: 'bg-success text-light', delay: 2000 });
          this.router.navigate(['']);
        },
        error: (error) => {
          this.toastService.show(`${error}`, { classname: 'bg-danger text-light', delay: 3000 });
        }
      })
  }
}

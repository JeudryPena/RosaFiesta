import { Component } from '@angular/core';
import { LogingDto } from '../../interfaces/Security/logingDto';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { AuthenticateService } from '../../shared/services/authenticate.service';
import { LoginResponse } from '../../interfaces/Security/Response/loginResponse';
import { ToastService } from '../../shared/services/toast.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-authenticate',
  templateUrl: './authenticate.component.html',
  styleUrls: ['./authenticate.component.css']
})
export class AuthenticateComponent {
  userFocused = false;
  passwordFocused = false;

  loginForm: any;

  constructor(
    private authService: AuthenticateService,
    private toastService: ToastService,
    private router: Router,
  ) { 
    this.loginForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', Validators.required),
      rememberMe: new FormControl(false)
    })
  }

  ngOnInit() {
    
  }

  loginUser = (loginFormValue: any) => {

    if (this.loginForm.invalid) {
      this.toastService.show('Por favor, ingrese usuario y contraseña', { classname: 'bg-danger text-light', delay: 3000 });
      return;
    }

    const login = { ...loginFormValue };

    const userForAuth: LogingDto = {
      username: login.username,
      password: login.password,
      rememberMe: login.rememberMe
    }

    this.authService.login(userForAuth)
      .subscribe({
        next: (res: LoginResponse) => {
          if (res.token && res.refreshToken && res.expiration) {
            this.toastService.show('Ingreso exitoso!', { classname: 'bg-success text-light', delay: 2000 });
            localStorage.setItem("token", res.token);
            const refreshToken = res.refreshToken;
            localStorage.setItem("refreshToken", refreshToken);
            localStorage.setItem('expiration', res.expiration);
            this.authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
            this.router.navigate(['']);
          }
        },
        error: (error: HttpErrorResponse) => {
          console.log(error.error);
          this.toastService.show(`${error.error}`, { classname: 'bg-danger text-light', delay: 3000 });
        }
      })
  }
}

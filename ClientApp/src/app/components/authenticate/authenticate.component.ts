import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginResponse } from '../../interfaces/Security/Response/loginResponse';
import { LogingDto } from '../../interfaces/Security/logingDto';
import { AuthenticateService } from '../../shared/services/authenticate.service';
import { ToastService } from '../../shared/services/toast.service';
import { ExternalAuthDto } from '../../interfaces/Security/external-auth-dto';
import { GoogleLoginProvider } from "@abacritt/angularx-social-login";
import { config } from '../../env/config.dev';

declare const FB: any;

@Component({
  selector: 'app-authenticate',
  templateUrl: './authenticate.component.html',
  styleUrls: ['./authenticate.component.css']
})
export class AuthenticateComponent implements OnInit {
  userFocused = false;
  passwordFocused = false;
  loginProvider: any; 

  loginForm: any;

  constructor(
    private authService: AuthenticateService,
    private toastService: ToastService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.loginForm = new FormGroup({
      username: new FormControl(''),
      password: new FormControl(''),
      rememberMe: new FormControl(false)
    })
    this.loginProvider = config.googleClientId;
  }

  validate = (controlName: string, errorName: string, isFocused: boolean) => {
    const control = this.loginForm.get(controlName);
    return isFocused == false && control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }

  loginFacebook() {
    FB.login(function (response) {
      if (response.status === 'connected') {

      } else {

      }
    });
  }

  logoutFacebook() {
    FB.logout(function (response) {
      
    });
  }
  
  checkLoginState() {
    FB.getLoginStatus(function (response) {
      // statusChangeCallback(response);
      console.log(response)
    });
  }

  ngOnInit() {
    this.checkLoginState();
    const token = this.route.snapshot.queryParams['token'];
    if (token) {
      const email = this.route.snapshot.queryParams['email'];
      this.authService.confirmEmail(token, email).subscribe({
        next: (res: any) => {
          this.toastService.show('Email confirmado!', 'Ya puedes proceder a identificarte', { classname: 'bg-success text-light', delay: 6000 });
        }, error: (error: HttpErrorResponse) => {
          this.toastService.show('Error!', `${error.error}`, { classname: 'bg-danger text-light', delay: 3000 });
        }
      })
    }
  }

  loginUser = (loginFormValue: any) => {
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
            this.authService.isExternalAuth = false;
            this.toastService.show(null, 'Ingreso exitoso!', { classname: 'bg-success text-light', delay: 2000 });
            localStorage.setItem("token", res.token);
            localStorage.setItem("refreshToken", res.refreshToken);
            localStorage.setItem('expiration', res.expiration);
            this.authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
            this.router.navigate(['']);
          }
        },
        error: (error) => {
          console.log(error);
          this.toastService.show('Error', `${error}`, { classname: 'bg-danger text-light', delay: 5000 });
        }
      })
  }
}

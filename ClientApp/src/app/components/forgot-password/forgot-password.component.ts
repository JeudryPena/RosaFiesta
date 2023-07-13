import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AuthenticateService } from '../../shared/services/authenticate.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent  implements OnInit {
  emailFocused: boolean = false;
  forgotForm: any;

  constructor(
    private service: AuthenticateService,
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
    const forgot = { ...forgotFormValue };
    
    this.service.forgotPassword(forgot.email).subscribe({
      next: (res: any) => {
        console.log(res);
      },
      error: (error: any) => {
        console.log(error);
      }
    });
  }
}

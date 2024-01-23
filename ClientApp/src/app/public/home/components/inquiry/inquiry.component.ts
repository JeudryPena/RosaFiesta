import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {AuthenticateService} from "@auth/services/authenticate.service";
import {CurrentUserResponse} from "@core/interfaces/Security/Response/userResponse";
import {config} from "@env/config.dev";
import {QuotesService} from "@intranet/services/quotes.service";
import {SwalService} from "@core/shared/services/swal.service";
import {SweetAlertOptions} from "sweetalert2";
import {QuoteDto} from "@core/interfaces/Enterprise/quoteDto";

@Component({
  selector: 'app-inquiry',
  templateUrl: './inquiry.component.html',
  styleUrl: './inquiry.component.sass'
})
export class InquiryComponent implements OnInit {

  formGroup: FormGroup
  user: CurrentUserResponse;
  swalOptions: SweetAlertOptions = {icon: 'info'};

  constructor(
    private readonly fb: FormBuilder,
    private readonly authService: AuthenticateService,
    private readonly quoteService: QuotesService,
    private readonly swalService: SwalService
  ) {

  }

  ngOnInit(): void {
    this.formGroup = this.fb.group({
      fullName: [''],
      eventName: [''],
      email: ['']
    });
    if (this.authService.isUserAuthenticated()) {
      this.user = this.authService.currentUser();
    }
  }

  makeQuote(formValue: any) {
    const value = {...formValue}
    const quote: QuoteDto = {
      fullName: value.fullName,
      eventName: value.eventName,
      email: value.email
    }

    this.quoteService.makeQuote(quote).subscribe({
      next: () => {
        this.formGroup.reset();
        this.messageWhatsapp(quote);
      },
      error: (err) => {
        this.swalService.error();
        console.error(err)
      }
    });
  }

  messageWhatsapp(quote: QuoteDto) {
    const phone = config.whatsappNumber;
    const mensaje = `Buenas! Soy ${quote.fullName}. Y me gustaria solicitar una cotización. El evento es '${quote.eventName}.'`;
    const link = `https://api.whatsapp.com/send?phone=${phone}&text=${encodeURI(mensaje)}`;
    window.open(link, '_blank');
  }

  validate = (controlName: string, errorName: string) => {
    const control = this.formGroup.controls[controlName];
    return control.invalid && control.dirty && control.touched && control.hasError(errorName);
  }
}

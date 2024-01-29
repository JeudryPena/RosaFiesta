import {Injectable} from '@angular/core';
import {SweetAlertOptions} from "sweetalert2";
import {Subject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class SwalService {
  swalOptions: SweetAlertOptions = {icon: 'info'}

  private swalSource = new Subject<SweetAlertOptions>();
  swalEmitted = this.swalSource.asObservable();

  private swalCloseSource = new Subject<boolean>();
  swalCloseEmitted$ = this.swalCloseSource.asObservable();
  private swalConfirmSource = new Subject<SwalConfirmItem>();
  swalConfirmEmitted$ = this.swalConfirmSource.asObservable();


  constructor() {
  }

  show(options: SweetAlertOptions) {
    this.swalSource.next(options);
  }

  close() {
    this.swalCloseSource.next(true);
  }

  // Set the confirm event
  setConfirm(confirmItem: SwalConfirmItem) {
    this.swalConfirmSource.next(confirmItem);
  }

  // Handle the HttpErrorResponse and show the error box
  showErrors(error: any, options: SweetAlertOptions) {
    console.error('%c [ error ]-37', 'font-size:13px; background:pink; color:#bf2c9f;', error);
    options.icon = 'error';
    this.swalSource.next(options);
  }

  ngOnDestroy() {
    //Complete and release the subject
    this.swalSource.complete();
    this.swalCloseSource.complete();
    this.swalConfirmSource.complete();
  }

  error() {
    this.swalOptions.icon = 'error';
    this.swalOptions.html = 'Favor de contactar con el administrador';
    this.swalOptions.title = 'Hubo un error';
    this.show(this.swalOptions);
  }
}

/**
 * Handle confirm action and data
 */
export interface SwalConfirmItem {
  //the confirm handler function
  fnConfirm: any;
  //The data needs to be passed to the confirm function
  confirmData: any;
  //the current context of the component
  context: any;
}

import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {AuthenticateService} from '@auth/services/authenticate.service';
import {register} from "swiper/element/bundle";
import {SweetAlertOptions} from "sweetalert2";
import {SwalComponent} from "@sweetalert2/ngx-sweetalert2";
import {SwalService} from "@core/shared/services/swal.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],

})
export class AppComponent implements OnInit, AfterViewInit {
  isSwalVisible = false;
  swalConfirmData: any;
  swalComponentContext: any;

  @ViewChild(SwalComponent) swalBox!: SwalComponent;
  swalOptions: SweetAlertOptions = {};

  constructor(
    private authService: AuthenticateService,
    private swalService: SwalService
  ) {
    //fire the swal from child component
    this.swalService.swalEmitted.subscribe(options => {
      if (!this.swalBox) {
        //just wait for the time to load the object if can't find it
        setTimeout(() => {
          if (this.swalBox) {
            this.isSwalVisible = true;
            this.swalBox.update(options);
            this.swalBox.fire();
          }
        }, 500);
      } else {
        this.isSwalVisible = true;
        this.swalBox.update(options);
        this.swalBox.fire();
      }
    });
    //set the confirm function and execute the login in the child component
    this.swalService.swalConfirmEmitted$.subscribe(confirmItem => {
      this.handleConfirm = confirmItem.fnConfirm == null ? this.resetHandleConfirm : confirmItem.fnConfirm;

      this.swalConfirmData = confirmItem.confirmData;
      this.swalComponentContext = confirmItem.context;
    });
    //handle close the swal event
    this.swalService.swalCloseEmitted$.subscribe(item => {
      this.swalBox.close();
    });


  }

  handleConfirm(item: string, data: any, context: any): void {
    //this will be overwrite by this.swalService.swalConfirmEmitted$
  }

  //just for reset(remove) the existing handle confirm function
  resetHandleConfirm(item: string, data: any, context: any): void {
    //this will be overwrite by this.swalService.swalConfirmEmitted$
  }

  ngOnInit(): void {
    this.authService.sendAuthStateChangeNotification(true);
  }


  ngAfterViewInit(): void {
    register();
  }
}

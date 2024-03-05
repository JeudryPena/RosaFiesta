import {Component, EventEmitter, OnInit} from '@angular/core';
import {MatDatepickerInputEvent} from "@angular/material/datepicker";
import {DatePipe} from "@angular/common";
import {lastValueFrom, Observable} from "rxjs";
import {PurchaseService} from "@intranet/services/purchase.service";
import {DateAdapter, MAT_DATE_LOCALE} from "@angular/material/core";
import {MonthPickAdapter} from "@core/classes/month-pick-adapter";
import {Platform} from "@angular/cdk/platform";
import {AnalyticDataResponse} from "@core/interfaces/Product/Response/MostPurchasedProductsResponse";
import {FilesService} from "@core/shared/services/files.service";
import {AuthenticateService} from "@auth/services/authenticate.service";
import Swal from "sweetalert2";

@Component({
  selector: 'app-analytics',
  templateUrl: './analytics.component.html',
  styleUrl: './analytics.component.sass',
  providers: [
    {
      provide: DateAdapter,
      useClass: MonthPickAdapter,
      deps: [MAT_DATE_LOCALE, Platform],
    },
  ],
})
export class AnalyticsComponent implements OnInit {

  multi: any[] = [];
  public start: Date | null = null;
  public end: Date | null = null;
  public monthAndYearChange = new EventEmitter<Date | null>();
  minDate: Date;
  maxDate: Date;
  orderComparative = [];
  analyticData: AnalyticDataResponse;
  userName: string;
  observable: Observable<any>;

  constructor(
    private readonly purchaseService: PurchaseService,
    private readonly fileService: FilesService,
    private readonly authenticateService: AuthenticateService
  ) {
  }

  public emitDateChange(event: MatDatepickerInputEvent<Date | null, unknown>): void {
    this.monthAndYearChange.emit(event.value);
  }

  public endMonthChanged(value: any, widget: any): void {
    this.end = value;
    this.end.setDate(new Date().getDate())
    widget.close();
    this.datesChoosed();
  }

  public startMonthChanged(value: any, widget: any): void {
    this.start = value;
    this.start.setDate(new Date().getDate())
    widget.close();
    this.datesChoosed();
  }

  datesChoosed() {
    if (this.start && this.end) {
      this.retrieveData();
    }
  }

  retrieveData() {
    const startDate = new DatePipe('en-US');
    const endDate = new DatePipe('en-US');
    const start = startDate.transform(this.start, 'yyyy-MM-dd');
    const end = endDate.transform(this.end, 'yyyy-MM-dd');
    this.start.toISOString();

    const productsWithDateobservable = this.purchaseService.retrieveMostPurchasedProductsWithDates(start, end);
    const compareOrdersObservable = this.purchaseService.retrieveOrderComparative(start, end);
    const analyticDataObservable = this.purchaseService.retrieveAnalyticData(start, end);

    const productsWithDateResponse = lastValueFrom(productsWithDateobservable);
    const compareOrdersResponse = lastValueFrom(compareOrdersObservable);
    const analyticDataResponse = lastValueFrom(analyticDataObservable);

    productsWithDateResponse.catch((error) => {
      console.error(error);
    });
    compareOrdersResponse.catch((error) => {
      console.error(error);
    });
    analyticDataResponse.catch((error) => {
      console.error(error);
    });

    productsWithDateResponse.then((response) => {
      this.multi = response;
    });
    compareOrdersResponse.then((response) => {
      const orderComparative = [];

      orderComparative.push(response.orders);
      orderComparative.push(response.quotes);
      orderComparative.push(response.notPurchased);
      orderComparative.push(response.refunds);

      this.orderComparative = orderComparative;
    });
    analyticDataResponse.then((response) => {
      this.analyticData = response;
    });
    this.observable = productsWithDateobservable;
  }

  ngOnInit(): void {
    this.maxDate = new Date();
    this.minDate = new Date();
    this.minDate.setMonth(this.maxDate.getMonth() - 10);
    this.start = new Date();
    this.start.setMonth(this.start.getMonth() - 3)
    this.end = this.maxDate;
    this.retrieveData();
    if (this.authenticateService.isUserAuthenticated()) {
      const user = this.authenticateService.currentUser();
      this.userName = user.userName;
    }
  }

  generateReport() {
    if (this.start == null || this.end == null || this.analyticData == null || this.orderComparative.length == 0 || this.multi.length == 0 || this.userName == null) {
      Swal.fire({
        title: 'No se pudo generar el reporte',
        text: 'Es necesario que haya data encontrada en las fechas designadas',
        icon: 'error'
      })
      return;
    }
    this.fileService.generateReport(this.start, this.end, this.analyticData, this.orderComparative, this.multi, this.userName);
  }
}

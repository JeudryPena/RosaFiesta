import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormBuilder} from "@angular/forms";
import {Platform} from "@angular/cdk/platform";
import {DateAdapter, MAT_DATE_LOCALE} from "@angular/material/core";
import {MatDatepickerInputEvent} from "@angular/material/datepicker";
import {MonthPickAdapter} from "@core/classes/month-pick-adapter";
import {PurchaseService} from "@intranet/services/purchase.service";
import {DatePipe} from "@angular/common";

@Component({
  selector: 'app-stacked-area-chart',
  templateUrl: './stacked-area-chart.component.html',
  styleUrls: ['./stacked-area-chart.component.scss'],
  providers: [
    {
      provide: DateAdapter,
      useClass: MonthPickAdapter,
      deps: [MAT_DATE_LOCALE, Platform],
    },
  ],
})
export class StackedAreaChartComponent implements OnInit {

  @Input()
  public start: Date | null = null;
  @Input()
  public end: Date | null = null;

  @Output()
  public monthAndYearChange = new EventEmitter<Date | null>();
  minDate: Date;
  maxDate: Date;
  multi = [
    {
      "name": "Germany",
      "series": [
        {
          "name": new Date("2018-01-01").toLocaleString('es-ES', {month: 'long'}),
          "value": 62000000
        },
        {
          "name": new Date("2018-02-01").toLocaleString('es-ES', {month: 'long'}),
          "value": 73000000
        },
        {
          "name": new Date("2018-03-01").toLocaleString('es-ES', {month: 'long'}),
          "value": 89400000
        }
      ]
    },

    {
      "name": "USA",
      "series": [
        {
          "name": new Date("2018-01-01").toLocaleString('es-ES', {month: 'long'}),
          "value": 250000000
        },
        {
          "name": new Date("2018-02-01").toLocaleString('es-ES', {month: 'long'}),
          "value": 309000000
        },
        {
          "name": new Date("2018-03-01").toLocaleString('es-ES', {month: 'long'}),
          "value": 311000000
        }
      ]
    },

    {
      "name": "France",
      "series": [
        {
          "name": new Date("2018-01-01").toLocaleString('es-ES', {month: 'long'}),
          "value": 58000000
        },
        {
          "name": new Date("2018-02-01").toLocaleString('es-ES', {month: 'long'}),
          "value": 50000020
        },
        {
          "name": new Date("2018-03-01").toLocaleString('es-ES', {month: 'long'}),
          "value": 58000000
        }
      ]
    },
    {
      "name": "UK",
      "series": [
        {
          "name": new Date("2018-01-01").toLocaleString('es-ES', {month: 'long'}),
          "value": 57000000
        },
        {
          "name": new Date("2018-02-01").toLocaleString('es-ES', {month: 'long'}),
          "value": 62000000
        }
      ]
    }
  ];
  view: [number, number] = [870, 600];
  // options
  legend: boolean = true;
  animations: boolean = true;
  xAxis: boolean = true;
  yAxis: boolean = true;
  showYAxisLabel: boolean = true;
  showXAxisLabel: boolean = true;
  xAxisLabel: string = 'Mes';
  yAxisLabel: string = 'Cantidades Compradas';
  timeline: boolean = true;
  colorScheme = {
    domain: ['#5AA454', '#E44D25', '#CFC0BB', '#7aa3e5', '#a8385d', '#aae3f5']
  };

  constructor(
    private readonly fb: FormBuilder,
    private readonly purchaseService: PurchaseService
  ) {

  }

  public emitDateChange(event: MatDatepickerInputEvent<Date | null, unknown>): void {
    this.monthAndYearChange.emit(event.value);
  }

  public endMonthChanged(value: any, widget: any): void {
    this.end = value;
    widget.close();
    this.datesChoosed();
  }

  public startMonthChanged(value: any, widget: any): void {
    this.start = value;
    widget.close();
    this.datesChoosed();
  }

  datesChoosed() {
    if (this.start && this.end) {
      this.retrieveData();
    }
  }

  retrieveData() {
    const start = new DatePipe('en-US');
    const end = this.end.transform(user.birthDate, 'yyyy-MM-dd').toISOString();
    this.start.toISOString();
    const response = this.purchaseService.retrieveMostPurchasedProductsWithDates(start, end);
  }

  ngOnInit(): void {
    this.maxDate = new Date();
    this.minDate.setMonth(this.maxDate.getMonth() - 6);
    this.start = this.maxDate;
    this.end = this.minDate;
  }

  onSelect(event: any) {
    console.log(event);
  }
}

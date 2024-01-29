import {Component, Input} from '@angular/core';
import {FormBuilder} from "@angular/forms";
import {PurchaseService} from "@intranet/services/purchase.service";

@Component({
  selector: 'app-stacked-area-chart',
  templateUrl: './stacked-area-chart.component.html',
  styleUrls: ['./stacked-area-chart.component.scss']
})
export class StackedAreaChartComponent {


  @Input() multi = [];
  view: [number, number] = [800, 500];
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


  onSelect(event: any) {
    console.log(event);
  }
}

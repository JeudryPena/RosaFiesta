import {Component} from '@angular/core';

@Component({
  selector: 'app-normalized-area-chart',
  templateUrl: './normalized-area-chart.component.html',
  styleUrls: ['./normalized-area-chart.component.scss']
})
export class NormalizedAreaChartComponent {
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
        },
        {
          "name": new Date("2018-03-01").toLocaleString('es-ES', {month: 'long'}),
          "value": 62000000
        }
      ]
    }
  ];
  view: [number, number] = [700, 300];

  // options
  legend: boolean = true;
  showLabels: boolean = true;
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

  onSelect(event: any) {
    console.log(event);
  }
}

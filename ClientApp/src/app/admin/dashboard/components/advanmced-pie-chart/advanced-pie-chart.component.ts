import {Component} from '@angular/core';

@Component({
    selector: 'app-advanced-pie-chart',
    templateUrl: './advanced-pie-chart.component.html',
    styleUrls: ['./advanced-pie-chart.component.scss']
})
export class AdvancedPieChartComponent {
    single = [
        {
            "name": "Germany",
            "value": 8940000
        },
        {
            "name": "USA",
            "value": 5000000
        },
        {
            "name": "France",
            "value": 7200000
        },
        {
            "name": "UK",
            "value": 6200000
        }
    ];
    view: [number, number] = [700, 400];

    // options
    gradient: boolean = true;
    showLegend: boolean = true;
    showLabels: boolean = true;
    isDoughnut: boolean = false;

    colorScheme = {
        domain: ['#5AA454', '#A10A28', '#C7B42C', '#AAAAAA']
    };

    constructor() {
        // Object.assign(this, { single });
    }

    onSelect(data: any): void {
        console.log('Item clicked', JSON.parse(JSON.stringify(data)));
    }

    onActivate(data: any): void {
        console.log('Activate', JSON.parse(JSON.stringify(data)));
    }

    onDeactivate(data: any): void {
        console.log('Deactivate', JSON.parse(JSON.stringify(data)));
    }
}

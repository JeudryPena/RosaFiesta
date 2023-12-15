import {NgModule} from '@angular/core';
import {DashboardComponent} from "@admin/dashboard/dashboard.component";
import {dashboardRouter} from "@admin/dashboard/dashboard-routing.module";
import {StatisticsComponent} from "@admin/dashboard/containers/statistics/statistics.component";
import {AdvancedPieChartComponent, AreaChartComponent, PolarChartComponent} from "@swimlane/ngx-charts";
import {BubleChartComponent} from "@admin/dashboard/components/buble-chart/buble-chart.component";
import {GaugeChartComponent} from "@admin/dashboard/components/gauge-chart/gauge-chart.component";
import {
  GroupedHorizontalBarComponent
} from "@admin/dashboard/components/grouped-horizontal-bar/grouped-horizontal-bar.component";
import {HeartChartComponent} from "@admin/dashboard/components/heart-chart/heart-chart.component";
import {
  HorizontalBarChartComponent
} from "@admin/dashboard/components/horizontal-bar-chart/horizontal-bar-chart.component";
import {LineChartComponent} from "@admin/dashboard/components/line-chart/line-chart.component";
import {LinearGaugeChartComponent} from "@admin/dashboard/components/linear-gauge-chart/linear-gauge-chart.component";
import {
  NormalizedAreaChartComponent
} from "@admin/dashboard/components/normalized-area-chart/normalized-area-chart.component";
import {
  NormalizedVerticalBarChartComponent
} from "@admin/dashboard/components/normalized-vertical-bar-chart/normalized-vertical-bar-chart.component";
import {NumberCardChartComponent} from "@admin/dashboard/components/number-card-chart/number-card-chart.component";
import {PieChartComponent} from "@admin/dashboard/components/pie-chart/pie-chart.component";
import {PieGridChartComponent} from "@admin/dashboard/components/pie-grid-chart/pie-grid-chart.component";
import {StackedAreaChartComponent} from "@admin/dashboard/components/stacked-area-chart/stacked-area-chart.component";
import {
  StackedVerticalBarChartComponent
} from "@admin/dashboard/components/stacked-vertical-bar-chart/stacked-vertical-bar-chart.component";
import {TreeMapChartComponent} from "@admin/dashboard/components/tree-map-chart/tree-map-chart.component";

@NgModule({
  declarations: [
    StatisticsComponent,
    DashboardComponent,
    AdvancedPieChartComponent,
    AreaChartComponent,
    BubleChartComponent,
    GaugeChartComponent,
    GroupedHorizontalBarComponent,
    HeartChartComponent,
    HorizontalBarChartComponent,
    LineChartComponent,
    LinearGaugeChartComponent,
    NormalizedAreaChartComponent,
    NormalizedVerticalBarChartComponent,
    NumberCardChartComponent,
    PieChartComponent,
    PieGridChartComponent,
    PolarChartComponent,
    StackedAreaChartComponent,
    StackedVerticalBarChartComponent,
    TreeMapChartComponent
  ],
  imports: [
    dashboardRouter
  ],
  exports: [],
  providers: [],
  bootstrap: [
    DashboardComponent
  ]
})
export class DashboardModule {
}

import {NgModule} from '@angular/core';
import {CommonModule, DatePipe, DecimalPipe, NgTemplateOutlet} from '@angular/common';
import {ActionDropdownComponent} from "@core/shared/components/action-dropdown/action-dropdown.component";
import {BreadcrumbComponent} from "@core/shared/components/breadcrumb/breadcrumb.component";
import {CheckboxComponent} from "@core/shared/components/checkbox/checkbox.component";
import {CloseButtonComponent} from "@core/shared/components/close-button/close-button.component";
import {DateSelectorComponent} from "@core/shared/components/date-selector/date-selector.component";
import {EnableModalComponent} from "@core/shared/components/enable-modal/enable-modal.component";
import {EnterIconComponent} from "@core/shared/components/enter-icon/enter-icon.component";
import {ExpandedButtonsComponent} from "@core/shared/components/expanded-buttons/expanded-buttons.component";
import {JumbotronComponent} from "@core/shared/components/jumbotron/jumbotron.component";
import {LoadingButtonComponent} from "@core/shared/components/loading-button/loading-button.component";
import {MenuDropdownComponent} from "@core/shared/components/menu-dropdown/menu-dropdown.component";
import {NotificationsComponent} from "@core/shared/components/notifications/notifications.component";
import {PaginationComponent} from "@core/shared/components/pagination/pagination.component";
import {RatingComponent} from "@core/shared/components/rating/rating.component";
import {RoundedButtonsComponent} from "@core/shared/components/rounded-buttons/rounded-buttons.component";
import {SaveModalComponent} from "@core/shared/components/save-modal/save-modal.component";
import {SelectListComponent} from "@core/shared/components/select-list/select-list.component";
import {TimePickerComponent} from "@core/shared/components/time-picker/time-picker.component";
import {ToastContainerComponent} from "@core/shared/components/toast-container/toast-container.component";
import {ToastGlobalComponent} from "@core/shared/components/toast-global/toast-global.component";
import {FocusDirective} from "@core/shared/directives/focus.directive";
import {IsFocusDirective} from "@core/shared/directives/is-focus.directive";
import {RatingDirective} from "@core/shared/directives/rating.directive";
import {SortableModule} from "ngx-bootstrap/sortable";
import {ImgPathPipe} from "@core/shared/pipes/img-path.pipe";
import {TruncatePipe} from "@core/shared/pipes/truncate.pipe";
import {RouterModule} from "@angular/router";
import {AdminLayoutComponent} from "@core/shared/components/layout/admin-layout/admin-layout.component";
import {InventoryLayoutComponent} from "@core/shared/components/layout/inventory-layout/inventory-layout.component";
import {BodyComponent} from "@core/shared/components/layout/body/body.component";
import {SidenavComponent} from "@core/shared/components/layout/sidenav/sidenav.component";
import {FooterComponent} from "@core/shared/components/layout/footer/footer.component";
import {NavbarComponent} from "@core/shared/components/layout/navbar/navbar.component";
import {LayoutComponent} from "@core/shared/components/layout/layout/layout.component";
import {
  NgbDatepickerModule,
  NgbDropdownModule,
  NgbModalModule,
  NgbModule,
  NgbPaginationModule,
  NgbRatingConfig,
  NgbToastModule,
  NgbTooltipModule,
  NgbTypeaheadModule
} from "@ng-bootstrap/ng-bootstrap";
import {tokenGetter} from "@root/app.module";
import {NgxPayPalModule} from "ngx-paypal";
import {FontAwesomeModule} from "@fortawesome/angular-fontawesome";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {NgxStarsModule} from "ngx-stars";
import {NgbdSortableHeader} from "@core/shared/directives/sortable.directive";
import {NgxChartsModule} from "@swimlane/ngx-charts";
import {JwtModule} from "@auth0/angular-jwt";
import {BsDatepickerModule} from "ngx-bootstrap/datepicker";
import {PopoverModule} from "ngx-bootstrap/popover";
import {TimepickerModule} from "ngx-bootstrap/timepicker";
import {TypeaheadModule} from "ngx-bootstrap/typeahead";
import {NgxFileDropModule} from "ngx-file-drop";
import {TooltipModule} from "ngx-bootstrap/tooltip";
import {
  FacebookLoginProvider,
  GoogleLoginProvider,
  GoogleSigninButtonModule,
  SocialAuthServiceConfig,
  SocialLoginModule
} from "@abacritt/angularx-social-login";
import {AvatarModule} from "ngx-avatar";
import {config} from "@env/config.dev";


@NgModule({
  declarations: [
    AdminLayoutComponent,
    InventoryLayoutComponent,
    BodyComponent,
    SidenavComponent,
    FooterComponent,
    NavbarComponent,
    LayoutComponent,
    ActionDropdownComponent,
    BreadcrumbComponent,
    CheckboxComponent,
    CloseButtonComponent,
    DateSelectorComponent,
    EnableModalComponent,
    EnterIconComponent,
    ExpandedButtonsComponent,
    JumbotronComponent,
    LoadingButtonComponent,
    MenuDropdownComponent,
    NotificationsComponent,
    PaginationComponent,
    RatingComponent,
    RoundedButtonsComponent,
    SaveModalComponent,
    SelectListComponent,
    TimePickerComponent,
    ToastContainerComponent,
    ToastGlobalComponent
  ],
  imports: [
    CommonModule,
    RouterModule,

    FontAwesomeModule,
    FormsModule,
    ReactiveFormsModule,
    NgbDropdownModule,
    NgxStarsModule,
    NgbPaginationModule,
    NgbModule,
    NgbdSortableHeader,
    NgbTypeaheadModule,
    NgbModalModule,
    CommonModule,
    NgbDatepickerModule,
    NgxChartsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:7136"],
        disallowedRoutes: []
      }
    }),
    NgbTooltipModule,
    NgbToastModule,
    NgTemplateOutlet,
    BsDatepickerModule.forRoot(),
    PopoverModule.forRoot(),
    TimepickerModule.forRoot(),
    TypeaheadModule.forRoot(),
    NgxFileDropModule,
    TooltipModule,
    SocialLoginModule,
    GoogleSigninButtonModule,
    AvatarModule,
    NgxPayPalModule
  ],
  exports: [],
  providers: [
    FocusDirective,
    IsFocusDirective,
    RatingDirective,
    SortableModule,
    ImgPathPipe,
    TruncatePipe,
    DatePipe,
    NgbRatingConfig,
    DecimalPipe,
    ImgPathPipe,

    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              `${config.googleClientId}`, {
                scopes: 'email',
              }
            )
          },
          {
            id: FacebookLoginProvider.PROVIDER_ID,
            provider: new FacebookLoginProvider(
              `${config.facebookClientId}`, {
                scope: 'email',
              }
            )
          }
        ],
        onError: (err) => {
          console.error(err);
        }
      } as SocialAuthServiceConfig
    }
  ],
  bootstrap: []
})
export class SharedModule {
}

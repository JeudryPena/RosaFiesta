/// <reference types="@angular/localize" />

import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';

import '@angular/localize/init';
import {AppModule} from '@root/app.module';


platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));

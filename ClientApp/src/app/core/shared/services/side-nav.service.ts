import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SidenavService {
  public toggleSidenav$: Subject<void> = new Subject<void>();

  constructor() { }

  toggleCollapsed(): void {
    this.toggleSidenav$.next();
  }
}

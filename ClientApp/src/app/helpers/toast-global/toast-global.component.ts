import { Component, OnDestroy } from '@angular/core';
import { ToastService } from '../../shared/services/toast.service';

@Component({
  selector: 'app-toast-global',
  templateUrl: './toast-global.component.html',
  styleUrls: ['./toast-global.component.scss'],
})
export class ToastGlobalComponent implements OnDestroy {
  constructor(public toastService: ToastService) { }

  
  ngOnDestroy(): void {
    this.toastService.clear();
  }
}

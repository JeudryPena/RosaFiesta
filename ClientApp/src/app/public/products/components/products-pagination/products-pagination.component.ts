import {AfterViewInit, Component, EventEmitter, Input, Output, ViewChild} from '@angular/core';
import {MatPaginator, PageEvent} from "@angular/material/paginator";

@Component({
  selector: 'app-products-pagination',
  templateUrl: './products-pagination.component.html',
  styleUrl: './products-pagination.component.sass'
})
export class ProductsPaginationComponent implements AfterViewInit {
  pageSizeOptions = [8, 16, 24];
  hidePageSize = false;
  showPageSizeOptions = true;
  showFirstLastButtons = true;
  disabled = false;

  @Input() pageEvent: PageEvent;
  @Input() length = 50;
  @Input() pageSize = 2;
  @Input() pageIndex = 0;
  @Output() handlePageEvent = new EventEmitter<PageEvent>();
  @Output() initializePaginator = new EventEmitter<MatPaginator>();
  @ViewChild('paginator') paginator: MatPaginator;

  handlePage(e: PageEvent) {
    this.handlePageEvent.emit(e);
  }

  ngAfterViewInit(): void {
    this.initializePaginator.emit(this.paginator);
  }
}

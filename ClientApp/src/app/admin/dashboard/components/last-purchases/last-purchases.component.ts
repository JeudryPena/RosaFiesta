import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {SweetAlertOptions} from "sweetalert2";
import {InvoiceAction} from "@core/interfaces/invoice";
import {PurchaseService} from "@intranet/services/purchase.service";
import {SwalService} from "@core/shared/services/swal.service";
import {FilesService} from "@core/shared/services/files.service";
import {OrderResponse} from "@core/interfaces/Product/UserInteract/Response/orderResponse";
import {OrderManagementPreviewResponse} from "@core/interfaces/Product/Response/OrderManagementPreviewResponse";
import {CurrentUserResponse} from "@core/interfaces/Security/Response/userResponse";

@Component({
  selector: 'app-last-purchases',
  templateUrl: './last-purchases.component.html',
  styleUrl: './last-purchases.component.sass'
})
export class LastPurchasesComponent implements OnInit {
  dataSource: MatTableDataSource<OrderManagementPreviewResponse> = new MatTableDataSource<OrderManagementPreviewResponse>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('filesTbSort') filesTbSort = new MatSort();
  @Input() user: CurrentUserResponse;

  displayedColumns: string[] = ['orderId', 'customerName', 'total', 'transactionDate', 'status', 'actions'];
  swalOptions: SweetAlertOptions = {icon: 'info'};

  invoiceAction = InvoiceAction;

  constructor(
    private readonly purchaseService: PurchaseService,
    private readonly swal: SwalService,
    private readonly fileService: FilesService
  ) {
  }

  ngOnInit(): void {
    this.retrieveData()
  }

  invoice(invoiceAction: InvoiceAction, id: string) {
    this.purchaseService.retrieveOrderDetail(id).subscribe({
      next: (order: OrderResponse) => {
        this.fileService.generatePDF(invoiceAction, order);
      },
      error: (error) => {
        this.swal.error()
        console.error(error);
      }
    });
  }

  retrieveData() {
    this.purchaseService.retrieveAllOrders(20).subscribe({
      next: (data: OrderManagementPreviewResponse[]) => {
        this.dataSource.data = data;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.filesTbSort;
      },
      error: (error) => {
        this.swal.error()
        console.error(error);
      }
    });
  }
}

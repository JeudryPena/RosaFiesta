import {Component, ViewChild} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
import {OrderManagementPreviewResponse} from "@core/interfaces/Product/Response/OrderManagementPreviewResponse";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {SweetAlertOptions} from "sweetalert2";
import {InvoiceAction} from "@core/interfaces/invoice";
import {PurchaseService} from "@intranet/services/purchase.service";
import {SwalConfirmItem, SwalService} from "@core/shared/services/swal.service";
import {FilesService} from "@core/shared/services/files.service";
import {OrderResponse} from "@core/interfaces/Product/UserInteract/Response/orderResponse";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {ModalQuoteComponent} from "@public/products/components/modal-quote/modal-quote.component";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.sass'
})
export class OrdersComponent {
  dataSource: MatTableDataSource<OrderManagementPreviewResponse> = new MatTableDataSource<OrderManagementPreviewResponse>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('filesTbSort') filesTbSort = new MatSort();
  displayedColumns: string[] = ['orderId', 'customerName', 'total', 'transactionDate', 'status', 'actions'];
  swalOptions: SweetAlertOptions = {icon: 'info'};

  invoiceAction = InvoiceAction;
  public confirmItem: SwalConfirmItem = {
    fnConfirm: this.confirmRefund,
    confirmData: null,
    context: this
  };

  constructor(
    private readonly purchaseService: PurchaseService,
    private readonly swal: SwalService,
    private readonly fileService: FilesService,
    public modalService: NgbModal
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
        this.dataSource.filterPredicate = (data: OrderManagementPreviewResponse, filter: string) => {
          const normalizedName = data.orderId
            .normalize('NFD')
            .replace(/[\u0300-\u036f]/g, '');
          const normalizedFilter = filter
            .normalize('NFD')
            .replace(/[\u0300-\u036f]/g, '');
          return normalizedName.toLowerCase().includes(normalizedFilter);
        };
      },
      error: (error) => {
        this.swal.error()
        console.error(error);
      }
    });
  }

  applyFilter(event: any) {
    let filter = (event.target as HTMLInputElement).value;
    filter = filter.trim();
    filter = filter.toLowerCase();
    this.dataSource.filter = filter;
  }

  oficialize(id: string, quoteId: string) {
    const modalRef = this.modalService.open(ModalQuoteComponent, {size: 'xl', scrollable: true});
    modalRef.componentInstance.title = 'Oficializar Cotización';
    modalRef.componentInstance.orderId = id;
    modalRef.componentInstance.id = quoteId;
  }

  refund(id) {
    this.swalOptions.icon = 'question';
    this.swalOptions.title = 'Oficializar Reembolso';
    this.swalOptions.html = `¿Esta seguro de que desea oficializar el reembolso?`;
    this.swalOptions.showConfirmButton = true;
    this.swalOptions.showCancelButton = true;
    this.confirmItem.fnConfirm = this.confirmRefund;
    this.swal.setConfirm(this.confirmItem);
    this.swal.show(this.swalOptions);
  }

  confirmRefund(isConfirm: string, data: any, context: any) {
    context.authService.deleteMyAccount().subscribe({
      next: () => {
        this.swalOptions.icon = 'success';
        this.swalOptions.html = 'Se ha realizado el reembolso correctamente';
        this.swalOptions.title = 'Cuenta Eliminada';
        this.swal.show(this.swalOptions);
        this.swalOptions.showCancelButton = false;
        context.confirmItem.fnConfirm = null;
        context.authService.logout();
        context.router.navigate(['/main-page']);
        this.swal.setConfirm(context.confirmItem);
      },
      error: (err: HttpErrorResponse) => {
        this.swal.showErrors(err, {
          icon: 'error',
          title: 'Error',
          text: err.message
        });
        console.error(err);
      }
    });
  }
}

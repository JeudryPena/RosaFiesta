import {Component, ViewChild} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
import {OrderManagementPreviewResponse} from "@core/interfaces/Product/Response/OrderManagementPreviewResponse";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {SweetAlertOptions} from "sweetalert2";
import {InvoiceAction} from "@core/interfaces/invoice";
import {PurchaseService} from "@intranet/services/purchase.service";
import {SwalService} from "@core/shared/services/swal.service";
import {FilesService} from "@core/shared/services/files.service";
import {OrderResponse} from "@core/interfaces/Product/UserInteract/Response/orderResponse";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {ModalQuoteComponent} from "@public/products/components/modal-quote/modal-quote.component";

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
}

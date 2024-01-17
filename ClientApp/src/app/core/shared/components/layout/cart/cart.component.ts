import {DecimalPipe} from '@angular/common';
import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Router} from '@angular/router';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {CartResponse} from '@core/interfaces/Product/Response/cartResponse';
import {
  PurchaseDetailOptionResponse
} from '@core/interfaces/Product/UserInteract/Response/purchaseDetailOptionResponse';
import {CartsService} from '@intranet/services/carts.service';
import {ProductsService} from '@admin/inventory/services/products.service';
import {SwalService} from "@core/shared/services/swal.service";
import {WisheslistService} from "@intranet/services/wisheslist.service";
import {SweetAlertOptions} from "sweetalert2";
import {lastValueFrom} from "rxjs";
import {DiscountsService} from "@admin/inventory/services/discounts.service";

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
  providers: [ProductsService, DecimalPipe],
})
export class CartComponent implements OnInit {
  viewCart: boolean = false;
  details: PurchaseDetailOptionResponse[] = [];
  totalPrice: number = 0;

  swalOptions: SweetAlertOptions = {icon: 'info'};

  @Input() totalItems: number = 0;
  @Output() total: EventEmitter<number> = new EventEmitter<number>();

  constructor(
    private service: CartsService,
    public modalService: NgbModal,
    private router: Router,
    private wishlistService: WisheslistService,
    private swalService: SwalService,
    private discountService: DiscountsService
  ) {
    this.service.getCart$.subscribe({
      next: () => {
        this.getCartItems();
      },
    });
  }

  ngOnInit(): void {
    this.getCartItems();
  }

  purchase() {
    this.router.navigate(['/intranet/purchase']);
  }

  addToWishList(detailId: string, optionId: string) {
    this.wishlistService.addToWishList(optionId).subscribe({
      next: () => {
        this.swalOptions.icon = 'success';
        this.swalOptions.html = 'Se ha agregado el producto a la lista de deseos correctamente';
        this.swalOptions.title = 'Producto agregado';
        this.swalService.show(this.swalOptions);
        this.deleteItem(detailId, optionId);
      },
      error: (error) => {
        this.swalService.error();
        console.error(error);
      }
    });
  }

  getCartItems() {
    this.service.getMyCart().subscribe({
      next: async (response: CartResponse) => {
        if (response.details) {
          this.viewCart = true;
          let totalItems = 0;
          let totalPrice = 0;
          let details = [];
          response.details.forEach(element => {
            element.purchaseOptions.forEach(detail => {
              details.push(detail);
              totalItems += detail.quantity;
              totalPrice += detail.option.price * detail.quantity;
            });
          });
          this.totalItems = totalItems;
          this.totalPrice = totalPrice;
          this.details = details;
          for (let option of this.details) {
            const discountResponse = this.discountService.GetOptionDiscount(option.optionId);
            const discountPromise = await lastValueFrom(discountResponse);
            if (discountPromise != null) {
              option.discount = discountPromise;
              option.offerPrice = option.unitPrice - (option.unitPrice * (discountPromise.value / 100));
            }
          }

          this.total.emit(this.totalItems);
        }
      }, error: (error) => {
        this.swalService.error();
        console.error(error);
      }
    });
  }

  OnQuantityChange(quantity: number, detailId: string, optionId: string) {
    console.log(quantity)
    this.service.verifyStock(detailId, optionId, quantity).subscribe({
      next: () => {
        this.service.UpdateQuantity(quantity, detailId, optionId).subscribe({
          next: () => {
            this.getCartItems();
          }, error: (error) => {
            this.swalService.error();
            console.error(error);
          }
        });
      }, error: (error) => {
        this.swalOptions.icon = 'error';
        this.swalOptions.html = error.error.error;
        this.swalOptions.title = 'Stock insuficiente';
        this.swalService.show(this.swalOptions);
        this.getCartItems();
        console.error(error);
      }
    });
  }

  deleteItem(detailId: string, optionId: string) {
    this.service.RemoveItem(detailId, optionId).subscribe({
      next: (response: any) => {
        this.swalOptions.icon = 'success';
        this.swalOptions.html = 'Se ha eliminado el producto a la lista de deseos correctamente';
        this.swalOptions.title = 'Producto eliminado';
        this.swalService.show(this.swalOptions);
        this.getCartItems();
      }, error: (error) => {
        this.swalService.error();
        console.error(error)
      }
    });
  }

  clearCart() {
    this.service.ClearCart().subscribe({
      next: (response: any) => {
        this.swalOptions.icon = 'success';
        this.swalOptions.html = 'Se ha vaciado el carrito correctamente';
        this.swalOptions.title = 'Carrito vaciado';
        this.swalService.show(this.swalOptions);
        this.getCartItems();
      }, error: (error) => {
        this.swalService.error();
        console.error(error);
      }
    });
  }
}

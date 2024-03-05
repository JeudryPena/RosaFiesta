import {DecimalPipe} from '@angular/common';
import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Router} from '@angular/router';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {CartResponse} from '@core/interfaces/Product/Response/cartResponse';
import {CartsService} from '@intranet/services/carts.service';
import {ProductsService} from '@admin/inventory/services/products.service';
import {WisheslistService} from "@intranet/services/wisheslist.service";
import Swal from "sweetalert2";
import {lastValueFrom} from "rxjs";
import {DiscountsService} from "@admin/inventory/services/discounts.service";
import {PurchaseDetailResponse} from "@core/interfaces/Product/UserInteract/Response/purchaseDetailResponse";

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
  providers: [ProductsService, DecimalPipe],
})
export class CartComponent implements OnInit {
  viewCart: boolean = false;
  details: PurchaseDetailResponse[] = [];
  totalPrice: number = 0;
  @Input() totalItems: number = 0;
  @Output() total: EventEmitter<number> = new EventEmitter<number>();

  constructor(
    private service: CartsService,
    public modalService: NgbModal,
    private router: Router,
    private wishlistService: WisheslistService,
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
        Swal.fire({
          icon: 'success',
          title: 'Producto agregado',
          html: 'Se ha agregado el producto a la lista de deseos correctamente',
        });
        this.deleteItem(detailId, optionId);
      },
      error: (error) => {
        Swal.fire({
          icon: 'error',
          title: 'Error',
          html: 'No se ha podido agregar el producto a la lista de deseos',
        });
        console.error(error);
      }
    });
  }

  getCartItems() {
    this.service.getMyCart().subscribe({
      next: async (response: CartResponse) => {
        if (response.details) {
          let totalItems = 0;
          let totalPrice = 0;
          for (let element of response.details) {
            for (let detail of element.purchaseOptions) {
              const discountResponse = this.discountService.GetOptionDiscount(detail.optionId);
              const discount = await lastValueFrom(discountResponse);
              totalItems += detail.quantity;
              if (discount != null) {
                detail.option.offerPrice = detail.option.price - (detail.option.price * (discount.value / 100));
                detail.option.discountValue = discount.value;
                totalPrice += detail.option.offerPrice * detail.quantity;
              } else {
                totalPrice += detail.option.price * detail.quantity;
              }
            }
          }

          this.totalItems = totalItems;
          this.totalPrice = totalPrice;
          this.details = response.details;
          this.total.emit(this.totalItems);
        }
      }, error: (error) => {
        Swal.fire({
          icon: 'error',
          title: 'Error',
          html: 'No se ha podido obtener el carrito, por favor contacte al Administrador',
        });
        console.error(error);
      }
    });
  }

  OnQuantityChange(quantity: number, detailId: string, optionId: string) {
    this.service.verifyStock(detailId, optionId, quantity).subscribe({
      next: () => {
        this.service.UpdateQuantity(quantity, detailId, optionId).subscribe({
          next: () => {
            this.getCartItems();
          }, error: (error) => {
            Swal.fire({
              icon: 'error',
              title: 'Error',
              html: 'No se ha podido actualizar la cantidad del producto, por favor contacte al Administrador',
            });
            console.error(error);
          }
        });
      }, error: (error) => {
        Swal.fire({
          icon: 'error',
          title: 'Stock insuficiente',
          html: error,
        });
        this.getCartItems();
        console.error(error);
      }
    });
  }

  deleteItem(detailId: string, optionId: string) {
    this.service.RemoveItem(detailId, optionId).subscribe({
      next: (response: any) => {
        Swal.fire({
          icon: 'success',
          title: 'Producto eliminado',
          html: 'Se ha eliminado el producto del carrito correctamente',
        });
        this.getCartItems();
      }, error: (error) => {
        Swal.fire({
          icon: 'error',
          title: 'Error',
          html: 'No se ha podido eliminar el producto del carrito, por favor contacte al Administrador',
        });
        console.error(error)
      }
    });
  }

  clearCart() {
    this.service.ClearCart().subscribe({
      next: (response: any) => {
        Swal.fire({
          icon: 'success',
          title: 'Carrito vaciado',
          html: 'Se ha vaciado el carrito correctamente',
        });
        this.getCartItems();
      }, error: (error) => {
        Swal.fire({
          icon: 'error',
          title: 'Error',
          html: 'No se ha podido vaciar el carrito, por favor contacte al Administrador',
        });
        console.error(error);
      }
    });
  }
}

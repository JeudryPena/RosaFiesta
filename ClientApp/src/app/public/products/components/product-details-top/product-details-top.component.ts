import {Component, Input, OnInit} from '@angular/core';
import {ProductDetailResponse} from "@core/interfaces/Product/Response/productDetailResponse";
import {FormControl, FormGroup} from "@angular/forms";
import {PurchaseDetailDto} from "@core/interfaces/Product/UserInteract/purchaseDetailDto";
import {CartsService} from "@intranet/services/carts.service";
import {Router} from "@angular/router";
import {encrypt} from "@core/shared/util/util-encrypt";
import {ShareButtonsComponent} from "@core/shared/components/share-buttons/share-buttons.component";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {WisheslistService} from "@intranet/services/wisheslist.service";
import Swal from "sweetalert2";

@Component({
  selector: 'app-product-details-top',
  templateUrl: './product-details-top.component.html',
  styleUrl: './product-details-top.component.sass'
})
export class ProductDetailsTopComponent implements OnInit {
  cartForm!: FormGroup;

  @Input() product: ProductDetailResponse;
  @Input() isAuthenticated = false;

  constructor(
    private readonly cartService: CartsService,
    private readonly router: Router,
    private readonly modalService: NgbModal,
    private readonly wishlistService: WisheslistService
  ) {

  }

  buyNow(cartFormValue: any) {
    if (!this.isAuthenticated) {
      Swal.fire({
        title: "Inicia sesión",
        text: "Para poder realizar una compra, debes iniciar sesión",
        icon: "info",
        showConfirmButton: true,
        showCancelButton: true,
        confirmButtonText: "Ir a inicio de sesión",
        cancelButtonText: "Cancelar"
      }).then((response) => {
        if (response.isConfirmed) {
          this.router.navigate(['/auth']);
        }
      });
      return;
    }
    const cart = {...cartFormValue};

    const cartDto: PurchaseDetailDto = {
      productId: this.product.id,
      quantity: cart.quantity,
      optionId: this.product.optionId,
      warrantyId: this.product.warranty?.id ?? null
    }

    this.cartService.AddProductToCart(cartDto).subscribe({
      next: () => {

        Swal.fire({
          title: "Producto añadido",
          text: "Se añadió el producto al carrito correctamente",
          icon: "success"
        }).then((response) => {
          if (response.isConfirmed) {
            this.router.navigate(['/intranet/purchase']);
          }
        });
        this.cartService.updatedCart();
      }, error: (err) => {
        Swal.fire({
          title: "Error",
          text: err.message,
          icon: "error"
        });
        console.error(err);
      }
    });

  }

  productDetail(productId: string, optionId: string) {
    const data = {id: productId, optionId: optionId};
    const dataEncrypted = encrypt(JSON.stringify(data));
    this.router.navigate([`/products/detail`], {queryParams: {product: dataEncrypted}}).then(
      () => {
        window.location.reload();
      }
    )
  }

  shareButtons(productTitle: string, productId: string) {
    const data = {id: productId};
    const shareUrl = window.location.origin + '/products/detail?productId=' + encrypt(JSON.stringify({id: data}));
    const modalRef = this.modalService.open(ShareButtonsComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = 'Compartir Producto';
    modalRef.componentInstance.shareUrl = shareUrl;
    modalRef.componentInstance.productTitle = productTitle;
  }

  addToWishList(optionId: string) {
    if (!this.isAuthenticated) {
      Swal.fire({
        title: "Inicia sesión",
        text: "Para poder añadir a una Lista de Deseos, debes iniciar sesión",
        icon: "info",
        showConfirmButton: true,
        showCancelButton: true,
        confirmButtonText: "Ir a inicio de sesión",
        cancelButtonText: "Cancelar"
      }).then((response) => {
        if (response.isConfirmed) {
          this.router.navigate(['/auth']);
        }
      });
      return;
    }
    this.wishlistService.addToWishList(optionId).subscribe({
      next: () => {
        Swal.fire({
          title: "Producto agregado",
          text: "Se ha agregado el producto a la lista de deseos correctamente",
          icon: "success"
        });
      },
      error: (error) => {
        Swal.fire({
          title: "Error",
          text: error.message,
          icon: "error"
        });
      }
    });
  }

  ngOnInit(): void {
    this.cartForm = new FormGroup({
      quantity: new FormControl(1)
    });
  }

  AddToCart(cartFormValue: any) {
    this.cartSubmit(cartFormValue)
  }

  cartSubmit(cartFormValue: any) {
    if (!this.isAuthenticated) {
      Swal.fire({
        title: "Inicia sesión",
        text: "Para poder añadir al carrito, debes iniciar sesión",
        icon: "info",
        showConfirmButton: true,
        showCancelButton: true,
        confirmButtonText: "Ir a inicio de sesión",
        cancelButtonText: "Cancelar"
      }).then((response) => {
        if (response.isConfirmed) {
          this.router.navigate(['/auth']);
        }
      });
      return;
    }
    const cart = {...cartFormValue};

    const cartDto: PurchaseDetailDto = {
      productId: this.product.id,
      quantity: cart.quantity,
      optionId: this.product.optionId,
      warrantyId: this.product.warranty?.id ?? null
    }

    this.cartService.AddProductToCart(cartDto).subscribe({
      next: () => {
        Swal.fire({
          title: "Producto añadido",
          text: "Se añadió el producto al carrito correctamente",
          icon: "success"
        });
        this.cartService.updatedCart();
      }, error: (err) => {
        Swal.fire({
          title: "Error",
          text: err.message,
          icon: "error"
        });
        console.error(err);
      }
    });
  }

}

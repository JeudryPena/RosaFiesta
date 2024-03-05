import {Component, Input, OnInit} from '@angular/core';
import {ProductPreviewResponse} from "@core/interfaces/Product/Response/productPreviewResponse";
import {WisheslistService} from "@intranet/services/wisheslist.service";
import {Router} from "@angular/router";
import {encrypt} from "@core/shared/util/util-encrypt";
import Swal from "sweetalert2";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {ShareButtonsComponent} from "@core/shared/components/share-buttons/share-buttons.component";
import {AuthenticateService} from "@auth/services/authenticate.service";

@Component({
  selector: 'app-product-cards',
  templateUrl: './product-cards.component.html',
  styleUrl: './product-cards.component.sass'
})
export class ProductCardsComponent implements OnInit {
  @Input() products: ProductPreviewResponse[];
  isAuthenticated: boolean;

  constructor(
    private readonly wishlistService: WisheslistService,
    private readonly router: Router,
    private readonly modalService: NgbModal,
    private readonly authService: AuthenticateService
  ) {
    this.isAuthenticated = this.authService.isUserAuthenticated();

  }

  ngOnInit(): void {
    for (let product of this.products) {
      const data = {id: product.id};
      product.shareUrl = window.location.origin + '/products/detail?productId=' + encrypt(JSON.stringify({id: data}));
    }
  }

  productDetail(productId: string, optionId: string) {
    const data = {id: productId, optionId: optionId};
    const dataEncrypted = encrypt(JSON.stringify(data));
    this.router.navigate([`/products/detail`], {queryParams: {product: dataEncrypted}});
  }

  shareButtons(shareUrl: string, productTitle: string) {
    const modalRef = this.modalService.open(ShareButtonsComponent, {size: '', scrollable: true});
    modalRef.componentInstance.title = 'Compartir Producto';
    modalRef.componentInstance.shareUrl = shareUrl;
    modalRef.componentInstance.productTitle = productTitle;
  }

  addToWishList(optionId: string) {
    if (!this.isAuthenticated) {
      Swal.fire({
        title: "Inicia sesión",
        text: "Para poder añadir un producto a la Lista de Deseos, debes iniciar sesión",
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
          title: 'Producto agregado',
          icon: 'success',
          html: 'Se ha agregado el producto a la lista de deseos correctamente'
        });
      },
      error: (error) => {
        Swal.fire({
          title: 'No se pudo agregar el producto',
          icon: 'error',
          html: error.message
        });
      }
    });
  }
}

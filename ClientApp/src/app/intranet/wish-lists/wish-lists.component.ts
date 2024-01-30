import {Component} from '@angular/core';
import {WisheslistService} from "@intranet/services/wisheslist.service";
import {catchError, lastValueFrom, map, Observable} from "rxjs";
import {Router} from "@angular/router";
import {DiscountsService} from "@admin/inventory/services/discounts.service";
import {ReviewsService} from "@intranet/services/reviews.service";
import {WishListResponse} from "@core/interfaces/Product/UserInteract/Response/wishListResponse";
import {WishListProductsResponse} from "@core/interfaces/Product/UserInteract/Response/wishListProductsResponse";
import {FormControl, FormGroup} from "@angular/forms";
import {PurchaseDetailDto} from "@core/interfaces/Product/UserInteract/purchaseDetailDto";
import {CartsService} from "@intranet/services/carts.service";
import {WarrantiesService} from "@admin/inventory/services/warranties.service";
import {SwalService} from "@core/shared/services/swal.service";

@Component({
  selector: 'app-wish-lists',
  templateUrl: './wish-lists.component.html',
  styleUrls: ['./wish-lists.component.scss']
})
export class WishListsComponent {
  cartForm!: FormGroup;
  wishListId!: string;
  productsWish$: Observable<WishListProductsResponse[]> = new Observable<WishListProductsResponse[]>();

  constructor(
    private readonly wishListService: WisheslistService,
    private readonly router: Router,
    private readonly reviewService: ReviewsService,
    private readonly discountService: DiscountsService,
    private readonly cartService: CartsService,
    private readonly warrantyService: WarrantiesService,
    private readonly swalService: SwalService
  ) {

  }

  ngOnInit() {
    this.cartForm = new FormGroup({
      quantity: new FormControl(1)
    });
    this.retrieveProducts();
  }

  async AddToCart(cartFormValue: any, productId: string, optionId: string) {
    const cart = {...cartFormValue};

    const warrantResponse = this.warrantyService.GetWarrantyByProductId(productId);
    const warrantId = await lastValueFrom(warrantResponse);
    const cartDto: PurchaseDetailDto = {
      productId: productId,
      quantity: cart.quantity,
      optionId: optionId,
      warrantyId: warrantId
    }
    this.cartService.AddProductToCart(cartDto).subscribe({
      next: () => {
        this.swalService.show({
          icon: 'success',
          title: 'Producto Añadido',
          html: 'El producto se añadio al carrito correctamente'
        })
      }, error: (err) => {
        this.swalService.showErrors(err, {
          title: 'Error al eliminar el producto',
          html: 'Ha ocurrido un error al añadir el producto al carrito',
          icon: 'error'
        })
        console.error(err);
      }
    });
  }

  deleteItem(optionId: string) {
    this.wishListService.RemoveItem(this.wishListId, optionId).subscribe({
      next: () => {
        this.swalService.show({
          icon: 'success',
          title: 'Producto eliminado',
          html: 'El producto se ha eliminado de la lista de deseos correctamente'
        })
        this.retrieveProducts();
      }, error: (error) => {
        this.swalService.showErrors(error, {
          title: 'Error al eliminar el producto',
          html: 'Ha ocurrido un error al eliminar el producto de la lista de deseos',
          icon: 'error'
        })
        console.error(error);
      }
    });
  }

  return() {
    this.router.navigate(['/main-page']);
  }

  cleanList() {
    this.wishListService.DeleteAllProductsFromWishList().subscribe({
      next: () => {
        this.swalService.show({
          icon: 'success',
          title: 'Lista limpia',
          html: 'La lista se ha limpiado correctamente'
        })
        this.retrieveProducts();
      }, error: (error) => {
        this.swalService.showErrors(error, {
          title: 'Error al eliminar el producto',
          html: 'Ha ocurrido un error al eliminar el producto de la lista de deseos',
          icon: 'error'
        })
        console.error(error);
      }
    })
  }

  private retrieveProducts() {
    this.productsWish$ = this.wishListService.getWishList().pipe(
      catchError(err => {
        this.swalService.showErrors(err, {
          title: 'Error',
          html: 'Ha ocurrido un error al traer el contenido de la lista',
          icon: 'error'
        })
        throw err
      }),
      map((wishListResponse: WishListResponse) => {
        if (wishListResponse.productsWish != null)
          wishListResponse.productsWish.forEach(product => {
            this.reviewService.GetReviewsPreview(product.option.id).subscribe((reviews: any) => {
              product.option.reviews = reviews;
              product.option.averageRating = reviews.reduce((acc: any, review: any) => acc + review.rating, 0) / reviews.length;
            });
            this.discountService.GetOptionDiscount(product.option.id).subscribe((discount: any) => {
              product.option.discount = discount;
              product.option.offerPrice = product.option.price - (product.option.price * (discount.value / 100));
            });
          });
        this.wishListId = wishListResponse.id;
        return wishListResponse.productsWish;
      })
    );
  }
}

import { ProductsWishListDto } from "../productsWishListDto";

export interface WishListProductsResponse {
    wishListId: number;
    productsWish: ProductsWishListDto[];
}
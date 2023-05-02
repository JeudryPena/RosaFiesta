import { ProductsWishListDto } from "../productsWishListDto";

export interface WishListProductsResponse {
    wishListId: number;
    tittle: string;
    productsWish: ProductsWishListDto[];
}
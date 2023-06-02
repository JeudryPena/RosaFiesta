import { ProductsWishListDto } from "../productsWishListDto";

export interface WishListProductsResponse {
    wishListId: number;
    title: string;
    productsWish: ProductsWishListDto[];
}
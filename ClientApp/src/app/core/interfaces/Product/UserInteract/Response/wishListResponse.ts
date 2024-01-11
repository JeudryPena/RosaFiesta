import {BaseResponse} from "../../../baseResponse";
import {WishListProductsResponse} from "@core/interfaces/Product/UserInteract/Response/wishListProductsResponse";

export interface WishListResponse extends BaseResponse {
  id: string;
  productsWish: WishListProductsResponse[] | null;
}

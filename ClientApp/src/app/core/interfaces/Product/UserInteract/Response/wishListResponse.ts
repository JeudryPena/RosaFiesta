import { BaseResponse } from "../../../baseResponse";
import { ProductPreviewResponse } from "../../Response/productPreviewResponse";

export interface WishListResponse extends BaseResponse {
	id: number;
	products: ProductPreviewResponse[] | null;
}
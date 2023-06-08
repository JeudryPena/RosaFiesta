import { BaseResponse } from "../../../base-response";
import { ProductPreviewResponse } from "../../Response/productPreviewResponse";

export interface WishListResponse extends BaseResponse {
    id: number;
    title: string | null;
    description: string | null;
    products: ProductPreviewResponse[] | null;
}
import { ProductAndOptionsPreviewResponse } from "../../response/productAndOptionsPreviewResponse";

export interface WishListResponse {
    id: number;
    title: string | null;
    description: string | null;
    createdDate: string;
    updatedDate: string | null;
    products: ProductAndOptionsPreviewResponse[] | null;
}
import {BaseResponse} from "../../../baseResponse";
import {PurchaseDetailOptionResponse} from "./purchaseDetailOptionResponse";
import {WarrantyPreviewResponse} from "@core/interfaces/Product/Response/warrantyPreviewResponse";

export interface PurchaseDetailResponse extends BaseResponse {
  purchaseNumber: string;
  productId: string;
  purchaseOptions: PurchaseDetailOptionResponse[];
  cartId: string;
  orderId: string | null;
  quoteId: string | null;
  warrantyId: string | null;
  warranty: WarrantyPreviewResponse | null;
  category: string;
}

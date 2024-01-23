import {WarrantyPreviewResponse} from "@core/interfaces/Product/Response/warrantyPreviewResponse";
import {PurchaseOrderOptionResponse} from "@core/interfaces/Product/UserInteract/Response/PurchaseOrderOptionResponse";

export interface PurchaseDetailOrderResponse {
  id: string;
  productId: string;
  purchaseOptions: PurchaseOrderOptionResponse[];
  orderId: string;
  quoteId: string;
  warrantyId: string;
  warranty: WarrantyPreviewResponse;
}

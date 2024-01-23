import {BaseResponse} from "../../../baseResponse";
import {AddressDto} from "@core/interfaces/Product/UserInteract/AddressDto";
import {QuoteDetailPreviewResponse} from "@core/interfaces/Product/UserInteract/Response/QuoteDetialPreviewResponse";
import {PurchaseDetailOrderResponse} from "@core/interfaces/Product/UserInteract/Response/PurchaseDetailOrderResponse";

export interface OrderResponse extends BaseResponse {
  id: string;
  orderId: string;
  status: string;
  userName: string;
  details: PurchaseDetailOrderResponse[];
  transactionId: string;
  currencyCode: string;
  payerId: string;
  shipping: number;
  total: number;
  address: AddressDto;
  quote: QuoteDetailPreviewResponse;
  transactionDate: string;
}

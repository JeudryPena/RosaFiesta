import {AddressDto} from "@core/interfaces/Product/UserInteract/AddressDto";

export interface OrderManagementPreviewResponse {
  id: string;
  orderId: string;
  total: number;
  currencyCode: string;
  transactionDate: string | null;
  status: string;
  userId: string | null;
  address: AddressDto;
  quoteId: string | null;
}

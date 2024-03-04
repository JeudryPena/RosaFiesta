import {AddressDto} from "@core/interfaces/Product/UserInteract/AddressDto";

export interface OrderDto {
  orderId: string;
  address: AddressDto;
  total: number;
  transactionId: string;
  currencyCode: string;
  payerId: string;
  shipping: number | null;
  shippingDiscount: number | null;
  taxes: number | null;
  transactionDate: string;
}

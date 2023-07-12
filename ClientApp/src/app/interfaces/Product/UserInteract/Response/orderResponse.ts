export interface OrderResponse extends BaseResponse {
    id: string;
    payMethodId: string;
    state: number;
    userId: string;
    shippingCost: number;
    voucherType: string;
    voucherNumber: number;
    voucherSeries: string;
    taxesCost: number;
    details: PurchaseDetailResponse[];
    addressId: string;
    address: AddressResponse;
}
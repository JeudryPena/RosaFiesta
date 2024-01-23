export interface PurchaseOrderOptionResponse {
  detailId: string;
  quantity: number;
  unitPrice: number;
  taxes: number;
  title: string;
  isService: boolean;
  discounted: number;
  isReturned: boolean;
}

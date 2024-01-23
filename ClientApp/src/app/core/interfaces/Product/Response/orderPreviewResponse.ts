export interface OrderPreviewResponse {
  id: string;
  orderId: string;
  total: number;
  currencyCode: string;
  transactionDate: string;
  status: string;
}

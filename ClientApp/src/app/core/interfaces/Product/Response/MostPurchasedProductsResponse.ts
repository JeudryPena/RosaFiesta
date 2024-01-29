export interface MostPurchasedProductsResponse {
  id: string;
  title: string;
  purchases: number;
}

export interface MostPurchasedProductsWithDateResponse {
  name: string;
  series: PurchasedProductsWithDateResponse[];
}

export interface PurchasedProductsWithDateResponse {
  name: string;
  value: number;
}

export interface OrderComparativeResponse {
  orders: OrderComparativeDataResponse;
  quotes: OrderComparativeDataResponse;
  notPurchased: OrderComparativeDataResponse;
  refunds: OrderComparativeDataResponse;
}

export interface OrderComparativeDataResponse {
  name: string;
  value: number;
}

export interface AnalyticDataResponse {
  totalClients: number;
  averageReviews: number;
  totalGains: number;
}

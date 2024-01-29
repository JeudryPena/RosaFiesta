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

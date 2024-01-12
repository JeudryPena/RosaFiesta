import {OptionPreviewResponse} from "@core/interfaces/Product/Response/optionPreviewResponse";

export interface DiscountResponse {
  id: string;
  value: number;
  productsDiscounts: HotestProductsResponse[];
  start: Date;
  end: Date;
}

export interface HotestProductsResponse {
  option: OptionPreviewResponse;
}

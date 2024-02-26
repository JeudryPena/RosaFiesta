import {MultipleImagesResponse} from "./multipleImagesResponse";

export interface OptionCartResponse {
  title: string;
  image: MultipleImagesResponse;
  price: number;
  offerPrice: number;
  discountValue: number;
  quantityAvailable: number;
  weight: number;
}

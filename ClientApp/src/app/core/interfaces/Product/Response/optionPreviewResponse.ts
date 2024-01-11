import {BaseResponse} from "../../baseResponse";
import {DiscountPreviewResponse} from "./discountPreviewResponse";
import {MultipleImagesResponse} from "./multipleImagesResponse";
import {ReviewPreviewResponse} from "./reviewPreviewResponse";

export interface OptionPreviewResponse extends BaseResponse {
  id: string;
  title: string;
  price: number;
  image: MultipleImagesResponse[] | null;
  quantityAvailable: number;
  condition: string;
  genderFor: string;
  averageRating: number;
  reviews: ReviewPreviewResponse[] | null;
  discount: DiscountPreviewResponse | null;
  offerPrice: number;
  color: string;
  productId: string;
}

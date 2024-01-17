import {BaseResponse} from "../../baseResponse";
import {OptionDetailResponse} from "./optionDetailResponse";
import {OptionPreviewResponse} from "./optionPreviewResponse";
import {WarrantyResponse} from "@core/interfaces/Product/Response/warrantyResponse";

export interface ProductDetailResponse extends BaseResponse {
  id: string;
  isService: boolean;
  categoryId: number | null;
  optionId: string | null;
  warranty: WarrantyResponse;
  option: OptionDetailResponse;
  options: OptionPreviewResponse[];
}

import {ByBaseResponse} from "../../byBaseResponse";
import {OptionsListResponse} from "./optionsListResponse";
import {CategoriesListResponse} from "@core/interfaces/Product/category";

export interface ManagementProductsResponse extends ByBaseResponse {
  id: string;
  code: string | null;
  isService: boolean;
  category: CategoriesListResponse;
  options: OptionsListResponse[];
}

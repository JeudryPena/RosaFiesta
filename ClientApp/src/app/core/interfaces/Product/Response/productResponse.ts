import {ByBaseResponse} from "../../byBaseResponse";
import {OptionsResponse} from "./optionsResponse";
import {SuppliersListResponse} from "./suppliersListResponse";
import {WarrantiesListResponse} from "./warrantiesListResponse";
import {CategoriesListResponse} from "@core/interfaces/Product/category";

export interface ProductResponse extends ByBaseResponse {
  id: string;
  code: string;
  isService: boolean;
  option: OptionsResponse;
  category: CategoriesListResponse;
  warranty: WarrantiesListResponse | null;
  supplier: SuppliersListResponse | null;
  options: OptionsResponse[];
}

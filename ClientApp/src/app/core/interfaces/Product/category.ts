import {ByBaseResponse} from "../byBaseResponse";
import {BaseResponse} from "../baseResponse";
import {ProductPreviewResponse} from "./Response/productPreviewResponse";


interface Category extends ByBaseResponse {
  id: number;
  name: string;
  icon: string;
  description: string | null;
}

interface CategoriesListResponse {
  id: number;
  name: string;
}

interface CategoryPreviewResponse {
  id: number;
  name: string;
  icon: string;
  description: string | null;
}

interface CategoryResponse extends BaseResponse {
  id: number;
  name: string;
  description: string;
  icon: string;
  products: ProductPreviewResponse[] | null;
}

interface CategoryDto {
  name: string;
  description: string;
  icon: string;
}

export {Category, CategoriesListResponse, CategoryPreviewResponse, CategoryResponse, CategoryDto};

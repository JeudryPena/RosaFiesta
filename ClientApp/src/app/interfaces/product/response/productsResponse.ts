import { BaseResponse } from "../../base-response";
import { OptionsResponse } from "./optionsResponse";

export interface ProductsResponse extends BaseResponse {
	code: string;
	title: string;
	options: OptionsResponse;
}
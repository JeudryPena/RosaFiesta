import { BaseResponse } from "../../base-response";
import { OptionsResponse } from "./optionsResponse";

export interface ProductsResponse extends BaseResponse {
	id: string;
	code: string | null;
	title: string;
	options: OptionsResponse;
}
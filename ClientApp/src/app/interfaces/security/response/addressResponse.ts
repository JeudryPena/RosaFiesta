import { BaseResponse } from "../../base-response";

export interface AddressResponse extends BaseResponse {
	id: string;
	title: string;
	country: string;
	city: string;
	zipCode: string;
	street: string;
	userId: string;
}
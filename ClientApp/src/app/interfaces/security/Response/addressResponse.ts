import { BaseResponse } from "../../baseResponse";

export interface AddressResponse extends BaseResponse {
	id: string;
	extraDetails: string | null;
	title: string;
	city: string;
	zipCode: string;
	street: string;
	userId: string;
}
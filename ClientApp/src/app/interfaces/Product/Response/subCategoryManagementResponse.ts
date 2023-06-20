import { BaseResponse } from '../../base-response';

export interface SubCategoryManagementResponse extends BaseResponse {
	id: number;
	name: string;
	icon: string;
	description: string | null;
}
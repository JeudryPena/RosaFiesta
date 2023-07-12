export interface ByBaseResponse extends BaseResponse {
	createdBy: string;
	updatedBy: string | null;
}
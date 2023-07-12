export interface ProductDetailResponse extends BaseResponse {
	id: string;
	categoryId: number | null;
	optionId: string | null;
	warranty: WarrantiesListResponse;
	option: OptionDetailResponse;
	options: OptionPreviewResponse[];
}
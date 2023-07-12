export interface WishListResponse extends BaseResponse {
	id: number;
	products: ProductPreviewResponse[] | null;
}
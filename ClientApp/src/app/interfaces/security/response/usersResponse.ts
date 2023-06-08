import { AppliedDiscountResponse } from "../../Product/Response/appliedDiscountResponse";
import { OrderResponse } from "../../Product/UserInteract/Response/orderResponse";
import { ReviewResponse } from "../../Product/UserInteract/Response/reviewResponse";
import { WishListResponse } from "../../Product/UserInteract/Response/wishListResponse";
import { BaseResponse } from "../../base-response";

export interface UsersResponse extends BaseResponse {
	id: string;
	fullName: string;
	email: string;
	userName: string;
	age: number;
	birthDate: string;
	phoneNumber: string;
	twoFactorEnabled: boolean;
	phoneNumberConfirmed: boolean;
	emailConfirmed: boolean;
	lockoutEnabled: boolean;
	accessFailedCount: number;
	lockoutEnd: string | null;
	passwordHash: string | null;
	promotionalMails: boolean;
	orders: OrderResponse[] | null;
	reviews: ReviewResponse[] | null;
	wishLists: WishListResponse[] | null;
	appliedDiscounts: AppliedDiscountResponse[] | null;
}
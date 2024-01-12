import {BaseResponse} from "../../../baseResponse";
import {UsersListResponse} from "@core/interfaces/Security/Response/usersListResponse";

export interface ReviewResponse extends BaseResponse {
  id: number;
  description: string | null;
  rating: number;
  title: string | null;
  userId: string;
  optionId: string;
}

export interface DetailReviewsResponse extends ReviewResponse {
  id: number;
  description: string | null;
  rating: number;
  title: string | null;
  userId: string;
  optionId: string;
  user: UsersListResponse;
}

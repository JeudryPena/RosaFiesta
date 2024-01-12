import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {config} from "@env/config.prod";
import {DetailReviewsResponse, ReviewResponse} from '@core/interfaces/Product/UserInteract/Response/reviewResponse';
import {ReviewDto} from "@core/interfaces/Product/UserInteract/reviewDto";

@Injectable({
  providedIn: 'root'
})
export class ReviewsService {
  private apiUrl = `${config.apiURL}reviews/`

  constructor(
    private http: HttpClient
  ) {
  }

  GetReviewsPreview(optionId: string): Observable<ReviewResponse[]> {
    return this.http.get<ReviewResponse[]>(`${this.apiUrl}options/${optionId}`);
  }

  GetReviewsDetail(id: string): Observable<DetailReviewsResponse[]> {
    return this.http.get<DetailReviewsResponse[]>(`${this.apiUrl}options/${id}/all-detailed`);
  }

  GetReviews(optionId: string): Observable<ReviewResponse[]> {
    return this.http.get<ReviewResponse[]>(`${this.apiUrl}options/${optionId}/all`);
  }

  createReview(optionId: string, review: ReviewDto) {
    return this.http.post(`${this.apiUrl}options/${optionId}`, review);
  }

  UpdateReview(reviewId: number, review: ReviewDto) {
    return this.http.put(`${this.apiUrl}${reviewId}`, review);
  }

  DeleteReview(ratingId: number) {
    return this.http.delete(`${this.apiUrl}${ratingId}`);
  }
}

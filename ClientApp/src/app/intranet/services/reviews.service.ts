import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {config} from "@env/config.prod";
import {ReviewResponse} from '@core/interfaces/Product/UserInteract/Response/reviewResponse';

@Injectable({
  providedIn: 'root'
})
export class ReviewsService {
  private apiUrl = `${config.apiURL}reviews/`

  constructor(
    private http: HttpClient
  ) {
  }

  GetReviewsPreview(optionId: string) {
    return this.http.get(`${this.apiUrl}options/${optionId}`);
  }

  GetReviews(optionId: string): Observable<ReviewResponse[]> {
    return this.http.get<ReviewResponse[]>(`${this.apiUrl}options/${optionId}/all`);
  }

  CreateReview(optionId: string, review: any) {
    return this.http.post(`${this.apiUrl}options/${optionId}`, review);
  }

  UpdateReview(reviewId: string, review: any) {
    return this.http.put(`${this.apiUrl}${reviewId}`, review);
  }

  DeleteReview(reviewId: string) {
    return this.http.delete(`${this.apiUrl}${reviewId}`);
  }
}

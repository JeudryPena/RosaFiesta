import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { config } from "../../env/config.prod";

@Injectable({
  providedIn: 'root'
})
export class ReviewsService {
  private apiUrl = `${config.apiURL}reviews/`

  constructor(
    private http: HttpClient
  ) { }

  GetReviews(optionId: string) {
    return this.http.get(`${this.apiUrl}options/${optionId}`);
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

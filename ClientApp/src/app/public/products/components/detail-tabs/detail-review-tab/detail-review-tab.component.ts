import {Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges} from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {ReviewsService} from "@intranet/services/reviews.service";
import {ReviewDto} from "@core/interfaces/Product/UserInteract/reviewDto";
import {DetailReviewsResponse} from "@core/interfaces/Product/UserInteract/Response/reviewResponse";
import Swal from "sweetalert2";

@Component({
  selector: 'app-detail-review-tab',
  templateUrl: './detail-review-tab.component.html',
  styleUrl: './detail-review-tab.component.sass'
})
export class DetailReviewTabComponent implements OnInit, OnChanges {

  @Input() optionId: string;
  @Input() selectedRating: number = 0;
  ratings: number[] = [1, 2, 3, 4, 5];
  @Input() reviews: DetailReviewsResponse[] = [];
  reviewsResult: DetailReviewsResponse[];
  @Output() refreshReviews: EventEmitter<any> = new EventEmitter();

  @Input() isAuthenticated = false;
  @Input() userName: string;
  @Input() userId: string;
  alredyReviewedId: number;

  createReviewForm = this.fb.group({
    rating: [1],
    title: [],
    description: []
  });


  constructor(
    private readonly fb: FormBuilder,
    private readonly reviewService: ReviewsService
  ) {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['reviews'] && !changes['reviews'].firstChange) {
      this.filterReviews(this.selectedRating);
      this.findReview();
    }
  }

  filterReviews(rating: number) {
    if (rating === 0) {
      this.reviewsResult = this.reviews;
    } else {
      this.reviewsResult = this.reviews.filter(review => review.rating >= rating);
    }
  }

  ratingChange(rating: number) {
    this.createReviewForm.patchValue({rating: rating});
  }

  ngOnInit(): void {
    this.reviewsResult = this.reviews;
    this.createReviewForm = this.fb.group({
      rating: [this.selectedRating],
      title: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      description: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(250)]]
    });
    this.findReview();
  }

  findReview() {
    if (this.isAuthenticated) {
      const review = this.reviews.find(review => review.user.id === this.userId);
      if (review) {
        this.alredyReviewedId = review.id;
        this.createReviewForm.patchValue({
          title: review.title,
          description: review.description,
          rating: review.rating
        });
      }
    }
  }

  deleteReview(ratingId: number) {
    this.reviewService.DeleteReview(ratingId).subscribe({
      next: () => {
        Swal.fire({
          title: "Reseña agregada",
          icon: "success"
        }).then(() => {
          this.refreshReviews.emit();
          this.alredyReviewedId = null;
          this.createReviewForm.patchValue({
            title: '',
            description: '',
            rating: 0
          })
        });
      }, error: (err) => {
        console.error(err);
        Swal.fire({
          title: "Hubo un error",
          text: "Favor de contactar con el administrador",
          icon: "error"
        }).then(() => {
        });
      }
    });
  }

  submitReview(formValue: any) {
    const value = {...formValue};
    const reviewObject: ReviewDto = {
      rating: value.rating,
      title: value.title,
      description: value.description
    }
    if (this.alredyReviewedId)
      this.reviewService.UpdateReview(this.alredyReviewedId, reviewObject).subscribe({
        next: () => {
          Swal.fire({
            title: "Reseña Actualizada",
            icon: "success"
          }).then(() => {
            this.refreshReviews.emit();
          });
        }, error: (err) => {
          console.error(err);
          Swal.fire({
            title: "Hubo un error",
            text: "Favor de contactar con el administrador",
            icon: "error"
          }).then(() => {
          });
        }
      });
    else
      this.reviewService.createReview(this.optionId, reviewObject).subscribe({
        next: () => {
          Swal.fire({
            title: "Comentario agregado",
            icon: "success"
          }).then(() => {
            this.refreshReviews.emit();
          });
        }, error: (err) => {
          console.error(err);
          Swal.fire({
            title: "Hubo un error",
            text: "Favor de contactar con el administrador",
            icon: "error"
          }).then(() => {
          });
        }
      });
  }
}

import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Review } from 'src/app/models/review';
import { ReviewService } from 'src/app/services/review.service';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.scss']
})
export class ReviewsComponent implements OnInit {
  @Output() reviewUpdated = new EventEmitter<any[]>();

  public reviews: any = [];
  reviewToEdit?: Review;

  loading: boolean = false;

  personId: any;

  constructor(
    private reviewApi: ReviewService
  ) { }

  ngOnInit(): void {
    this.getReviews();
  }

  getReviews() {
    this.reviewApi.getReviews()
      .then(res => {
        this.reviews = res;
      });
  }

  updateReviewList(reviews: Review[]) {
    this.getReviews();
    window.location.reload();
  }

  initNewReview() {
    this.reviewToEdit = new Review();
  }

  editReview(review: Review) {
    this.reviewToEdit = review;
  }

  deleteReview(review: Review) {
    this.reviewApi
      .deleteReview(review)
      .then(res => {
        this.reviewUpdated.emit(res);
        window.location.reload();
      })
  }


}

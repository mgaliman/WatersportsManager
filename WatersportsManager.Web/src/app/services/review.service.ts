import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Review } from '../models/review';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  private baseUrl: string = 'https://localhost:7185/Review/'
  constructor(private http: HttpClient) { }

  getReviews(): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.get<any>(this.baseUrl).subscribe({
        next: (res) => {
          setTimeout(() => {
            resolve(res);
          }, 500);
        },
        error: (err) => {
          reject(err);
        }
      })
    })
  }

  createReview(review: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.post<any>(this.baseUrl, review).subscribe({
        next: (res) => {
          resolve(res);
        },
        error: (err) => {
          reject(err);
        }
      })
    })
  }

  updateReview(review: Review): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.put<Review>(this.baseUrl, review).subscribe({
        next: (res) => {
          resolve(res);
        },
        error: (err) => {
          reject(err);
        }
      })
    })
  }

  deleteReview(review: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.delete<any>(this.baseUrl + `${review.id}`).subscribe({
        next: (res) => {
          resolve(res);
        },
        error: (err) => {
          reject(err);
        }
      })
    })
  }
}

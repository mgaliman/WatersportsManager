import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Reservation } from '../models/reservation';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  private baseUrl: string = 'https://localhost:7185/Reservation/'
  constructor(private http: HttpClient) { }

  getReservations(): Promise<any> {
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

  createReservation(reservation: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.post<any>(this.baseUrl, reservation).subscribe({
        next: (res) => {
          resolve(res);
        },
        error: (err) => {
          reject(err);
        }
      })
    })
  }

  updateReservation(reservation: Reservation): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.put<Reservation>(this.baseUrl, reservation).subscribe({
        next: (res) => {
          resolve(res);
        },
        error: (err) => {
          reject(err);
        }
      })
    })
  }

  deleteReservation(reservation: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.delete<any>(this.baseUrl + `${reservation.id}`).subscribe({
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
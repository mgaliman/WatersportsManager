import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BoatType } from '../models/boatType';

@Injectable({
  providedIn: 'root'
})
export class BoatTypeService {

  private baseUrl: string = 'https://localhost:7185/BoatType/'
  constructor(private http: HttpClient) { }

  getBoatTypes(): Promise<any> {
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

  createBoatType(boatType: BoatType): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.post<any>(this.baseUrl, boatType).subscribe({
        next: (res) => {
          resolve(res);
        },
        error: (err) => {
          reject(err);
        }
      })
    })
  }

  updateBoatType(boatType: BoatType): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.put<BoatType>(this.baseUrl, boatType).subscribe({
        next: (res) => {
          resolve(res);
        },
        error: (err) => {
          reject(err);
        }
      })
    })
  }

  deleteBoatType(boatType: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.delete<any>(this.baseUrl + `${boatType.id}`).subscribe({
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

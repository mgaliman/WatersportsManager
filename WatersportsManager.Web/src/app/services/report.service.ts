import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Report } from '../models/report';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  private baseUrl: string = 'https://localhost:7185/Report/'
  constructor(private http: HttpClient) { }

  getReports(): Promise<any> {
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

  createReport(report: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.post<any>(this.baseUrl, report).subscribe({
        next: (res) => {
          resolve(res);
        },
        error: (err) => {
          reject(err);
        }
      })
    })
  }

  updateReport(report: Report): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.put<Report>(this.baseUrl, report).subscribe({
        next: (res) => {
          resolve(res);
        },
        error: (err) => {
          reject(err);
        }
      })
    })
  }

  deleteReport(report: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.delete<any>(this.baseUrl + `${report.id}`).subscribe({
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
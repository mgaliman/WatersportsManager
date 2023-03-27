import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  private baseUrl: string = 'https://localhost:7185/Location/'
  constructor(private http: HttpClient) { }

  getLocations(): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.get<any>(this.baseUrl).subscribe({
        next: (res) => {
          //res.unshift({ id: undefined, camp: 'Select Location' });
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
}

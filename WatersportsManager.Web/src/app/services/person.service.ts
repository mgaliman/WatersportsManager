import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Person } from '../models/person';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private baseUrl: string = 'https://localhost:7185/Person/'
  constructor(private http: HttpClient) { }

  getPeople(): Promise<any> {
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

  updatePerson(person: Person): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.put<Person>(this.baseUrl, person).subscribe({
        next: (res) => {
          resolve(res);
        },
        error: (err) => {
          reject(err);
        }
      })
    })
  }

  deletePerson(person: Person): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http.delete<any>(this.baseUrl + `${person.id}`).subscribe({
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

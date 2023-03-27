import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl: string = "https://localhost:7185/Person/"
  private personPayload: any;
  constructor(private http: HttpClient, private router: Router) {
    this.personPayload = this.decodedToken()
  }

  signUp(signUpObj: any): Promise<any> {

    return new Promise((resolve, reject) => {

      this.http.post<any>(`${this.baseUrl}register`, signUpObj).subscribe({

        next: (response) => {
          resolve(response);
        },
        error: (err) => {
          reject(err);
        }

      });

    });

  }

  login(loginObj: any): Promise<any> {

    return new Promise((resolve, reject) => {

      this.http.post<any>(`${this.baseUrl}authenticate`, loginObj).subscribe({

        next: (response) => {
          this.storeToken(response.token);
          this.personPayload = this.decodedToken();
          resolve(response);
        },
        error: (err) => {
          reject(err);
        }

      });

    });

  }

  signOut() {
    localStorage.clear();
    this.router.navigate(['login']);
  }

  storeToken(tokenValue: string) {
    localStorage.setItem('token', tokenValue)
  }

  getToken() {
    return localStorage.getItem('token')
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token')
  }

  decodedToken() {
    const jwtHelper = new JwtHelperService();
    const token = this.getToken()!;
    return jwtHelper.decodeToken(token);
  }

  getFullNameFromToken() {
    if (this.personPayload)
      return this.personPayload.unique_name;
  }

  getRoleFromToken() {
    if (this.personPayload)
      return this.personPayload.role;
  }
}

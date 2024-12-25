import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  registerUser(userData: any): Observable<any> {
    return this.http.post(this.apiUrl + '/api/Account/register', userData);
  }
  
  login(userData : any): Observable<boolean> {
    const { rememberMe, ...loginData } = userData;
    return this.http.post<{ token: string }>(`${this.apiUrl}/api/Account/login`, loginData.value).pipe(
      map((response) => {
        if (response.token) {
          localStorage.setItem('jwtToken', response.token);
          return true;
        }
        return false;
      })
    );
  }

  logout(): void {
    localStorage.removeItem('jwtToken');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('jwtToken');
  }

  getToken(): string | null {
    return localStorage.getItem('jwtToken');
  }
}

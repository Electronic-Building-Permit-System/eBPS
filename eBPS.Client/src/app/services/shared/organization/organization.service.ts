import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrganizationService {
  private apiUrl = environment.apiUrl;
  
  constructor(private http: HttpClient) {}

  getOrganization(): Observable<any> {
    return this.http.get(this.apiUrl + '/api/organizations');
  }
}

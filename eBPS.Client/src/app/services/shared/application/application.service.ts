import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {
 
private apiUrl = environment.apiUrl;
  
  constructor(private http: HttpClient) {}

  getBuildingPurpose(): Observable<any> {
    return this.http.get(this.apiUrl + '/api/application/get-building-purpose');
  }
  
  getStructureType(): Observable<any> {
    return this.http.get(this.apiUrl + '/api/application/get-structure-type');
  }

  getNBCClass(): Observable<any> {
    return this.http.get(this.apiUrl + '/api/application/get-nbc-class');
  }
  getWard(): Observable<any> {
    return this.http.get(this.apiUrl + '/api/application/get-ward');
  }
}

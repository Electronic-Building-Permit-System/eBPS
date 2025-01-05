import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BuildingApplicationData } from '../../../shared/models/building-application.model';

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

  createBuildingApplication(buildingApplication: BuildingApplicationData): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/api/application/create-building-application`, buildingApplication);
  }
}

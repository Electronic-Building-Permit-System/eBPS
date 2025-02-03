import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AbstractControl, FormGroup } from '@angular/forms';
import { environment } from '../../../environments/environment';
import { BuildingApplicationData } from '../../models/building-application/building-application.model';
import { LandTotals } from '../../models/building-application/land-area-totals.model';

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
  getLandUseSubZone(): Observable<any> {
    return this.http.get(this.apiUrl + '/api/application/get-land-use-sub-zone');
  }
  getBuildingApplication(): Observable<any> {
    return this.http.get(this.apiUrl + '/api/application/get-building-application-list');
  }
  getLandUseZone() : Observable<any> {
    return this.http.get(this.apiUrl + '/api/application/get-land-use-zone');
  }
  getTransactionType() : Observable<any> {
    return this.http.get(this.apiUrl + '/api/application/get-transaction-type');
  }
  getIssueDistrict() : Observable<any> {
    return this.http.get(this.apiUrl + '/api/application/get-issue-district');
  }
  getLandscapeType() : Observable<any> {
    return this.http.get(this.apiUrl + '/api/application/get-landscape-type');
  }
  createBuildingApplication(buildingApplication: BuildingApplicationData): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/api/application/create-building-application`, buildingApplication);
  }
  calculateTotals(landInformationControls: AbstractControl[]): LandTotals {
    let totals: LandTotals = {
      totalRopani: 0,
      totalAana: 0,
      totalPaisa: 0,
      totalDaam: 0,
      totalSquareFeet: 0,
      totalSquareMeter: 0,
    };

    landInformationControls.forEach((control) => {
      const form = control.value;
      totals.totalRopani += +form.ropani || 0;
      totals.totalAana += +form.aana || 0;
      totals.totalPaisa += +form.paisa || 0;
      totals.totalDaam += +form.daam || 0;
      totals.totalSquareFeet += +form.squareFeet || 0;
      totals.totalSquareMeter += +form.squareMeter || 0;
    });

    return totals;
  }
}

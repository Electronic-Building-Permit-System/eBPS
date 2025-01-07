import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatStepperModule } from '@angular/material/stepper';
import { ApplicationService } from '../../../services/shared/application/application.service';

@Component({
  selector: 'app-application-details',
  standalone: true,
  imports: [CommonModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule, ReactiveFormsModule, MatStepperModule],
  templateUrl: './application-details.component.html',
  styleUrl: './application-details.component.css'
})
export class ApplicationDetailsComponent {
  buildingPurpose: { id: number; description: string }[] = [];
  structureType: { id: number; description: string }[] = [];
  landUseZone: { id: number; description: string }[] = [];
  @Input() firstFormGroup!: FormGroup;
  nbcClass: { id: number; description: string }[] = [];
  landUseSubZone: { id: number; description: string }[] = [];

 
  constructor(private applicationService: ApplicationService){}
    ngOnInit(): void {
      this.fetchBuildingPurpose();
      this.fetchNBCClass();
      this.fetchStructureType();
      this.fetchLandUseSubZone();
      this.fetchLandUseZone();
    }  
    
    fetchBuildingPurpose() {
      this.applicationService.getBuildingPurpose().subscribe((data: { id: number; description: string }[]) => {
        this.buildingPurpose = data;
      });
    }
    fetchStructureType() {
      this.applicationService.getStructureType().subscribe((data: { id: number; description: string }[]) => {
        this.structureType = data;
      });
    }
    fetchLandUseZone() {
      this.applicationService.getLandUseZone().subscribe((data: { id: number; description: string }[]) => {
        this.landUseZone = data;
      });
    }
    fetchNBCClass() {
      this.applicationService.getNBCClass().subscribe((data: { id: number; description: string }[]) => {
        this.nbcClass = data;
      }); 
    }
    fetchLandUseSubZone(){
      this.applicationService.getLandUseSubZone().subscribe((data: { id: number; description: string }[]) => {
        this.landUseSubZone = data;
    });
}
}

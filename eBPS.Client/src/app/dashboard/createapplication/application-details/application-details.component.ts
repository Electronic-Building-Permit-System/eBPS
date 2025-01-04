import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatStepperModule } from '@angular/material/stepper';

@Component({
  selector: 'app-application-details',
  imports: [CommonModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule, ReactiveFormsModule, MatStepperModule],
  templateUrl: './application-details.component.html',
  styleUrl: './application-details.component.css'
})
export class ApplicationDetailsComponent {
  buildingPurpose: { id: number; description: string }[] = [];
  structureType: { id: number; description: string }[] = [];
  @Input() firstFormGroup!: FormGroup;
  constructor(private applicationService: ApplicationService){}
    ngOnInit(): void {
      this.fetchBuildingPurpose();
      this.fetchStructureType();
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
}

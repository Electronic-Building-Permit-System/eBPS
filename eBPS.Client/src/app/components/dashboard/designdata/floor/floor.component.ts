import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatStepperModule } from '@angular/material/stepper';

@Component({
  selector: 'app-floor',
  standalone: true,
  imports: [CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatButtonModule, MatOptionModule, MatSelectModule, MatStepperModule],
  templateUrl: './floor.component.html',
  styleUrls: ['./floor.component.css']
})
export class FloorComponent implements OnInit {

  predefinedFloors: string[] = [
    'Boundary Wall', 'Basement 1', 'Basement 2',
    'Semi Basement',
    'Ground Floor',
    'First Floor',
    'Second Floor',
    'Third Floor',
    'Fourth Floor',
    'Fifth Floor',
    'Sixth Floor'
  ];

  @Input() floorForm!: FormArray;

  constructor(private fb: FormBuilder) {
    this.floorForm = this.fb.array([]);
  }

  ngOnInit(): void {
    if (!this.floorForm) {
      this.floorForm = this.fb.array([]);  // Initialize if not passed from parent
    }
    this.initializeFloors();
  }

  initializeFloors(): void {
    // Initialize with the first 4 floors
    for (let i = 0; i < 4; i++) {
      this.floorForm.push(this.createFloorFormGroup(this.predefinedFloors[i]));
    }
  }

  getFormGroup(control: any): FormGroup {
    return control as FormGroup;
  }

  // Create a new FormGroup for a floor
  createFloorFormGroup(floorName: string): FormGroup {
    return this.fb.group({
      floorName: [floorName, Validators.required],
      NonCountableExisting: ['', Validators.required],
      CountableExisting: ['', Validators.required],
      NonCountablePermitted: ['', Validators.required],
      CountablePermitted: ['', Validators.required],
      NonCountableProposed: ['', Validators.required],
      CountableProposed: ['', Validators.required],
      TotalTaxable: ['', Validators.required],
      Total: ['', Validators.required],
    });
  }

  addFloor(): void {
    const nextFloorIndex = this.floorForm.length;
    if (nextFloorIndex < this.predefinedFloors.length) {
      this.floorForm.push(this.createFloorFormGroup(this.predefinedFloors[nextFloorIndex]));
    }
  }

  removeFloor(): void {
    if (this.floorForm.length > 4) {
      this.floorForm.removeAt(this.floorForm.length - 1);
    }
  }
}
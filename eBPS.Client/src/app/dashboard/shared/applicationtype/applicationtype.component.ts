import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms'; 

@Component({
  selector: 'app-applicationtype',
  imports: [CommonModule,
    MatCardModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatOptionModule,
    MatButtonModule],
  templateUrl: './applicationtype.component.html',
  styleUrl: './applicationtype.component.css'
})
export class ApplicationTypeComponent {
  formGroup: FormGroup;

  // Dropdown options
  transactionTypes = ['Buy', 'Sell', 'Rent', 'Lease'];
  buildingPurposes = ['Residential', 'Commercial', 'Industrial', 'Mixed-use'];
  nbcClasses = ['Class A', 'Class B', 'Class C', 'Class D'];
  landUserZones = ['Urban', 'Rural', 'Agricultural', 'Industrial'];
  landUserSubZones = ['Sub Urban', 'Core Urban', 'Green Belt'];
  structureTypes = ['Steel Frame', 'Concrete', 'Wood', 'Hybrid'];

  constructor(private fb: FormBuilder) {
    this.formGroup = this.fb.group({
      transactionType: ['', Validators.required],
      buildingPurpose: ['', Validators.required],
      nbcClass: ['', Validators.required],
      landUserZone: ['', Validators.required],
      landUserSubZone: ['', Validators.required],
      structureType: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.formGroup.valid) {
      console.log('Form submitted:', this.formGroup.value);
    }
  }
  onReset(): void {
    this.formGroup.reset();
  }
}

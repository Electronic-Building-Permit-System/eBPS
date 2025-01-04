import { Component } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatStepperModule } from '@angular/material/stepper';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from '../navbar/navbar.component';
import { MatIconModule } from '@angular/material/icon';
import { ApplicationDetailsComponent } from './application-details/application-details.component';
import { ApplicantDetailsComponent } from './applicant-details/applicant-details.component';
import { LandInformationComponent } from './land-information/land-information.component';
import { LandOwnerComponent } from './land-owner/land-owner.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-createapplication',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatStepperModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatIconModule, 
    NavbarComponent,
    ApplicationDetailsComponent,
    ApplicantDetailsComponent,
    LandInformationComponent,
    LandOwnerComponent
  ],
  templateUrl: './createapplication.component.html',
  styleUrl: './createapplication.component.css'
})
export class CreateapplicationComponent {
  

      
  isLinear = true; // Enables linear stepper mode
  firstFormGroup!: FormGroup;  // Add '!' to indicate that it will be initialized later
  secondFormGroup!: FormGroup;
  dynamicForms!: FormArray;
  landOwnerForm!: FormArray;

  constructor(private _formBuilder: FormBuilder, private router: Router) {}

  ngOnInit() {
    this.firstFormGroup = this._formBuilder.group({
      transactionType: ['', Validators.required],
      buildingPurpose: ['', Validators.required],
      nbcClass: ['', Validators.required],
      landUseZone: ['', Validators.required],
      landUseSubZone: ['', Validators.required],
      structureType: ['', Validators.required],
    });

    this.secondFormGroup = this._formBuilder.group({
      salutation: ['', Validators.required],
      applicantName: ['', Validators.required],
      wardNo: ['', Validators.required],
      address: ['', Validators.required],
      houseNo: ['', Validators.required],
      phone: ['', Validators.required],
      email: ['', Validators.required],
    });

    this.dynamicForms = this._formBuilder.array([]);
    this.landOwnerForm = this._formBuilder.array([]); // Initialize the FormArray
    this.addNewForm();
    this.addNewlandOwnerForm();
     // Start with one form by default
  }

  getDynamicFormControls() {
    return this.dynamicForms.controls;
  }
  

  addNewForm(): void {
    const newForm = this._formBuilder.group({
      field1: ['', Validators.required],
      field2: ['', Validators.required],
    });
    this.dynamicForms.push(newForm);
  }
  removeForm(index: number): void {
    if (this.dynamicForms.length > 1) {
      this.dynamicForms.removeAt(index);
    }
  }
  addNewlandOwnerForm(): void {
    const newForm = this._formBuilder.group({
      field1: ['', Validators.required],
      // field2: ['', Validators.required],
    });
    this.landOwnerForm.push(newForm);
  }

  removelandOwnerForm(index: number): void {
    if (this.landOwnerForm.length > 1) {
      this.landOwnerForm.removeAt(index);
    }
  }

  asFormGroup(control: AbstractControl): FormGroup {
    return control as FormGroup;
  }

  submitForm() {
    if (this.firstFormGroup.valid && this.secondFormGroup.valid) {
      const fullFormData = {
        ...this.firstFormGroup.value,
        ...this.secondFormGroup.value,
        dynamicForms: this.dynamicForms.value,
        landOwnerForm: this.landOwnerForm.value,
      };

      console.log('Final Form Data:', fullFormData);
      alert('Form submitted successfully!');
    } else {
      console.log('Form is invalid');
    }
  }
  navigateToDashboard() {   
    this.router.navigate(['/dashboard']);
     }
}

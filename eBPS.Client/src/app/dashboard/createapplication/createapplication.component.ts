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
import { HouseOwnerComponent } from './house-owner/house-owner.component';
import { CharkillaComponent } from './charkilla/charkilla.component';

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
    LandOwnerComponent,
    HouseOwnerComponent,
    CharkillaComponent
  ],
  templateUrl: './createapplication.component.html',
  styleUrl: './createapplication.component.css'
})
export class CreateapplicationComponent {
  isLinear = true;
  firstFormGroup!: FormGroup;
  secondFormGroup!: FormGroup;
  dynamicForms!: FormArray;
  landOwnerForm!: FormArray;
  houseOwnerForm!: FormArray;
  charkillaForm!: FormArray;
  constructor(private _formBuilder: FormBuilder, private router: Router) { }

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
    this.landOwnerForm = this._formBuilder.array([]);
    this.addNewlandOwnerForm();
    this.addNewForm();
    this.houseOwnerForm = this._formBuilder.array([]);
    this.addNewHouseOwnerForm();
    this.charkillaForm = this._formBuilder.array([]);
    this.addNewCharkillaForm();
  }

  getDynamicFormControls() {
    return this.dynamicForms.controls;
  }
  
  getHouseOwnerFormControls() {
    return this.houseOwnerForm.controls;
  }

  getCharkillaFormControls() {
    return this.charkillaForm.controls;
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

  addNewHouseOwnerForm(): void {
    const newForm = this._formBuilder.group({
      Salutation: ['', Validators.required],
    });
    this.houseOwnerForm.push(newForm);
  }

  removeHouseOwnerForm(index: number): void {
    if (this.houseOwnerForm.length > 1) {
      this.houseOwnerForm.removeAt(index);
    }
  }

  addNewCharkillaForm(): void {
    const newForm = this._formBuilder.group({
      Direction: ['', Validators.required],
    });
    this.charkillaForm.push(newForm);
  }

  removeCharkillaForm(index: number): void {
    if (this.charkillaForm.length > 1) {
      this.charkillaForm.removeAt(index);
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
        houseOwnerForm: this.houseOwnerForm.value,
        charkillaForm: this.charkillaForm.value,
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

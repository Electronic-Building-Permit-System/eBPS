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
import { ApplicationService } from '../../services/shared/application/application.service';
import { BuildingApplicationData } from '../../shared/models/building-application.model';
import { HouseOwnerData } from '../../shared/models/house-owner.model';

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
  landInformationForm!: FormArray;
  landOwnerForm!: FormArray;
  houseOwnerForm!: FormArray;
  charkillaForm!: FormArray;
  totalRopani: number = 0;
  totalAana: number = 0;
  totalPaisa: number = 0;
  totalDaam: number = 0;
  totalSquareFeet: number = 0;
  totalSquareMeter: number = 0;
  constructor(private _formBuilder: FormBuilder, private router: Router, private applicationService: ApplicationService) { }

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
      wardNumber: ['', Validators.required],
      address: ['', Validators.required],
      houseNumber: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      email: ['', Validators.required],
    });

    this.landInformationForm = this._formBuilder.array([]);
    this.landOwnerForm = this._formBuilder.array([]);
    this.addNewlandOwnerForm();
    this.addNewForm();
    this.houseOwnerForm = this._formBuilder.array([]);
    this.addNewHouseOwnerForm();
    this.charkillaForm = this._formBuilder.array([]);
    this.addNewCharkillaForm();
  }

  asFormGroup(control: AbstractControl, form: any): FormGroup {
    return control as FormGroup;
    return form as FormGroup;
  }
  getDynamicFormControls() {
    return this.landInformationForm.controls;
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
      Ropani: [0, Validators.required],
      Aana: [0, Validators.required],
      Paisa: [0, Validators.required],
      Daam: [0, Validators.required],
      SquareFeet: [0, Validators.required],
      SquareMeter: [0, Validators.required],
    });
    newForm.valueChanges.subscribe(() => this.calculateTotals());
    this.landInformationForm.push(newForm);
    this.calculateTotals(); // Recalculate totals after adding a form

  }

  removeForm(index: number): void {
    if (this.landInformationForm.length > 1) {
      this.landInformationForm.removeAt(index);
      this.calculateTotals(); // Recalculate totals after removing a form
    }
  }
  // Calculate totals for Ropani, Aana, Paisa, and Daam
  calculateTotals() {
    this.totalRopani = 0;
    this.totalAana = 0;
    this.totalPaisa = 0;
    this.totalDaam = 0;
    this.totalSquareFeet = 0;
    this.totalSquareMeter = 0;

    this.landInformationForm.controls.forEach((formGroup) => {
      const form = formGroup.value;
      this.totalRopani += +form.Ropani || 0; // Add Ropani
      this.totalAana += +form.Aana || 0;     // Add Aana
      this.totalPaisa += +form.Paisa || 0;   // Add Paisa
      this.totalDaam += +form.Daam || 0;     // Add Daam
      this.totalSquareFeet += +form.SquareFeet || 0;   // Add Paisa
      this.totalSquareMeter += +form.SquareMeter || 0;
    });
  }

  addNewlandOwnerForm(): void {
    const newForm = this._formBuilder.group({
      field1: ['', Validators.required],
      issueDistrict: ['', Validators.required],
      ward: ['', Validators.required],

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
      Name: ['', Validators.required],
      FatherName: ['', Validators.required],
      Phone: ['', Validators.required],
      Email: ['', Validators.required],
      GrandFatherName: ['', Validators.required],
      CitizenshipNo: ['', Validators.required],
      IssueDate: ['', Validators.required],
      Tole: ['', Validators.required],
      ApplicantNationality: ['', Validators.required],
      issueDistrict: ['', Validators.required],
      ward: ['', Validators.required],     
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
      landscapeType: ['', Validators.required],

    });
    this.charkillaForm.push(newForm);
  }

  removeCharkillaForm(index: number): void {
    if (this.charkillaForm.length > 1) {
      this.charkillaForm.removeAt(index);
    }
  }
  submitForm() {
    if (this.firstFormGroup.valid && this.secondFormGroup.valid) {
      // Map houseOwnerForm values to the houseOwners array in BuildingApplicationData
    const houseOwners: HouseOwnerData[] = this.houseOwnerForm.controls.map((group) => group.value);

      const fullFormData: BuildingApplicationData = {
        ...this.firstFormGroup.value,
        ...this.secondFormGroup.value,
        HouseOwnerList: houseOwners, // Directly bind the houseOwners array
        // landInformationForm: this.landInformationForm.value,
        // landOwnerForm: this.landOwnerForm.value,
        // charkillaForm: this.charkillaForm.value,
      };
      console.log(fullFormData);
      // Pass `formData` to your service or handle it as needed
      this.applicationService.createBuildingApplication(fullFormData).subscribe({
        next: (response) => {
          console.log('Application created successfully:', response);
        },
        error: (error) => {
          console.error('Error creating application:', error);
        },
      });
      console.log('Final Form Data:', fullFormData);
      alert('Form submitted successfully!');
    }
   else {
      console.log('Form is invalid');
    }
  }
  navigateToDashboard() {
    this.router.navigate(['/dashboard']);
  }
}

import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatStepperModule } from '@angular/material/stepper';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from '../navbar/navbar.component';
import { MatIconModule } from '@angular/material/icon';
import { LandInformationComponent } from './land-information/land-information.component';
import { LandOwnerComponent } from './land-owner/land-owner.component';
import { Router } from '@angular/router';
import { HouseOwnerComponent } from './house-owner/house-owner.component';
import { CharkillaComponent } from './charkilla/charkilla.component';
import { ApplicationDetailsComponent } from './application-details/application-details.component';
import { ApplicantDetailsComponent } from './applicant-details/applicant-details.component';
import { BuildingApplicationData } from '../../../models/building-application/building-application.model';
import { ApplicationDetailsModel } from '../../../models/building-application/application-details.model';
import { LandInformationModel } from '../../../models/building-application/land-information.model';
import { ApplicantDetailsModel } from '../../../models/building-application/applicant-details.model';
import { HouseOwnerModel } from '../../../models/building-application/house-owner.model';
import { LandTotals } from '../../../models/building-application/land-area-totals.model';
import { LandOwnerModel } from '../../../models/building-application/land-owner.model';
import { CharkillaModel } from '../../../models/building-application/charkilla.model';
import { ApplicationService } from '../../../services/application/application.service';
import NepaliDate from 'nepali-date-converter';

@Component({
  selector: 'app-createapplication',
  imports: [
    CommonModule,
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
  styleUrls: ['./createapplication.component.css']
})
export class CreateApplicationComponent {
  decimalValidator = Validators.pattern(/^\d*\.?\d+$/);
  isLinear = true;
  applicationDetailsForm!: FormGroup;
  applicantDetailsForm!: FormGroup;
  landInformationForm!: FormArray;
  landOwnerForm!: FormArray;
  houseOwnerForm!: FormArray;
  charkillaForm!: FormArray;
  
  totals: LandTotals = { totalRopani: 0, totalAana: 0, totalPaisa: 0, totalDaam: 0, totalSquareFeet: 0, totalSquareMeter: 0 };

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private applicationService: ApplicationService,
  ) {}

  ngOnInit() {
    this.initializeForms();
    this.addNewDynamicForms();
    this.subscribeToLandInformationChanges();
  }

  private initializeForms() {
    
    this.applicationDetailsForm = this.fb.group({
      transactionType: ['', Validators.required],
      buildingPurpose: ['', Validators.required],
      nbcClass: ['', Validators.required],
      landUseZone: ['', Validators.required],
      landUseSubZone: ['', Validators.required],
      structureType: ['', Validators.required],
      landLongitude: ['', [Validators.required, this.decimalValidator]],
      landLatitude: ['', [Validators.required, this.decimalValidator]],
      landSawikWard: ['', Validators.required],
      landSawikGabisa: ['', Validators.required],
      landToleName: ['', Validators.required],
      wardNumber: ['', Validators.required],
    });

    this.applicantDetailsForm = this.fb.group({
      salutation: ['', Validators.required],
      applicantName: ['', Validators.required],
      applicationNumber: ['', Validators.required],
      fatherName: ['', Validators.required],
      grandFatherName: ['', Validators.required],
      tole: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      email: ['', Validators.required],
      citizenshipNumber: ['', Validators.required],
      citizenshipIssueDate: [NepaliDate.now(), Validators.required],
      citizenshipIssueDistrict: ['', Validators.required],
      wardNumber: ['', Validators.required],
      address: ['', Validators.required],
      houseNumber: ['', Validators.required],
    });

    this.landInformationForm = this.fb.array([]);
    this.landOwnerForm = this.fb.array([]);
    this.houseOwnerForm = this.fb.array([]);
    this.charkillaForm = this.fb.array([]);
  }

  private addNewDynamicForms() {
    this.addNewLandInformationForm();
    this.addNewLandOwnerForm();
    this.addNewHouseOwnerForm();
    this.addNewCharkillaForm();
  }

  private subscribeToLandInformationChanges() {
    this.landInformationForm.valueChanges.subscribe(() => this.updateTotals());
  }

  addNewLandInformationForm() {
    const landInfoForm = this.fb.group({
      mapSheetNumber: ['', Validators.required],
      landParcelNumber: ['', Validators.required],
      ropani: ['', [Validators.required, this.decimalValidator]],
      aana: ['', [Validators.required, this.decimalValidator]],
      paisa: ['', [Validators.required, this.decimalValidator]],
      daam: ['', [Validators.required, this.decimalValidator]],
      squareFeet: ['', [Validators.required, this.decimalValidator]],
      squareMeter: ['', [Validators.required, this.decimalValidator]],
      remarks: ['', Validators.required],
    });
    landInfoForm.valueChanges.subscribe(() => this.updateTotals());
    this.landInformationForm.push(landInfoForm);
  }

  addNewLandOwnerForm() {
    const formGroup = this.fb.group({
      citizenshipIssueDistrict: ['', Validators.required],
      wardNumber: ['', Validators.required],
      landOwnerType: ['', Validators.required],
      salutation: ['', Validators.required],
      landOwnerName: ['', Validators.required],
      fatherName: ['', Validators.required],
      grandFatherName: ['', Validators.required],
      citizenshipNumber: ['', Validators.required],
      citizenshipIssueDate: ['', Validators.required],
      address: ['', Validators.required],
      tole: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      email: ['', Validators.required],
    });
    this.landOwnerForm.push(formGroup);
  }

  addNewHouseOwnerForm() {
    const formGroup = this.fb.group({
      salutation: ['', Validators.required],
      houseOwnerName: ['', Validators.required],
      houseOwnerType: ['', Validators.required],
      fatherName: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      email: ['', Validators.required],
      grandFatherName: ['', Validators.required],
      citizenshipNumber: ['', Validators.required],
      citizenshipIssueDate: ['', Validators.required],
      tole: ['', Validators.required],
      citizenshipIssueDistrict: ['', Validators.required],
      wardNumber: ['', Validators.required],
      address: ['', Validators.required],
    });
    this.houseOwnerForm.push(formGroup);
  }

  addNewCharkillaForm() {
    const formGroup = this.fb.group({
      direction: ['', Validators.required],
      landscapeType: ['', Validators.required],
      side: ['', Validators.required],
      charkillaName: ['', Validators.required],
      roadLength: ['', [Validators.required, this.decimalValidator]],
      existingRow: ['', [Validators.required, this.decimalValidator]],
      proposedRow: ['', [Validators.required, this.decimalValidator]],
      actualSetback: ['', [Validators.required, this.decimalValidator]],
      standardSetback: ['', [Validators.required, this.decimalValidator]],
      roadId: ['', Validators.required],
      kitta: ['', Validators.required],
    });
    this.charkillaForm.push(formGroup);
  }

  private updateTotals() {
    this.totals = { ...this.totals, ...this.applicationService.calculateTotals(this.landInformationForm.controls) };
  }

  removeFormGroup(formArray: FormArray, index: number) {
    if (formArray.length > 1) {
      formArray.removeAt(index);
      if (formArray === this.landInformationForm) {
        this.updateTotals();
      }
    }
  }

  submitForm() {
    if (this.applicationDetailsForm.valid && this.applicantDetailsForm.valid) {
      const fullFormData: BuildingApplicationData = this.prepareFormData();
      console.log(fullFormData);
      this.applicationService.createBuildingApplication(fullFormData).subscribe({
        next: response => {
          console.log('Application created successfully:', response);
          alert('Form submitted successfully!');
        },
        error: error => {
          console.error('Error creating application:', error);
        },
      });
    } else {
      console.log('Form is invalid');
    }
  }

  private prepareFormData(): BuildingApplicationData {
    const houseOwners: HouseOwnerModel[] = this.houseOwnerForm.controls.map(group => group.value);
    const landInformation: LandInformationModel[] = this.landInformationForm.controls.map(group => group.value);
    const landOwners: LandOwnerModel[] = this.landOwnerForm.controls.map(group => group.value);
    const charkilla: CharkillaModel[] = this.charkillaForm.controls.map(group => group.value);
    const applicantDetails: ApplicantDetailsModel = this.applicantDetailsForm.value;
    if (applicantDetails.citizenshipIssueDate) {
      applicantDetails.citizenshipIssueDate = applicantDetails.citizenshipIssueDate.toJsDate(); // Convert to ISO 8601
      console.log('test', applicantDetails.citizenshipIssueDate);
      const nepaliDate = new NepaliDate(applicantDetails.citizenshipIssueDate);
      console.log('Nepali date:', nepaliDate.format('YYYY-MM-DD'));
      applicantDetails.citizenshipIssueDateBS = nepaliDate.format('YYYY-MM-DD'); // Example format
    }
    return {
      applicationDetails: this.applicationDetailsForm.value as ApplicationDetailsModel,
      applicantDetails: this.applicantDetailsForm.value as ApplicantDetailsModel,
      houseOwnerList: houseOwners,
      landInformationList: landInformation,
      landOwnerList: landOwners,
      charkillaList: charkilla,
    };
  }

  navigateToDashboard() {
    this.router.navigate(['/dashboard']);
  }
}

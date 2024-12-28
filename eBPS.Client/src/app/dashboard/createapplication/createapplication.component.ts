import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatStepperModule } from '@angular/material/stepper';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from '../navbar/navbar.component';
import { MatIconModule } from '@angular/material/icon';
import { FooterComponent } from '../../shared/footer/footer.component';
import { ApplicationDetailsComponent } from './application-details/application-details.component';
import { ApplicantDetailsComponent } from './applicant-details/applicant-details.component';

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
    FooterComponent,
    ApplicationDetailsComponent,
    ApplicantDetailsComponent,
  ],
  templateUrl: './createapplication.component.html',
  styleUrl: './createapplication.component.css'
})
export class CreateapplicationComponent {
  isLinear = true; // Enables linear stepper mode
  firstFormGroup!: FormGroup;  // Add '!' to indicate that it will be initialized later
  secondFormGroup!: FormGroup;

  constructor(private _formBuilder: FormBuilder) {}

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
  }

  submitForm() {
    if (this.firstFormGroup.valid && this.secondFormGroup.valid) {
      const fullFormData = {
        ...this.firstFormGroup.value,
        ...this.secondFormGroup.value,
      };

      console.log('Final Form Data:', fullFormData);
      alert('Form submitted successfully!');
    } else {
      console.log('Form is invalid');
    }
  }
}

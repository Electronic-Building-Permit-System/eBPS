import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatStepperModule } from '@angular/material/stepper';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from '../navbar/navbar.component';

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
    NavbarComponent
  ],
  templateUrl: './createapplication.component.html',
  styleUrl: './createapplication.component.css'
})
export class CreateapplicationComponent {
  isLinear = true; // Enables linear stepper mode
  step1Form: FormGroup;
  step2Form: FormGroup;
  step3Form: FormGroup;

  constructor(private fb: FormBuilder) {
    // Initialize step forms
    this.step1Form = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });

    this.step2Form = this.fb.group({
      address: ['', Validators.required],
      city: ['', Validators.required],
    });

    this.step3Form = this.fb.group({
      paymentMethod: ['', Validators.required],
    });
  }

  // Submit all form data
  onSubmit() {
    if (this.step1Form.valid && this.step2Form.valid && this.step3Form.valid) {
      const fullFormData = {
        ...this.step1Form.value,
        ...this.step2Form.value,
        ...this.step3Form.value,
      };

      console.log('Final Form Data:', fullFormData);
      alert('Form submitted successfully!');
    } else {
      alert('Please fill in all required fields before submitting.');
    }
  }
}

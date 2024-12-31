import { Component } from '@angular/core';
import { HomeNavbarComponent } from "../../shared/home-navbar/home-navbar.component";
import { FooterComponent } from "../../shared/footer/footer.component";
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common'; 

@Component({
  selector: 'app-forgotpassword',
  standalone: true, 
  imports: [
    CommonModule, 
    HomeNavbarComponent,
    FooterComponent,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatButtonModule,
  ],
  templateUrl: './forgotpassword.component.html',
  styleUrls: ['./forgotpassword.component.css'], 
})
export class ForgotpasswordComponent {
  forgotPasswordForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.forgotPasswordForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
    });
  }

  get email() {
    return this.forgotPasswordForm.get('email');
  }

  onSubmit() {
    if (this.forgotPasswordForm.valid) {
      console.log('Sending reset link to:', this.forgotPasswordForm.value.email);
    }
  }
}

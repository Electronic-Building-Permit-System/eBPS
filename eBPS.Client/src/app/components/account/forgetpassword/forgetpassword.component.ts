import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common'; 
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HomeNavbarComponent } from '../../shared/home-navbar/home-navbar.component';
import { FooterComponent } from '../../shared/footer/footer.component';
import { EmailService } from '../../../services/shared/email/email.service';



@Component({
  selector: 'app-forgetpassword',
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
    HttpClientModule,
  ],
  templateUrl: './forgetpassword.component.html',
  styleUrls: ['./forgetpassword.component.css'], 
})
export class ForgetpasswordComponent {
  forgetPasswordForm: FormGroup;

  constructor(private fb: FormBuilder, private emailService: EmailService) {
    this.forgetPasswordForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
    });
  }

  get email() {
    return this.forgetPasswordForm.get('email');
  }

  onSubmit() {
    if (this.forgetPasswordForm.valid) {
      debugger
      const payload = {
        to: this.forgetPasswordForm.value.email,
        subject: 'Password Reset',
        body: 'Click the link to reset your password.',
      };
  
      this.emailService.sendResetLink(payload).subscribe(
        (response: any) => {
          alert(response.message); // Notify the user
        },
        (error) => {
          console.error('Error:', error);
          alert('Something went wrong. Please try again.');
        }
      );
    }
  }}

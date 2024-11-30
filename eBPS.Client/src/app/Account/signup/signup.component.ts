import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { NavbarComponent } from "../../home/navbar/navbar.component";
import { FooterComponent } from "../../home/footer/footer.component";
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  imports: [FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule, NavbarComponent, FooterComponent],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {

  signupForm: FormGroup;
 

  constructor(private fb: FormBuilder , private router: Router) {
    this.signupForm = this.fb.group({
      fullName: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  onSubmit() {
    if (this.signupForm.valid) {
      console.log('Sign Up Form Submitted', this.signupForm.value);
    } else {
      console.log('Sign Up Form is invalid');
    }
  }
  navigateToLogin() {
    this.router.navigate(['/login']);
    }
}

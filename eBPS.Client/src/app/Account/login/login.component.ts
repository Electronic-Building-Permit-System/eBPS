import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { FooterComponent } from "../../shared/footer/footer.component";
import { HomeNavbarComponent } from '../../shared/home-navbar/home-navbar.component';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule, HomeNavbarComponent, MatSlideToggleModule, FooterComponent],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'] // Corrected property name
})
export class LoginComponent {

  loginForm: FormGroup;
 
  constructor(private fb: FormBuilder, private router: Router) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      rememberMe: [false]
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      console.log('Form Submitted', this.loginForm.value);
    } else {
      console.log('Form is invalid');
    }
  }

  navigateToSignUp() {
    this.router.navigate(['/signup']);
    }
}

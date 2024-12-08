import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { FooterComponent } from '../../shared/footer/footer.component';
import { HomeNavbarComponent } from '../../shared/home-navbar/home-navbar.component';
import { UserService } from '../../services/account/user.service';

@Component({
  selector: 'app-signup',
  imports: [FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule, HomeNavbarComponent, FooterComponent],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {

  signupForm: FormGroup;
 

  constructor(private fb: FormBuilder , private router: Router, private userService: UserService) {
    this.signupForm = this.fb.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      password: ['', Validators.required],
      roleId: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.signupForm.valid) {
      this.userService.registerUser(this.signupForm.value).subscribe(
        (response: { message: string }) => {
          console.log('User registered successfully', response);
          alert('User registered successfully!');
        },
        (error: { error: string }) => {
          console.error('Error registering user', error);
          alert('Registration failed!');
        }
      );
    }
  }
  navigateToLogin() {
    this.router.navigate(['/login']);
    }
}

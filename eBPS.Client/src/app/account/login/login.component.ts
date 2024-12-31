import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { FooterComponent } from "../../shared/footer/footer.component";
import { HomeNavbarComponent } from '../../shared/home-navbar/home-navbar.component';
import { UserService } from '../../services/account/user.service';

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
  errorMessage = '';
  loginForm: FormGroup;
 
  constructor(private fb: FormBuilder, private router: Router, private userService: UserService) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      rememberMe: [false]
    });
  }

  login() {
    this.userService.login(this.loginForm).subscribe(
      (success) => {
        if (success) {
          this.router.navigate(['/dashboard']); // Redirect on success
        }
      },
      (error) => {
        this.errorMessage = 'Invalid username or password';
        alert(this.errorMessage);
      }
    );
  }

  navigateToSignUp() {
    this.router.navigate(['/signup']);
    }

    navigateToForgotPassword() {
      this.router.navigate(['/forgotpassword']);
      }
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { FooterComponent } from '../../shared/footer/footer.component';
import { HomeNavbarComponent } from '../../shared/home-navbar/home-navbar.component';
import { UserService } from '../../services/account/user.service';
import { MatOption } from '@angular/material/core';
import { CommonModule } from '@angular/common';
import { MatSelect } from '@angular/material/select';
import { RoleService } from '../../services/shared/role/role.service';
import { OrganizationService } from '../../services/shared/organization/organization.service';

@Component({
  selector: 'app-signup',
  imports: [CommonModule, FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule, MatOption, MatSelect, HomeNavbarComponent, FooterComponent],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent implements OnInit {

  signupForm: FormGroup;
  roles: any[] = []; 
  organizations: any[] = [];

  constructor(private fb: FormBuilder , private router: Router, private userService: UserService, private organizationService: OrganizationService, private roleService : RoleService) {
    this.signupForm = this.fb.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      password: ['', Validators.required],
      roleIds: [[], Validators.required],
      orgIds: [[], Validators.required],
    });
  }

  ngOnInit() {
    this.getActiveRoles();
    this.getActiveOrganizations();
  }

  getActiveRoles() {
    this.roleService.getRoles().subscribe((data: any) => {
      this.roles = data;
    });
  }

  getActiveOrganizations() {
    this.organizationService.getOrganization().subscribe((data: any) => {
      this.organizations = data;
    });
  }

  onSubmit(): void {
    debugger
    if (this.signupForm.valid) {
      this.userService.registerUser(this.signupForm.value).subscribe(
        (response: { message: string }) => {
          console.log('User registered successfully', response);
          alert('User registered successfully!');
        },
        (error: { error: string }) => {
          console.log(error);
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

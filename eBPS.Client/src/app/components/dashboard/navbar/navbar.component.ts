import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { Router } from '@angular/router';
import { UserService } from '../../../services/account/user.service';
import { OrganizationService } from '../../../services/organization/organization.service';
import { RoleService } from '../../../services/role/role.service';


@Component({
  selector: 'app-navbar',
  imports: [MatToolbarModule, MatButton, MatMenuModule, CommonModule, MatIconModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  organizations: { id: number; name: string }[] = []; // Array of organizations
  selectedOrganization: string | null = null; // Selected organization name
roles: any;
  constructor(private organizationService: OrganizationService, private roleService : RoleService, private userService : UserService, private router: Router) {}

  ngOnInit(): void {
    this.fetchOrganizations();
    this.fetchRoles();
  }
  
  fetchRoles() {
    this.roleService.getRoles().subscribe((data: { id: number; name: string }[]) => {
      this.roles = data;
    });
  }

  fetchOrganizations(): void {
    this.organizationService.getUserOrganization().subscribe((data: { id: number; name: string }[]) => {
        this.organizations = data;
      });
  }

  onSelectOrganization(organization: { id: number; name: string }): void {
    this.selectedOrganization = organization.name; // Update selected organization name
  }

  logout() {
    this.userService.logout();
    this.router.navigate(['']);
  }
}
  


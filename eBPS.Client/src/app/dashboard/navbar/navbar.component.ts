import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { CommonModule } from '@angular/common';
import { OrganizationService } from '../../services/shared/organization/organization.service';
import { MatIconModule } from '@angular/material/icon';


@Component({
  selector: 'app-navbar',
  imports: [MatToolbarModule, MatButton, MatMenuModule, CommonModule, MatIconModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  organizations: { id: number; name: string }[] = []; // Array of organizations
  selectedOrganization: string | null = null; // Selected organization name
  constructor(private organizationService: OrganizationService) {}

  ngOnInit(): void {
    this.fetchOrganizations();
  }

  fetchOrganizations(): void {
    this.organizationService.getOrganization().subscribe((data: { id: number; name: string }[]) => {
        this.organizations = data;
      });
  }

  onSelectOrganization(organization: { id: number; name: string }): void {
    this.selectedOrganization = organization.name; // Update selected organization name
  }
}
  


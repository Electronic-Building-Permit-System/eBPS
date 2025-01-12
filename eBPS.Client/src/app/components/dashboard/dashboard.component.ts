import { Component } from '@angular/core';
import { NavbarComponent } from './navbar/navbar.component';
import { BuildingApplicationComponent } from './building-application/building-application.component';

@Component({
  selector: 'app-dashboard',
  imports: [NavbarComponent, BuildingApplicationComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  
}

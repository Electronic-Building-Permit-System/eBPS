import { Component } from '@angular/core';


import { NavbarComponent } from './navbar/navbar.component';
import { SideNavComponent } from './side-nav/side-nav.component';
import { BuildingApplicationComponent } from "./building-application/building-application.component";

@Component({
  selector: 'app-dashboard',
  imports: [NavbarComponent, SideNavComponent, BuildingApplicationComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  
}

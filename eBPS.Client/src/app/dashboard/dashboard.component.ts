import { Component } from '@angular/core';
import { BuilingComponent } from './builing/builing.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SideNavComponent } from './side-nav/side-nav.component';

@Component({
  selector: 'app-dashboard',
  imports: [BuilingComponent,NavbarComponent,SideNavComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  
}

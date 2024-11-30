import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatDividerModule } from '@angular/material/divider';
import { UserNavbarComponent } from '../shared/user-navbar/user-navbar.component';
@Component({
  selector: 'app-dashboard',
  imports: [UserNavbarComponent,MatCardModule, MatTableModule, MatDividerModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
}

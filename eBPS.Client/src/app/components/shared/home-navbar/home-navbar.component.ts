import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar'; // Import MatToolbarModule
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-navbar',
  imports: [MatToolbarModule, MatButton],
  templateUrl: './home-navbar.component.html',
  styleUrl: './home-navbar.component.css'
})
export class HomeNavbarComponent {
  constructor(private router: Router) {}

  navigateToLogin() {
    this.router.navigate(['/login']);
  }

  navigateToHome() {
    this.router.navigate(['/home']);
    }
}
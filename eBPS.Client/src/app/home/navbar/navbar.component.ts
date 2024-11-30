import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar'; // Import MatToolbarModule
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  imports: [MatToolbarModule, MatButton],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

  constructor(private router: Router) {}

  navigateToLogin() {
    this.router.navigate(['/login']);
  }

  navigateToAbout(): void {
    this.router.navigate(['/about']);
  }
  navigateToHome() {
    this.router.navigate(['/home']);
    }
}
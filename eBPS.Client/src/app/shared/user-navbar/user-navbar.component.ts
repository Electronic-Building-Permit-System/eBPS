import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { UserService } from '../../services/account/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar-user',
  imports: [MatToolbarModule,MatButtonModule],
  templateUrl: './user-navbar.component.html',
  styleUrl: './user-navbar.component.css'
})
export class UserNavbarComponent {
  constructor(private router: Router, private userService: UserService){}
  logout() {
    this.userService.logout();
    this.router.navigate(['']);
  }
}

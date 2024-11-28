import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar'; // Import MatToolbarModule

@Component({
  selector: 'app-navbar',
  imports: [MatToolbarModule, MatButton],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

}

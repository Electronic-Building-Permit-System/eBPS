import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-detailapplication',
  imports: [NavbarComponent, MatCardModule],
  templateUrl: './detailapplication.component.html',
  styleUrl: './detailapplication.component.css'
})
export class DetailapplicationComponent {

}

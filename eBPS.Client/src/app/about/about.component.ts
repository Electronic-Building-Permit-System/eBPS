import { Component } from '@angular/core';
import { FooterComponent } from '../home/footer/footer.component';
import { NavbarComponent } from '../home/navbar/navbar.component';

@Component({
  selector: 'app-about',
  imports: [NavbarComponent , FooterComponent],
  templateUrl: './about.component.html',
  styleUrl: './about.component.css'
})
export class AboutComponent {

}

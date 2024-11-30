import { Component } from '@angular/core';
import { FooterComponent } from '../shared/footer/footer.component';
import { HomeNavbarComponent } from '../shared/home-navbar/home-navbar.component';
@Component({
  selector: 'app-about',
  imports: [HomeNavbarComponent , FooterComponent],
  templateUrl: './about.component.html',
  styleUrl: './about.component.css'
})
export class AboutComponent {

}

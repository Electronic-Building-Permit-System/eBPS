import { Component } from '@angular/core';
import { NavbarComponent } from './navbar/navbar.component';
import { HeroComponent } from './hero/hero.component';
import { CardComponent } from './card/card.component';
import { FooterComponent } from './footer/footer.component';

@Component({
  selector: 'app-home',
  imports: [NavbarComponent, HeroComponent, CardComponent, FooterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}

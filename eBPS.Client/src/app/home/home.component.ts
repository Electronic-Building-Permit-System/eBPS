import { Component } from '@angular/core';
import { HeroComponent } from './hero/hero.component';
import { CardComponent } from './card/card.component';
import { FooterComponent } from '../shared/footer/footer.component';
import { HomeNavbarComponent } from '../shared/home-navbar/home-navbar.component';

@Component({
  selector: 'app-home',
  imports: [HomeNavbarComponent, HeroComponent, CardComponent, FooterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}

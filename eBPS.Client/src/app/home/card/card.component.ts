import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-card',
  imports:[MatCardModule, CommonModule],
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent {
  cards = [
    { title: 'Card Title 1', description: 'Description of the card content.' },
    { title: 'Card Title 2', description: 'Description of the card content.' },
    { title: 'Card Title 3', description: 'Description of the card content.' },
    { title: 'Card Title 4', description: 'Description of the card content.' }
  ];
}

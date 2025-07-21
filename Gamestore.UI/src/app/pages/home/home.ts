import { Component } from '@angular/core';
import { Game } from '../../models/game';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  imports: [CommonModule],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  games: Game[] = [
    {
      name: 'Cyberpunk 2077',
      price: 29.99,
      unitInStock: 10,
      discontinued: false,
      releaseDate: '2020-12-10',
      imageKey: 'cyberpunk.jpg',
    },
    {
      name: 'The Witcher 3',
      price: 19.99,
      unitInStock: 15,
      discontinued: false,
      releaseDate: '2015-05-19',
      imageKey: 'witcher3.jpg',
    },
  ];
}

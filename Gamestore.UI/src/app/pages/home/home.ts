import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Game } from '../../models/game';
import { GameCard } from '../../components/game-card/game-card';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, GameCard],
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
      imageKey:
        'https://upload.wikimedia.org/wikipedia/en/9/9f/Cyberpunk_2077_box_art.jpg',
    },
    {
      name: 'The Witcher 3',
      price: 19.99,
      unitInStock: 15,
      discontinued: false,
      releaseDate: '2015-05-19',
      imageKey:
        'https://image.api.playstation.com/vulcan/ap/rnd/202211/0711/kh4MUIuMmHlktOHar3lVl6rY.png',
    },
  ];
}

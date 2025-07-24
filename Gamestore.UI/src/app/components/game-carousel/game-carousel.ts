import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Game } from '../../models/game';

@Component({
  selector: 'app-game-carousel',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './game-carousel.html',
  styleUrl: './game-carousel.css',
})
export class GameCarousel {
  games: Game[] = [
    {
      name: 'Cyberpunk 2077',
      price: 29.99,
      unitInStock: 10,
      discontinued: false,
      releaseDate: '2020-12-10',
      imageKey:
        'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRR3Q1evDu0tMAUgKr9wd9A_xt-UcsS7PZEWA&s',
    },
    {
      name: 'The Witcher 3',
      price: 19.99,
      unitInStock: 15,
      discontinued: false,
      releaseDate: '2015-05-19',
      imageKey:
        'https://store-images.s-microsoft.com/image/apps.46303.69531514236615003.534d4f71-03cb-4592-929a-b00a7de28b58.abbf704e-3676-4fb7-9f68-f4425de5df24?q=90&w=480&h=270',
    },
  ];

  currentPage = 0;
  pageSize = 3;

  get paginatedGames(): Game[] {
    const start = this.currentPage * this.pageSize;
    return this.games.slice(start, start + this.pageSize);
  }

  nextPage() {
    if ((this.currentPage + 1) * this.pageSize < this.games.length) {
      this.currentPage++;
    }
  }

  prevPage() {
    if (this.currentPage > 0) {
      this.currentPage--;
    }
  }
}

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Game } from '../../models/game';
import { GameService } from '../../services/game.service';

@Component({
  selector: 'app-game-carousel',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './game-carousel.html',
  styleUrl: './game-carousel.css',
})
export class GameCarousel {
  games: Game[] = [];
  currentPage = 0;
  pageSize = 3;

  constructor(private gameService: GameService) {}

  ngOnInit(): void {
    this.gameService.getGames().subscribe({
      next: (data) => (this.games = data),
      error: (err) => console.error('Failed to fetch games:', err),
    });
  }

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

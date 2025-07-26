import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Game } from '../../models/game';
import { GameCarouselService } from './game-carousel.service';
import { paginate } from '../../utils/pagination';

@Component({
  selector: 'app-game-carousel',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './game-carousel.html',
  styleUrl: './game-carousel.css',
})
export class GameCarousel implements OnInit {
  @Input() pageSize = 3;
  @Input() title = 'Featured Games';

  games: Game[] = [];
  currentPage = 0;

  isLoading = false;
  loadFailed = false;
  errorMessage: string | null = null;

  constructor(private carouselService: GameCarouselService) {}

  ngOnInit(): void {
    this.loadGames();
  }

  loadGames(): void {
    this.isLoading = true;
    this.loadFailed = false;
    this.errorMessage = null;

    this.carouselService.fetchGames().subscribe({
      next: (data) => {
        this.games = data;
        this.isLoading = false;
      },
      error: () => {
        this.loadFailed = true;
        this.errorMessage = 'Failed to load games. Please try again later.';
        this.isLoading = false;
      },
    });
  }

  get paginatedGames(): Game[] {
    return paginate(this.games, this.currentPage, this.pageSize);
  }

  nextPage(): void {
    if ((this.currentPage + 1) * this.pageSize < this.games.length) {
      this.currentPage++;
    }
  }

  prevPage(): void {
    if (this.currentPage > 0) {
      this.currentPage--;
    }
  }

  get totalPages(): number {
    return Math.ceil(this.games.length / this.pageSize);
  }
}

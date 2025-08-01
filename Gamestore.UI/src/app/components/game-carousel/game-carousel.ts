import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Game } from '../../models/Game';
import { GameService } from '../../services/game.service';
import { paginate } from '../../utils/pagination';
import { Category } from '../../models/Category';
import { CategoryService } from '../../services/category.service';

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
  categories: Category[] = [];

  currentPage = 0;
  selectedGame: Game | null = null;
  isLoading = false;
  loadFailed = false;
  errorMessage: string | null = null;

  selectedCategoryId: string | null = null;
  filteredGames: Game[] = [];

  constructor(
    private gameService: GameService,
    private categoryService: CategoryService
  ) {}

  ngOnInit(): void {
    this.loadGames();
    this.LoadCategoreis();
  }

  LoadCategoreis(): void {
    this.categoryService.getCategories().subscribe({
      next: (data) => {
        this.categories = data;
      },
    });
  }

  loadGames(): void {
    this.isLoading = true;
    this.loadFailed = false;
    this.errorMessage = null;

    this.gameService.getGames().subscribe({
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

  selectGame(game: Game) {
    this.selectedGame = game;
  }

  goBack() {
    this.selectedGame = null;
  }

  get totalPages(): number {
    return Math.ceil(this.games.length / this.pageSize);
  }

  filterByCategory(categoryId: string | null): void {
    this.selectedCategoryId = categoryId;

    this.filteredGames = categoryId
      ? this.games.filter((game) => game.categoryId === categoryId)
      : this.games;
  }
}

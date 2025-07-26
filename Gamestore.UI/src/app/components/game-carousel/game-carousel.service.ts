// src/app/services/game-carousel.service.ts
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GameService } from '../../services/game.service';
import { Game } from '../../models/game';

@Injectable({ providedIn: 'root' })
export class GameCarouselService {
  constructor(private gameService: GameService) {}

  fetchGames(): Observable<Game[]> {
    return this.gameService.getGames();
  }
}

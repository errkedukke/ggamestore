import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameCarousel } from '../../components/game-carousel/game-carousel';
import { GameCard } from '../../components/game-card/game-card';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, GameCarousel],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {}

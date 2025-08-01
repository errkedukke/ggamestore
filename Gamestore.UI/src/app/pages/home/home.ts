import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameCarousel } from '../../components/game-carousel/game-carousel';
import { NavbarComponent } from '../../components/navbar/navbar.component';
import { SecondaryNavbar } from '../../components/secondary-navbar/secondary-navbar';
import { Footer } from '../../components/footer/footer';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    GameCarousel,
    NavbarComponent,
    SecondaryNavbar,
    Footer,
  ],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {}

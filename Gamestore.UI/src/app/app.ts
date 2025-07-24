import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SecondaryNavbar } from './components/secondary-navbar/secondary-navbar';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, NavbarComponent, SecondaryNavbar],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {}

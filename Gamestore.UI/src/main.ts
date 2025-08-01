import { bootstrapApplication } from '@angular/platform-browser';
import { App } from './app/app';
import { importProvidersFrom } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { Home } from './app/pages/home/home';
import { GameDetail } from './app/pages/game-detail/game-detail';
import { Cart } from './app/pages/cart/cart';
import { Checkout } from './app/pages/checkout/checkout';
import { Error } from './app/pages/error/error';
import { provideHttpClient } from '@angular/common/http';

const routes: Routes = [
  { path: '', component: Home },
  { path: 'games/:id', component: GameDetail },
  { path: 'cart', component: Cart },
  { path: 'checkout', component: Checkout },
  { path: '**', component: Error },
];

bootstrapApplication(App, {
  providers: [
    importProvidersFrom(RouterModule.forRoot(routes)),
    provideHttpClient(),
  ],
}).catch((err) => console.error(err));

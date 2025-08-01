import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Game } from '../models/Game';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { Environment } from '../../environments/environments';

@Injectable({ providedIn: 'root' })
export class GameService {
  private readonly apiUrl = `${Environment.apiBaseUrl}/${Environment.endpoints.games}`;

  constructor(private http: HttpClient) {}

  getGames(): Observable<Game[]> {
    return this.http.get<Game[]>(this.apiUrl).pipe(
      catchError((error) => {
        console.error('Error fetching games', error);
        return throwError(() => error);
      })
    );
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from '../models/Category';
import { Environment } from '../../environments/environments';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CategoryService {
  private readonly apiUrl = `${Environment.apiBaseUrl}/${Environment.endpoints.categories}`;

  constructor(private http: HttpClient) {}

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl).pipe(
      catchError((error) => {
        console.error('Error fetching categories', error);
        return throwError(() => error);
      })
    );
  }
}

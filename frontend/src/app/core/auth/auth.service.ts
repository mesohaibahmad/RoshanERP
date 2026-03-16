import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { distinctUntilChanged, shareReplay, tap } from 'rxjs/operators';
import { User } from './user.model';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class AuthService {
  apiUrl = 'https://localhost:7232/api/auth';
  tokenKey = 'roshan_token';

  constructor(private readonly http: HttpClient, private router: Router) {}
private currentUserSubject = new BehaviorSubject<User | null>(null);
public currentUser = this.currentUserSubject.asObservable().pipe(distinctUntilChanged());
public isAuthenticated = this.currentUser.pipe(map(user => !!user));


  login(payload: any) {
    return this.http.post<{ token: string; user: User }>(`${this.apiUrl}/login`, payload).pipe(
      tap(res => { this.setAut(res); })
    );
  }

  register(payload: any) {
    return this.http.post(`${this.apiUrl}/register`, payload);
  }

  getCurrentUser(): Observable<{ user: User }> {
    return this.http.get<{ user: User }>(`${this.apiUrl}/user`).pipe(
      tap({
        next: ({ user }) => this.currentUserSubject.next(user),
        error: () => this.purgeAuth(),
      }),
      shareReplay(1),
    );
  }

  getToken() {
    return localStorage.getItem(this.tokenKey);
  }

  logout() {
this.purgeAuth();
this.router.navigate(['/login']);
  }

  setAut(response: any): void {
localStorage.setItem(this.tokenKey, response.token); 
this.currentUserSubject.next(response.user);
  }
purgeAuth(): void {
  localStorage.removeItem(this.tokenKey);
  this.currentUserSubject.next(null); 
}
}

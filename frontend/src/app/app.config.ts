// app.config.ts
import { ApplicationConfig, provideAppInitializer, inject } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { routes } from './app.routes';
import { AuthService } from './core/auth/auth.service';
import { tokenInterceptor } from './core/Interceptors/token.interceptor';
import { EMPTY } from 'rxjs';

export function initAuth(authService: AuthService) {
  return () => (authService.getToken() ? authService.getCurrentUser() : EMPTY);
}

// ApplicationConfig with providers
export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(withInterceptors([tokenInterceptor])),
    provideAppInitializer(() => initAuth(inject(AuthService))())
  ]
};

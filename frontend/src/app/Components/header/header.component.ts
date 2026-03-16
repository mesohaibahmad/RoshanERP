import { Component, inject } from '@angular/core';
import { AuthService } from '../../core/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
authService = inject(AuthService);
router = inject(Router);

logout() {
  this.authService.logout();
  this.router.navigate(['/login']);
}

toggleSidebar() {

}

}
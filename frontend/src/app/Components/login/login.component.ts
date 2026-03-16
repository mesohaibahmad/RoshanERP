import { Component } from '@angular/core';
import { AuthService } from '../../core/auth/auth.service';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [FormsModule, RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
constructor(private authService: AuthService, private router: Router) { }

email = '';
password = '';
error = '';

onSubmit() {

 
  const data = {
    id: 0,
    username: this.email,
    passwordHash: this.password,
    role: 'Admin'
  }

    console.log(data);
this.authService.login(data).subscribe(response => {
    this.router.navigate(['/sales-invoice']);
  }, error => {
    this.error = "Invalid Credentials";
  })

}
}

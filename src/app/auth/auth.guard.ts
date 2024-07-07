import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private cookieService: CookieService, private router: Router) { }

  canActivate(): boolean {
    const tokenExists = this.cookieService.check('jwtToken');
    if (tokenExists) {
      return true; // Allow navigation
    } else {
      this.router.navigate(['/login']); // Redirect to login page
      return false;
    }
  }
}

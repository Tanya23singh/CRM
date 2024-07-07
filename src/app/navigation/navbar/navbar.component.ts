import { Component, ElementRef, OnInit, Renderer2, ViewChild } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoginService } from 'src/app/services/loginservices/login.service';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  constructor(private LoginServie:LoginService,private cookieservice: CookieService,public authservice:AuthService){
    const tokenExists = this.cookieservice.check('jwtToken');
    if (tokenExists) { 
      this.authservice.login();
     }
  }
}

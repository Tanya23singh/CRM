import { Router } from '@angular/router';
import { LoginService } from './../../services/loginservices/login.service';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { jwtDecode } from 'jwt-decode';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username :string="";
  password:string=""
  errorMessage:string=""
  userid:string=""
  name:string=""
  constructor(private LoginService:LoginService,private cookieService:CookieService,private router: Router,public authservice :AuthService){
    
  }
  loginforall() {
  
this.LoginService.login(this.username,this.password).subscribe(
  (result) => {
    
    console.log(result);
    const token = result.token;
    // Store the token in a cookie with a name 'jwtToken'
    this.cookieService.set('jwtToken', token);
    this.authservice.login();
  
    if (token) {
      const decodedToken: any = jwtDecode(token);
      this.userid = decodedToken.NameIdentifier;
      this.name = decodedToken.username;
    }
    // After successful login, you can redirect if needed
    this.router.navigate(['/menu']);
  },
  (error) => {
this.errorMessage=error.error;
  })


  }




}

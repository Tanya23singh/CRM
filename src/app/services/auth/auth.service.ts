import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
isloggedin:boolean=false;
  constructor() { }
  login():void{
    
    this.isloggedin=true;
  }
  logout():void{
    
    this.isloggedin=false
  }
}

import { CookieService } from 'ngx-cookie-service';
import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {


  private apiUrl = 'https://localhost:7269/api/login/signin';
  constructor(private http: HttpClient,private CookieService:CookieService) { }

  login(username:string ,password:string):Observable<any>{
    const token=this.CookieService.get('jwtToken')
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

const logindata={username,password}
    return this.http.post<any>(this.apiUrl,logindata,{headers})
  }
getmenu(){
  const token=this.CookieService.get('jwtToken')
  const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
  return this.http.get<any>('https://localhost:7269/api/Menu/GetMenu',{headers})
}

}

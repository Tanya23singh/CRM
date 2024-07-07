import { LoginService } from 'src/app/services/loginservices/login.service';
import { Component } from '@angular/core';
import { AuthService } from 'src/app/services/auth/auth.service';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
interface Module {
  [module_name: string]: {
    component_name: string;
    component_id:number;
    module_id:number;
    _add: boolean;
    _update: boolean;
    _delete: boolean;
    _view: boolean;
    module_name: string;
    routes:string;
  }[];
}

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {

  MenuBind: Module[] = [];
  constructor(private router: Router,private cookieservice: CookieService,public authservice:AuthService ,private LoginService:LoginService) { 

    this.LoginService.getmenu().subscribe(
      (result) => {
          // Group elements by module name
    const groupedData: { [key: string]: any[] } = {};
    result.forEach((ele: any) => {
      if (!groupedData[ele.module_name]) {
        groupedData[ele.module_name] = [];
      }
      groupedData[ele.module_name].push(ele);
    });

    // Transform grouped data into the desired format for MenuBind
    this.MenuBind = Object.keys(groupedData).map((module_name: string) => ({
      [module_name]: groupedData[module_name]
    }));
    console.log(this.MenuBind); // Log MenuBind to see its structure
  },
  (error) => {
    // Handle error
  }
    );
    console.log(this.MenuBind)
  }
  sidebarActive: boolean = false;
  isMenuOpen: boolean = false;

  toggleSidebar(): void {
    this.sidebarActive = !this.sidebarActive;
  }
  
  toggleCollapse(): void {
    this.isMenuOpen = !this.isMenuOpen;
  }
  logout():void{

    this.cookieservice.delete("jwtToken");
    this.authservice.logout();
    this.router.navigate(['/login']);

  }
  getModuleName(module: any): string {
    return Object.keys(module)[0];
  }
}

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticationModule } from '../authentication/authentication.module';
import { LoginComponent } from '../authentication/login/login.component';
import { MenuComponent } from '../menu/menu/menu.component';
import { AuthGuard } from '../auth/auth.guard';
const routes: Routes = [

 
];


@NgModule({
  declarations: [
    NavbarComponent

  ],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)

  ],
  exports:[
    NavbarComponent
  ]
})
export class NavigationModule { }

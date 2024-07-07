import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

const routes: Routes = [
  // {
  //   path:'dashboard',
  //   component:DashboardComponent,
    
  // },
  // {
  //   path:'login',
  //   component:LoginComponent
  // },
 
];

@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forRoot(routes)

  ],

  exports:[
    LoginComponent
  ]
})
export class AuthenticationModule { }

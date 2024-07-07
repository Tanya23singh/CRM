import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './authentication/login/login.component';
import { MenuComponent } from './menu/menu/menu.component';
import { AuthGuard } from './auth/auth.guard';
import { PermissionComponent } from './AllFiles/Users/permission/permission.component';
import { RolesComponent } from './AllFiles/Users/roles/roles.component';

const routes: Routes = [
  {
  
    path:'login',
    component:LoginComponent,
    
  },

  { 
    path:'menu',
    component:MenuComponent,
    canActivate:[AuthGuard]

  }
  ,

  { 
    path:'menu/permissions',
    component:PermissionComponent,
    canActivate:[AuthGuard]

  }
  ,

  { 
    path:'menu/roles',
    component:RolesComponent,
    canActivate:[AuthGuard]

  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

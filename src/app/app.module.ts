import { NavigationModule } from './navigation/navigation.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CookieService } from 'ngx-cookie-service';
import { MenuComponent } from './menu/menu/menu.component';
import { PermissionComponent } from './AllFiles/Users/permission/permission.component';
import { RolesComponent } from './AllFiles/Users/roles/roles.component';
import { CommongridComponent } from './Common/commongrid/commongrid.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    PermissionComponent,
    RolesComponent,
    CommongridComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NavigationModule,
    NgbModule
  ],
  providers: [CookieService]
}
)
export class AppModule { }

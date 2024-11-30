import {Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import { AboutComponent } from './about/about.component';
import { LoginComponent } from './Account/login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,

  },
  {path: 'about', component: AboutComponent},
  { path: 'login', component: LoginComponent },
  { path: 'dashboard', component: DashboardComponent },

];
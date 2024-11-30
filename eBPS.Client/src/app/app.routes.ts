import {Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import { AboutComponent } from './about/about.component';
import { LoginComponent } from './Account/login/login.component';
import { SignupComponent } from './Account/signup/signup.component';
import { NavbarComponent } from '../shared/home-navbar/home-navbar.component';
import { FooterComponent } from '../shared/footer/footer.component';

import { DashboardComponent } from './dashboard/dashboard.component';
export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,

  },
  {path: 'home', component: HomeComponent},
  {path: 'about', component: AboutComponent},
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'navbar', component: NavbarComponent },
  { path: 'footer', component: FooterComponent },
  { path: 'dashboard', component: DashboardComponent },

];
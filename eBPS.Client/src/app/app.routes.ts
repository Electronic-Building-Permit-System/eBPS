import {Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import { AboutComponent } from './about/about.component';
import { LoginComponent } from './account/login/login.component';
import { SignupComponent } from './account/signup/signup.component';

import { DashboardComponent } from './dashboard/dashboard.component';
import { FooterComponent } from './shared/footer/footer.component';
import { HomeNavbarComponent } from './shared/home-navbar/home-navbar.component';
export const routes: Routes = [
  {
    path: '',
    component: LoginComponent,

  },
  {path: 'home', component: HomeComponent},
  {path: 'about', component: AboutComponent},
  { path: 'signup', component: SignupComponent },
  { path: 'navbar', component: HomeNavbarComponent },
  { path: 'footer', component: FooterComponent },
  { path: 'dashboard', component: DashboardComponent },

];
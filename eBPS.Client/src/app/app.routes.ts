import {Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';

import { DashboardComponent } from './dashboard/dashboard.component';
import { FooterComponent } from './shared/footer/footer.component';
import { HomeNavbarComponent } from './shared/home-navbar/home-navbar.component';
import { CreateapplicationComponent } from './dashboard/createapplication/createapplication.component';
import { LoginComponent } from './account/login/login.component';
import { SignupComponent } from './account/signup/signup.component';
import { AuthguardService } from './services/shared/authguard.service';

import { ForgotpasswordComponent } from './account/forgotpassword/forgotpassword.component';
export const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  },
  {path: 'home', component: HomeComponent},
  { path: 'navbar', component: HomeNavbarComponent },
  { path: 'footer', component: FooterComponent },
  { path: 'createapplication', component: CreateapplicationComponent },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthguardService] },
  { path: 'signup', component: SignupComponent },
  {path:'forgotpassword', component: ForgotpasswordComponent}
];
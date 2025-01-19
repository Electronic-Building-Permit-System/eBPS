import {Routes} from '@angular/router';
import { AuthguardService } from './guards/authguard.service';
import { HomeNavbarComponent } from './components/shared/home-navbar/home-navbar.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { ForgetpasswordComponent } from './components/account/forgetpassword/forgetpassword.component';
import { SignupComponent } from './components/account/signup/signup.component';
import { LoginComponent } from './components/account/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DesigndataComponent } from './components/dashboard/designdata/designdata.component';
import { CreateApplicationComponent } from './components/dashboard/createapplication/createapplication.component';
import { DetailapplicationComponent } from './components/dashboard/detailapplication/detailapplication.component';
export const routes: Routes = [
  { path: '',component: LoginComponent},
  { path: 'navbar', component: HomeNavbarComponent },
  { path: 'footer', component: FooterComponent },
  { path: 'createapplication', component: CreateApplicationComponent },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthguardService] },
  { path: 'signup', component: SignupComponent },
  { path:'forgotpassword', component: ForgetpasswordComponent},
  { path:'designdata', component: DesigndataComponent},
  { path:'detailapplication', component: DetailapplicationComponent}

];
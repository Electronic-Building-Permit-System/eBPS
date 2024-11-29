import {Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import { LoginComponent } from './Account/login/login.component';
export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,

  },
  { path: 'login', component: LoginComponent },
];
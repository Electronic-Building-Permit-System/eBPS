import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { of, throwError } from 'rxjs';
import { LoginComponent } from './login.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UserService } from '../../../services/account/user.service';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  let userServiceMock: any;
  let routerMock: any;

  beforeEach(async () => {
    userServiceMock = {
      login: jasmine.createSpy('login')
    };

    routerMock = {
      navigate: jasmine.createSpy('navigate')
    };

    await TestBed.configureTestingModule({
      declarations: [],
      imports: [
        LoginComponent,
        FormsModule,
        ReactiveFormsModule,
        MatInputModule,
        MatButtonModule,
        MatCardModule,
        MatSlideToggleModule,
        BrowserAnimationsModule
      ],
      providers: [
        { provide: UserService, useValue: userServiceMock },
        { provide: Router, useValue: routerMock },
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize the login form with default values', () => {
    const formValues = component.loginForm.value;
    expect(formValues.username).toBe('');
    expect(formValues.password).toBe('');
    expect(formValues.rememberMe).toBe(false);
  });

  it('should display an error message when login fails', () => {
    userServiceMock.login.and.returnValue(throwError({ error: 'Invalid credentials' }));

    component.loginForm.setValue({
      username: 'testuser',
      password: 'password',
      rememberMe: true
    });

    component.login();
    fixture.detectChanges();

    expect(component.errorMessage).toBe('Invalid username or password');
  });

  it('should navigate to /dashboard on successful login', () => {
    userServiceMock.login.and.returnValue(of(true));

    component.loginForm.setValue({
      username: 'testuser',
      password: 'password123',
      rememberMe: true
    });

    component.login();

    expect(routerMock.navigate).toHaveBeenCalledWith(['/dashboard']);
  });

  it('should navigate to /signup when navigateToSignUp is called', () => {
    component.navigateToSignUp();
    expect(routerMock.navigate).toHaveBeenCalledWith(['/signup']);
  });

  it('should validate the login form', () => {
    const form = component.loginForm;
    expect(form.valid).toBeFalse();

    form.setValue({
      username: 'validuser',
      password: 'validpass',
      rememberMe: false,
    });

    expect(form.valid).toBeTrue();
  });
});

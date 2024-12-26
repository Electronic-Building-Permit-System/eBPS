import { TestBed } from '@angular/core/testing';
import { AuthguardService } from './authguard.service';
import { UserService } from '../account/user.service';
import { Router } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';

describe('AuthguardService', () => {
  let service: AuthguardService;
  let userServiceMock: any;
  let routerMock: any;

  beforeEach(() => {
    // Mock UserService
    userServiceMock = {
      isLoggedIn: jasmine.createSpy('isLoggedIn').and.returnValue(false),
    };

    // Mock Router
    routerMock = {
      navigate: jasmine.createSpy('navigate'),
    };

    TestBed.configureTestingModule({
      providers: [
        AuthguardService,
        provideHttpClient(), // Use the new HttpClient provider
        { provide: UserService, useValue: userServiceMock },
        { provide: Router, useValue: routerMock },
      ],
    });

    service = TestBed.inject(AuthguardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should allow navigation if the user is logged in', () => {
    userServiceMock.isLoggedIn.and.returnValue(true); // Simulate logged-in user

    const result = service.canActivate();
    expect(result).toBeTrue();
    expect(routerMock.navigate).not.toHaveBeenCalled();
  });

  it('should block navigation and redirect if the user is not logged in', () => {
    userServiceMock.isLoggedIn.and.returnValue(false); // Simulate logged-out user

    const result = service.canActivate();
    expect(result).toBeFalse();
    expect(routerMock.navigate).toHaveBeenCalledWith(['']);
  });
});

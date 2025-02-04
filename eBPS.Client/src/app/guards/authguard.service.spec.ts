import { TestBed } from '@angular/core/testing';
import { UserService } from '../services/account/user.service';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { AuthguardService } from './authguard.service';

describe('AuthguardService', () => {
  let service: AuthguardService;
  let userServiceSpy: jasmine.SpyObj<UserService>;
  let routerSpy: jasmine.SpyObj<Router>;

  beforeEach(() => {
    const userSpy = jasmine.createSpyObj('UserService', ['isLoggedIn']);
    const routerMock = jasmine.createSpyObj('Router', ['navigate']);

    TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      providers: [
        AuthguardService,
        { provide: UserService, useValue: userSpy },
        { provide: Router, useValue: routerMock },
      ],
    });

    service = TestBed.inject(AuthguardService);
    userServiceSpy = TestBed.inject(UserService) as jasmine.SpyObj<UserService>;
    routerSpy = TestBed.inject(Router) as jasmine.SpyObj<Router>;
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  describe('canActivate', () => {
    it('should return true if user is logged in', () => {
      userServiceSpy.isLoggedIn.and.returnValue(true);

      expect(service.canActivate()).toBeTrue();
      expect(routerSpy.navigate).not.toHaveBeenCalled();
    });

    it('should navigate to the home page and return false if user is not logged in', () => {
      userServiceSpy.isLoggedIn.and.returnValue(false);

      expect(service.canActivate()).toBeFalse();
      expect(routerSpy.navigate).toHaveBeenCalledWith(['']);
    });
  });
});

import { HttpRequest, HttpHandlerFn, HttpEvent } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { jwtInterceptor } from './jwtinterceptor.service';
import { UserService } from '../services/account/user.service';

describe('jwtInterceptor', () => {
  let userService: jasmine.SpyObj<UserService>;

  beforeEach(() => {
    // Mock UserService
    userService = jasmine.createSpyObj('UserService', ['getToken']);

    TestBed.configureTestingModule({
      providers: [
        { provide: UserService, useValue: userService },
      ],
    });
  });

  it('should add Authorization header when token exists', () => {
    const token = 'test-token';
    userService.getToken.and.returnValue(token); // Mock token

    const mockRequest = new HttpRequest('GET', '/test');
    const mockHandler: HttpHandlerFn = (req) => {
      // Verify the Authorization header
      expect(req.headers.has('Authorization')).toBeTrue();
      expect(req.headers.get('Authorization')).toBe(`Bearer ${token}`);
      return of({} as HttpEvent<any>);
    };

    TestBed.runInInjectionContext(() => {
      // Call the interceptor within an injection context
      jwtInterceptor(mockRequest, mockHandler).subscribe();
    });
  });

  it('should not add Authorization header when token does not exist', () => {
    userService.getToken.and.returnValue(null); // Mock no token

    const mockRequest = new HttpRequest('GET', '/test');
    const mockHandler: HttpHandlerFn = (req) => {
      // Verify the Authorization header is not present
      expect(req.headers.has('Authorization')).toBeFalse();
      return of({} as HttpEvent<any>);
    };

    TestBed.runInInjectionContext(() => {
      // Call the interceptor within an injection context
      jwtInterceptor(mockRequest, mockHandler).subscribe();
    });
  });
});

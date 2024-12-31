import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { UserService } from './user.service';
import { environment } from '../../../environments/environment';

const mockApiUrl = environment.apiUrl;

describe('UserService', () => {
  let service: UserService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [UserService]
    });
    service = TestBed.inject(UserService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  describe('registerUser', () => {
    it('should make a POST request to register a user', () => {
      const mockUserData = { username: 'testuser', password: 'testpass' };
      const mockResponse = { message: 'User registered successfully' };

      service.registerUser(mockUserData).subscribe((response) => {
        expect(response).toEqual(mockResponse);
      });

      const req = httpTestingController.expectOne(`${mockApiUrl}/api/Account/register`);
      expect(req.request.method).toBe('POST');
      expect(req.request.body).toEqual(mockUserData);

      req.flush(mockResponse);
    });
  });

  describe('login', () => {
    it('should make a POST request to login and store the token', () => {
      const mockUserData = { username: 'testuser', password: 'testpass', rememberMe: true };
      const mockResponse = { token: 'mockJwtToken' };
    
      spyOn(localStorage, 'setItem');
    
      service.login({ ...mockUserData, value: { username: 'testuser', password: 'testpass' } }).subscribe((response) => {
        expect(response).toBeTrue();
        expect(localStorage.setItem).toHaveBeenCalledWith('jwtToken', 'mockJwtToken');
      });
    
      const req = httpTestingController.expectOne(`${mockApiUrl}/api/Account/login`);
      expect(req.request.method).toBe('POST');
      expect(req.request.body).toEqual({ username: 'testuser', password: 'testpass' });
    
      req.flush(mockResponse);
    });
    

    it('should return false if no token is provided in the response', () => {
      const mockUserData = { username: 'testuser', password: 'testpass' };
      const mockResponse = {};

      service.login(mockUserData).subscribe((response) => {
        expect(response).toBeFalse();
      });

      const req = httpTestingController.expectOne(`${mockApiUrl}/api/Account/login`);
      req.flush(mockResponse);
    });
  });

  describe('logout', () => {
    it('should remove the token from localStorage', () => {
      spyOn(localStorage, 'removeItem');

      service.logout();

      expect(localStorage.removeItem).toHaveBeenCalledWith('jwtToken');
    });
  });

  describe('isLoggedIn', () => {
    it('should return true if a token exists in localStorage', () => {
      spyOn(localStorage, 'getItem').and.returnValue('mockJwtToken');

      expect(service.isLoggedIn()).toBeTrue();
    });

    it('should return false if no token exists in localStorage', () => {
      spyOn(localStorage, 'getItem').and.returnValue(null);

      expect(service.isLoggedIn()).toBeFalse();
    });
  });

  describe('getToken', () => {
    it('should return the token from localStorage', () => {
      spyOn(localStorage, 'getItem').and.returnValue('mockJwtToken');

      expect(service.getToken()).toBe('mockJwtToken');
    });

    it('should return null if no token exists in localStorage', () => {
      spyOn(localStorage, 'getItem').and.returnValue(null);

      expect(service.getToken()).toBeNull();
    });
  });
});

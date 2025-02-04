import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { EmailService } from './email.service';
import { environment } from '../../../environments/environment';

describe('EmailService', () => {
  let service: EmailService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [EmailService],
    });

    service = TestBed.inject(EmailService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify(); // Ensure no unmatched requests remain
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should send a POST request to the correct URL with the correct payload', () => {
    const payload = {
      to: 'test@example.com',
      subject: 'Password Reset',
      body: 'Click the link to reset your password.',
    };

    const mockResponse = { message: 'Email sent successfully' };

    // Call the service method
    service.sendResetLink(payload).subscribe((response) => {
      expect(response).toEqual(mockResponse); // Verify the response
    });

    // Expect a POST request
    const req = httpTestingController.expectOne(environment.apiUrl + '/api/account/forget-password');
    expect(req.request.method).toBe('POST'); // Verify the HTTP method
    expect(req.request.body).toEqual(payload); // Verify the request payload

    // Flush the mock response
    req.flush(mockResponse);
  });
});

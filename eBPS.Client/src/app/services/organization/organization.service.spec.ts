import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { OrganizationService } from './organization.service';
import { environment } from '../../../environments/environment';

describe('OrganizationService', () => {
  let service: OrganizationService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [OrganizationService]
    });
    service = TestBed.inject(OrganizationService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  describe('getOrganization', () => {
    it('should make a GET request to fetch organizations', () => {
      const mockResponse = [{ id: 1, name: 'Org1' }, { id: 2, name: 'Org2' }];

      service.getOrganization().subscribe((response) => {
        expect(response).toEqual(mockResponse);
      });

      const req = httpTestingController.expectOne(`${environment.apiUrl}/api/organizations`);
      expect(req.request.method).toBe('GET');

      req.flush(mockResponse);
    });
  });

  describe('getUserOrganization', () => {
    it('should make a GET request to fetch user organization', () => {
      const mockResponse = { id: 1, name: 'UserOrg' };

      service.getUserOrganization().subscribe((response) => {
        expect(response).toEqual(mockResponse);
      });

      const req = httpTestingController.expectOne(`${environment.apiUrl}/api/organizations/user-organization`);
      expect(req.request.method).toBe('GET');

      req.flush(mockResponse);
    });
  });
});

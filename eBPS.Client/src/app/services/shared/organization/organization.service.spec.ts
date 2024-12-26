import { TestBed } from '@angular/core/testing';

import { OrganizationService } from './organization.service';
import { provideHttpClient } from '@angular/common/http';

describe('OrganizationService', () => {
  let service: OrganizationService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [provideHttpClient()]
    });
    service = TestBed.inject(OrganizationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

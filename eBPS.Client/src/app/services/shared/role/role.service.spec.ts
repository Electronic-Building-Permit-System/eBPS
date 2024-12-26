import { TestBed } from '@angular/core/testing';

import { RoleService } from './role.service';
import { provideHttpClient } from '@angular/common/http';

describe('RoleService', () => {
  let service: RoleService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [provideHttpClient()]
    });
    service = TestBed.inject(RoleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed, ComponentFixture } from '@angular/core/testing';
import { NavbarComponent } from './navbar.component';
import { OrganizationService } from '../../services/shared/organization/organization.service';
import { RoleService } from '../../services/shared/role/role.service';
import { UserService } from '../../services/account/user.service';
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';

describe('NavbarComponent', () => {
  let component: NavbarComponent;
  let fixture: ComponentFixture<NavbarComponent>;
  let mockOrganizationService: jasmine.SpyObj<OrganizationService>;
  let mockRoleService: jasmine.SpyObj<RoleService>;
  let mockUserService: jasmine.SpyObj<UserService>;
  let mockRouter: jasmine.SpyObj<Router>;

  beforeEach(async () => {
    mockOrganizationService = jasmine.createSpyObj('OrganizationService', ['getUserOrganization']);
    mockRoleService = jasmine.createSpyObj('RoleService', ['getRoles']);
    mockUserService = jasmine.createSpyObj('UserService', ['logout']);
    mockRouter = jasmine.createSpyObj('Router', ['navigate']);

    // Mock methods to return observables
    mockOrganizationService.getUserOrganization.and.returnValue(of([])); // Return an empty array by default
    mockRoleService.getRoles.and.returnValue(of([])); // Return an empty array by default

    await TestBed.configureTestingModule({
      imports: [
        NavbarComponent, // Import the standalone component
        MatToolbarModule,
        MatButtonModule,
        MatMenuModule,
        CommonModule,
        MatIconModule
      ],
      providers: [
        { provide: OrganizationService, useValue: mockOrganizationService },
        { provide: RoleService, useValue: mockRoleService },
        { provide: UserService, useValue: mockUserService },
        { provide: Router, useValue: mockRouter },
      ],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NavbarComponent);
    component = fixture.componentInstance;
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should fetch organizations on initialization', () => {
    const mockOrganizations = [
      { id: 1, name: 'Org 1' },
      { id: 2, name: 'Org 2' },
    ];
    mockOrganizationService.getUserOrganization.and.returnValue(of(mockOrganizations));

    component.ngOnInit();

    expect(mockOrganizationService.getUserOrganization).toHaveBeenCalled();
    expect(component.organizations).toEqual(mockOrganizations);
  });

  it('should fetch roles on initialization', () => {
    const mockRoles = [
      { id: 1, name: 'Role 1' },
      { id: 2, name: 'Role 2' },
    ];
    mockRoleService.getRoles.and.returnValue(of(mockRoles));

    component.ngOnInit();

    expect(mockRoleService.getRoles).toHaveBeenCalled();
    expect(component.roles).toEqual(mockRoles);
  });

  it('should update selected organization when onSelectOrganization is called', () => {
    const mockOrganization = { id: 1, name: 'Org 1' };

    component.onSelectOrganization(mockOrganization);

    expect(component.selectedOrganization).toEqual(mockOrganization.name);
  });

  it('should call userService.logout and navigate to home on logout', () => {
    component.logout();

    expect(mockUserService.logout).toHaveBeenCalled();
    expect(mockRouter.navigate).toHaveBeenCalledWith(['']);
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NavbarComponent } from './navbar.component';
import { Router } from '@angular/router';
import { OrganizationService } from '../../services/shared/organization/organization.service';
import { RoleService } from '../../services/shared/role/role.service';
import { UserService } from '../../services/account/user.service';
import { of } from 'rxjs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';

describe('NavbarComponent', () => {
  let component: NavbarComponent;
  let fixture: ComponentFixture<NavbarComponent>;

  let organizationServiceSpy: jasmine.SpyObj<OrganizationService>;
  let roleServiceSpy: jasmine.SpyObj<RoleService>;
  let userServiceSpy: jasmine.SpyObj<UserService>;
  let routerSpy: jasmine.SpyObj<Router>;

  beforeEach(async () => {
    organizationServiceSpy = jasmine.createSpyObj('OrganizationService', ['getOrganization']);
    roleServiceSpy = jasmine.createSpyObj('RoleService', ['getRoles']);
    userServiceSpy = jasmine.createSpyObj('UserService', ['logout']);
    routerSpy = jasmine.createSpyObj('Router', ['navigate']);

    organizationServiceSpy.getOrganization.and.returnValue(
      of([{ id: 1, name: 'Org 1' }, { id: 2, name: 'Org 2' }])
    );
    roleServiceSpy.getRoles.and.returnValue(
      of([{ id: 1, name: 'Admin' }, { id: 2, name: 'User' }])
    );

    await TestBed.configureTestingModule({
      imports: [
        NavbarComponent,
        MatToolbarModule,
        MatMenuModule,
        MatButtonModule,
        MatIconModule,
        CommonModule,
      ],
      providers: [
        { provide: OrganizationService, useValue: organizationServiceSpy },
        { provide: RoleService, useValue: roleServiceSpy },
        { provide: UserService, useValue: userServiceSpy },
        { provide: Router, useValue: routerSpy },
      ],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should fetch organizations on init', () => {
    expect(organizationServiceSpy.getOrganization).toHaveBeenCalled();
    expect(component.organizations).toEqual([
      { id: 1, name: 'Org 1' },
      { id: 2, name: 'Org 2' },
    ]);
  });

  it('should fetch roles on init', () => {
    expect(roleServiceSpy.getRoles).toHaveBeenCalled();
    expect(component.roles).toEqual([
      { id: 1, name: 'Admin' },
      { id: 2, name: 'User' },
    ]);
  });

  it('should set the selected organization', () => {
    const org = { id: 1, name: 'Org 1' };
    component.onSelectOrganization(org);
    expect(component.selectedOrganization).toBe('Org 1');
  });

  it('should log out and navigate to login page', () => {
    component.logout();
    expect(userServiceSpy.logout).toHaveBeenCalled();
    expect(routerSpy.navigate).toHaveBeenCalledWith(['']);
  });
});
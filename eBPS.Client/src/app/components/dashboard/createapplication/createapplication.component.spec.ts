import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { MatStepperModule } from '@angular/material/stepper';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { Router } from '@angular/router';
import { of, throwError } from 'rxjs';
import { CreateApplicationComponent } from './createapplication.component';
import { ApplicationService } from '../../../services/application/application.service';

describe('CreateapplicationComponent', () => {
  let component: CreateApplicationComponent;
  let fixture: ComponentFixture<CreateApplicationComponent>;
  let mockApplicationService: jasmine.SpyObj<ApplicationService>;
  let mockRouter: jasmine.SpyObj<Router>;

  beforeEach(async () => {
    mockApplicationService = jasmine.createSpyObj('ApplicationService', ['createBuildingApplication']);
    mockRouter = jasmine.createSpyObj('Router', ['navigate']);

    await TestBed.configureTestingModule({
      imports: [
        CreateApplicationComponent, // Import the standalone component
        ReactiveFormsModule,
        MatStepperModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatSelectModule,
        MatIconModule,
      ],
      providers: [
        { provide: ApplicationService, useValue: mockApplicationService },
        { provide: Router, useValue: mockRouter },
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(CreateApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize forms on ngOnInit', () => {
    component.ngOnInit();
    expect(component.firstFormGroup).toBeDefined();
    expect(component.secondFormGroup).toBeDefined();
    expect(component.landInformationForm.length).toBeGreaterThan(0);
    expect(component.landOwnerForm.length).toBeGreaterThan(0);
    expect(component.houseOwnerForm.length).toBeGreaterThan(0);
    expect(component.charkillaForm.length).toBeGreaterThan(0);
  });

  it('should add a new dynamic form', () => {
    const initialLength = component.landInformationForm.length;
    component.addNewForm();
    expect(component.landInformationForm.length).toBe(initialLength + 1);
  });


  it('should remove a dynamic form', () => {
    component.addNewForm();
    const initialLength = component.landInformationForm.length;
    component.removeForm(0);
    expect(component.landInformationForm.length).toBe(initialLength - 1);
  });

  it('should not remove a dynamic form if only one exists', () => {
    component.landInformationForm.clear();
    component.addNewForm();
    const initialLength = component.landInformationForm.length;
    component.removeForm(0);
    expect(component.landInformationForm.length).toBe(initialLength);
  });

  it('should call applicationService on valid form submission', () => {
    mockApplicationService.createBuildingApplication.and.returnValue(of({}));
    component.firstFormGroup.setValue({
      transactionType: 'Type1',
      buildingPurpose: 'Residential',
      nbcClass: 'Class1',
      landUseZone: 'Zone1',
      landUseSubZone: 'SubZone1',
      structureType: 'Structure1',
    });
    component.secondFormGroup.setValue({
      salutation: 'Mr.',
      applicantName: 'John Doe',
      wardNumber: '1',
      address: '123 Street',
      houseNumber: '456',
      phoneNumber: '1234567890',
      email: 'john@example.com',
    });

    component.submitForm();
    expect(mockApplicationService.createBuildingApplication).toHaveBeenCalled();
  });

  it('should navigate to dashboard on successful form submission', () => {
    mockApplicationService.createBuildingApplication.and.returnValue(of({}));
    component.submitForm();
    expect(mockRouter.navigate).toHaveBeenCalledWith(['/dashboard']);
  });

  it('should handle form submission errors', () => {
    mockApplicationService.createBuildingApplication.and.returnValue(throwError(() => new Error('Error')));
    spyOn(console, 'error');
    component.submitForm();
    expect(console.error).toHaveBeenCalledWith('Error creating application:', jasmine.any(Error));
  });

  it('should display an alert on successful submission', () => {
    spyOn(window, 'alert');
    mockApplicationService.createBuildingApplication.and.returnValue(of({}));
    component.submitForm();
    expect(window.alert).toHaveBeenCalledWith('Form submitted successfully!');
  });

  it('should not submit if forms are invalid', () => {
    spyOn(console, 'log');
    component.submitForm();
    expect(console.log).toHaveBeenCalledWith('Form is invalid');
    expect(mockApplicationService.createBuildingApplication).not.toHaveBeenCalled();
  });
});

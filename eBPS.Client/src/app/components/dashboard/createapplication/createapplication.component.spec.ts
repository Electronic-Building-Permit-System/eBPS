import {
  ComponentFixture,
  TestBed,
  fakeAsync,
  tick,
} from '@angular/core/testing';
import { CreateApplicationComponent } from './createapplication.component';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ApplicationService } from '../../../services/application/application.service';
import { MatStepperModule } from '@angular/material/stepper';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { LandInformationComponent } from './land-information/land-information.component';
import { LandOwnerComponent } from './land-owner/land-owner.component';
import { HouseOwnerComponent } from './house-owner/house-owner.component';
import { CharkillaComponent } from './charkilla/charkilla.component';
import { ApplicationDetailsComponent } from './application-details/application-details.component';
import { ApplicantDetailsComponent } from './applicant-details/applicant-details.component';
import { of, throwError } from 'rxjs';
import { RouterTestingModule } from '@angular/router/testing';
import NepaliDate from 'nepali-date-converter';
import { provideHttpClient } from '@angular/common/http';

describe('CreateApplicationComponent', () => {
  let component: CreateApplicationComponent;
  let fixture: ComponentFixture<CreateApplicationComponent>;
  let applicationService: jasmine.SpyObj<ApplicationService>;
  let router: Router;

  beforeEach(async () => {
    const applicationServiceSpy = jasmine.createSpyObj('ApplicationService', [
      'createBuildingApplication',
      'calculateTotals',
      'getIssueDistrict',
      'getWard',
      'getLandscapeType',
      'getBuildingPurpose',
      'getNBCClass',
      'getStructureType',
      'getLandUseSubZone',
      'getLandUseZone',
      'getTransactionType',
    ]);

    await TestBed.configureTestingModule({
      imports: [
        CommonModule,
        ReactiveFormsModule,
        MatStepperModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatSelectModule,
        MatIconModule,
        NoopAnimationsModule,
        RouterTestingModule,
        // Import standalone components
        LandInformationComponent,
        LandOwnerComponent,
        HouseOwnerComponent,
        CharkillaComponent,
        ApplicationDetailsComponent,
        ApplicantDetailsComponent,
      ],
      providers: [
        FormBuilder,
        { provide: ApplicationService, useValue: applicationServiceSpy },
        provideHttpClient(),
      ],
    }).compileComponents();

    applicationService = TestBed.inject(
      ApplicationService
    ) as jasmine.SpyObj<ApplicationService>;
    router = TestBed.inject(Router);
    // Mock the getIssueDistrict method
    applicationService.getIssueDistrict.and.returnValue(of([]));
    applicationService.getWard.and.returnValue(of([]));
    applicationService.getLandscapeType.and.returnValue(of([]));
    applicationService.getBuildingPurpose.and.returnValue(of([]));
    applicationService.getNBCClass.and.returnValue(of([]));
    applicationService.getStructureType.and.returnValue(of([]));
    applicationService.getLandUseSubZone.and.returnValue(of([]));
    applicationService.getLandUseZone.and.returnValue(of([]));
    applicationService.getTransactionType.and.returnValue(of([]));
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize all form groups', () => {
    expect(component.applicationDetailsForm).toBeDefined();
    expect(component.applicantDetailsForm).toBeDefined();
    expect(component.landInformationForm).toBeDefined();
    expect(component.landOwnerForm).toBeDefined();
    expect(component.houseOwnerForm).toBeDefined();
    expect(component.charkillaForm).toBeDefined();
  });

  it('should have initial dynamic forms', () => {
    expect(component.landInformationForm.length).toBe(1);
    expect(component.landOwnerForm.length).toBe(1);
    expect(component.houseOwnerForm.length).toBe(1);
    expect(component.charkillaForm.length).toBe(1);
  });

  describe('Form Validation', () => {
    it('applicationDetailsForm should have required validators', () => {
      const form = component.applicationDetailsForm;
      expect(form.get('transactionType')?.hasError('required')).toBeTruthy();
      expect(form.get('landLongitude')?.hasError('required')).toBeTruthy();
    });

    it('applicantDetailsForm should have required validators', () => {
      const form = component.applicantDetailsForm;
      expect(form.get('applicantName')?.hasError('required')).toBeTruthy();
      expect(form.get('phoneNumber')?.hasError('required')).toBeTruthy();
    });
  });

  describe('Dynamic Form Handling', () => {
    it('should add new land information form', () => {
      component.addNewLandInformationForm();
      expect(component.landInformationForm.length).toBe(2);
    });

    it('should not remove last land information form', () => {
      component.removeFormGroup(component.landInformationForm, 0);
      expect(component.landInformationForm.length).toBe(1);
    });

    it('should add new land owner form', () => {
      component.addNewLandOwnerForm();
      expect(component.landOwnerForm.length).toBe(2);
    });
  });

  describe('Totals Calculation', () => {
    it('should update totals when land information changes', () => {
      const mockTotals = {
        totalRopani: 1,
        totalAana: 2,
        totalPaisa: 3,
        totalDaam: 4,
        totalSquareFeet: 100,
        totalSquareMeter: 10,
      };

      applicationService.calculateTotals.and.returnValue(mockTotals);

      component.landInformationForm.at(0).patchValue({
        ropani: 1,
        aana: 2,
        paisa: 3,
        daam: 4,
        squareFeet: 100,
        squareMeter: 10,
      });

      expect(component.totals).toEqual(mockTotals);
    });
  });

  describe('Form Submission', () => {
    it('should submit valid form', fakeAsync(() => {
      spyOn(router, 'navigate');
      applicationService.createBuildingApplication.and.returnValue(of({}));

      // Fill required fields
      component.applicationDetailsForm.patchValue({
        transactionType: 'NEW',
        buildingPurpose: 'RESIDENTIAL',
        nbcClass: 'A',
        landUseZone: 'URBAN',
        landUseSubZone: 'CORE',
        structureType: 'RCC',
        landLongitude: 85.324,
        landLatitude: 27.717,
        landSawikWard: '5',
        landSawikGabisa: '10',
        landToleName: 'Main Tole',
        wardNumber: '3',
      });

      const nepaliDate = new NepaliDate(2080, 1, 1);
      component.applicantDetailsForm.patchValue({
        salutation: 'MR',
        applicantName: 'John Doe',
        applicationNumber: 'APP-001',
        fatherName: 'John Doe Sr.',
        grandFatherName: 'John Doe Jr.',
        tole: 'Main Tole',
        phoneNumber: '9841234567',
        email: 'test@example.com',
        citizenshipNumber: '123-45',
        citizenshipIssueDate: nepaliDate,
        citizenshipIssueDistrict: 'Kathmandu',
        wardNumber: '5',
        address: 'Kathmandu',
        houseNumber: '123',
      });

      component.submitForm();
      tick();

      expect(applicationService.createBuildingApplication).toHaveBeenCalled();
      expect(router.navigate).toHaveBeenCalledWith(['/dashboard']);
    }));

    it('should handle submission error', fakeAsync(() => {
      // Mock the service to return an error
      applicationService.createBuildingApplication.and.returnValue(
        throwError(() => new Error('Test Error'))
      );
  
      // Spy on console.error to verify it's called
      spyOn(console, 'error');
  
      // Fill required fields in applicationDetailsForm
      component.applicationDetailsForm.patchValue({
        transactionType: 'NEW',
        buildingPurpose: 'RESIDENTIAL',
        nbcClass: 'A',
        landUseZone: 'URBAN',
        landUseSubZone: 'CORE',
        structureType: 'RCC',
        landLongitude: 85.324,
        landLatitude: 27.717,
        landSawikWard: '5',
        landSawikGabisa: '10',
        landToleName: 'Main Tole',
        wardNumber: '3',
      });
  
      // Fill required fields in applicantDetailsForm
      const nepaliDate = new NepaliDate(2080, 1, 1); // Create a NepaliDate instance
      component.applicantDetailsForm.patchValue({
        salutation: 'MR',
        applicantName: 'John Doe',
        applicationNumber: 'APP-001',
        fatherName: 'John Doe Sr.',
        grandFatherName: 'John Doe Jr.',
        tole: 'Main Tole',
        phoneNumber: '9841234567',
        email: 'test@example.com',
        citizenshipNumber: '123-45',
        citizenshipIssueDate: nepaliDate, // Use NepaliDate instance
        citizenshipIssueDistrict: 'Kathmandu',
        wardNumber: '5',
        address: 'Kathmandu',
        houseNumber: '123',
      });
  
      // Trigger form submission
      component.submitForm();
      tick(); // Simulate async completion
  
      // Verify that console.error was called with the expected arguments
      expect(console.error).toHaveBeenCalledWith(
        'Error creating application:',
        jasmine.any(Error)
      );
    }));
  });

  describe('Navigation', () => {
    it('should navigate to dashboard on back button click', () => {
      const navigateSpy = spyOn(router, 'navigate');
      component.navigateToDashboard();
      expect(navigateSpy).toHaveBeenCalledWith(['/dashboard']);
    });
  });
});

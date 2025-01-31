import { ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';
import { CreateApplicationComponent } from './createapplication.component';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ApplicationService } from '../../../services/application/application.service';
import { Router } from '@angular/router';
import { of, throwError } from 'rxjs';
import { MatStepperModule } from '@angular/material/stepper';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import NepaliDate from 'nepali-date-converter';
import { provideHttpClient } from '@angular/common/http';

describe('CreateApplicationComponent', () => {
  let component: CreateApplicationComponent;
  let fixture: ComponentFixture<CreateApplicationComponent>;
  let applicationService: jasmine.SpyObj<ApplicationService>;
  let router: jasmine.SpyObj<Router>;
  let formBuilder: FormBuilder;

  beforeEach(async () => {
    const applicationServiceSpy = jasmine.createSpyObj('ApplicationService', ['createBuildingApplication', 'calculateTotals']);
    const routerSpy = jasmine.createSpyObj('Router', ['navigate']);

    await TestBed.configureTestingModule({
      imports: [
        CreateApplicationComponent,
        ReactiveFormsModule,
        MatStepperModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatSelectModule,
        MatIconModule,
        CommonModule,
        NoopAnimationsModule
      ],
      providers: [
        FormBuilder,
        { provide: ApplicationService, useValue: applicationServiceSpy },
        { provide: Router, useValue: routerSpy },
        provideHttpClient()
      ]
    }).compileComponents();

    applicationService = TestBed.inject(ApplicationService) as jasmine.SpyObj<ApplicationService>;
    router = TestBed.inject(Router) as jasmine.SpyObj<Router>;
    formBuilder = TestBed.inject(FormBuilder);
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  describe('Form Initialization', () => {
    it('should initialize applicationDetailsForm with required controls', () => {
      expect(component.applicationDetailsForm.contains('transactionType')).toBeTrue();
      expect(component.applicationDetailsForm.get('transactionType')?.hasValidator(Validators.required)).toBeTrue();
      
      expect(component.applicationDetailsForm.contains('landLongitude')).toBeTrue();
      expect(component.applicationDetailsForm.get('landLongitude')?.hasValidator(Validators.required)).toBeTrue();
    });

    it('should initialize applicantDetailsForm with required controls', () => {
      expect(component.applicantDetailsForm.contains('applicantName')).toBeTrue();
      expect(component.applicantDetailsForm.get('applicantName')?.hasValidator(Validators.required)).toBeTrue();
    });

    it('should initialize dynamic form arrays with at least one entry', () => {
      expect(component.landInformationForm.controls.length).toBe(1);
      expect(component.landOwnerForm.controls.length).toBe(1);
      expect(component.houseOwnerForm.controls.length).toBe(1);
      expect(component.charkillaForm.controls.length).toBe(1);
    });
  });

  describe('Form Manipulation', () => {
    it('should add new land information form', () => {
      const initialLength = component.landInformationForm.controls.length;
      component.addNewLandInformationForm();
      expect(component.landInformationForm.controls.length).toBe(initialLength + 1);
    });

    it('should remove land information form when multiple exist', () => {
      component.addNewLandInformationForm();
      const initialLength = component.landInformationForm.controls.length;
      component.removeFormGroup(component.landInformationForm, 0);
      expect(component.landInformationForm.controls.length).toBe(initialLength - 1);
    });

    it('should not remove last land information form', () => {
      const initialLength = component.landInformationForm.controls.length;
      component.removeFormGroup(component.landInformationForm, 0);
      expect(component.landInformationForm.controls.length).toBe(initialLength);
    });
  });

  describe('Form Submission', () => {
    beforeEach(() => {
      // Mock valid form data
      component.applicationDetailsForm.patchValue({
        transactionType: 'NEW',
        buildingPurpose: 'RESIDENTIAL',
        // ... populate all required fields
      });

      component.applicantDetailsForm.patchValue({
        applicantName: 'Test User',
        citizenshipNumber: '123-456',
        // ... populate all required fields
      });

      applicationService.createBuildingApplication.and.returnValue(of({}));
    });

    it('should submit valid form', () => {
      component.submitForm();
      expect(applicationService.createBuildingApplication).toHaveBeenCalled();
    });

    it('should navigate to dashboard on successful submission', () => {
      component.submitForm();
      expect(router.navigate).toHaveBeenCalledWith(['/dashboard']);
    });

    it('should handle submission error', () => {
      applicationService.createBuildingApplication.and.returnValue(throwError(() => new Error('Test Error')));
      component.submitForm();
      expect(applicationService.createBuildingApplication).toHaveBeenCalled();
    });

    it('should not submit invalid form', () => {
      component.applicationDetailsForm.reset();
      component.submitForm();
      expect(applicationService.createBuildingApplication).not.toHaveBeenCalled();
    });
  });

  describe('Data Preparation', () => {
    it('should prepare form data correctly', () => {
      const testDate = NepaliDate.now; // Example Nepali date
      component.applicantDetailsForm.patchValue({
        citizenshipIssueDate: testDate
      });

      const preparedData = component.prepareFormData();
      
      expect(preparedData.applicantDetails.citizenshipIssueDateBS).toBe('2081-01-01');
      expect(preparedData.landInformationList.length).toBe(1);
      expect(preparedData.houseOwnerList.length).toBe(1);
    });
  });

  describe('Validation', () => {
    it('should validate decimal fields', () => {
      const control = component.applicationDetailsForm.get('landLongitude');
      control?.setValue('invalid');
      expect(control?.hasError('pattern')).toBeTrue();
      
      control?.setValue('123.45');
      expect(control?.hasError('pattern')).toBeFalse();
    });
  });

  describe('Totals Calculation', () => {
    it('should update totals when land information changes', () => {
      applicationService.calculateTotals.and.returnValue({
        totalRopani: 2,
        totalAana: 4,
        totalPaisa: 6,
        totalDaam: 8,
        totalSquareFeet: 100,
        totalSquareMeter: 10
      });

      component.landInformationForm.at(0).patchValue({ ropani: 2 });
      expect(applicationService.calculateTotals).toHaveBeenCalled();
      expect(component.totals.totalRopani).toBe(2);
    });
  });
});
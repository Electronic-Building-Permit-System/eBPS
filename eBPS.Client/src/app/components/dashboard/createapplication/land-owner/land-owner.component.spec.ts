import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LandOwnerComponent } from './land-owner.component';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatStepperModule } from '@angular/material/stepper';
import { ApplicationService } from '../../../../services/application/application.service';
import { of } from 'rxjs';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { CdkStepper } from '@angular/cdk/stepper';
import { ChangeDetectorRef, ElementRef } from '@angular/core';

describe('LandOwnerComponent', () => {
  let component: LandOwnerComponent;
  let fixture: ComponentFixture<LandOwnerComponent>;
  let applicationService: jasmine.SpyObj<ApplicationService>;
  let formBuilder: FormBuilder;

  beforeEach(async () => {
    const applicationServiceSpy = jasmine.createSpyObj('ApplicationService', [
      'getIssueDistrict',
      'getWard',
    ]);

    await TestBed.configureTestingModule({
      imports: [
        LandOwnerComponent,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatSelectModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatStepperModule,
        NoopAnimationsModule,
      ],
      providers: [
        FormBuilder,
        { provide: ApplicationService, useValue: applicationServiceSpy },
        CdkStepper,
        ChangeDetectorRef,
        { provide: ElementRef, useValue: jasmine.createSpyObj('ElementRef', ['nativeElement']) },
      ],
    }).compileComponents();

    applicationService = TestBed.inject(ApplicationService) as jasmine.SpyObj<ApplicationService>;
    formBuilder = TestBed.inject(FormBuilder);
    // Mock the service methods to return observables
    applicationServiceSpy.getIssueDistrict.and.returnValue(of([])); // Return an empty array or mock data
    applicationServiceSpy.getWard.and.returnValue(of([]));
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LandOwnerComponent);
    component = fixture.componentInstance;

    // Initialize the form array with a sample form group
    component.landOwnerForm = new FormArray([
      formBuilder.group({
        landOwnerType: [''],
        salutation: [''],
        landOwnerName: [''],
        fatherName: [''],
        grandFatherName: [''],
        citizenshipNumber: [''],
        citizenshipIssueDistrict: [''],
        citizenshipIssueDate: [''],
        address: [''],
        tole: [''],
        wardNumber: [''],
        phoneNumber: [''],
        email: [''],
      }),
    ]);

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize and fetch issue district and ward data', () => {
    // Mock data for issue district and ward
    const mockIssueDistrict = [{ id: 1, description: 'Kathmandu' }];
    const mockWard = [{ id: 1, wardNumber: '1' }];

    // Mock service methods to return test data
    applicationService.getIssueDistrict.and.returnValue(of(mockIssueDistrict));
    applicationService.getWard.and.returnValue(of(mockWard));

    // Trigger ngOnInit
    component.ngOnInit();

    // Verify that the service methods were called
    expect(applicationService.getIssueDistrict).toHaveBeenCalled();
    expect(applicationService.getWard).toHaveBeenCalled();

    // Verify that the component processed the data correctly
    expect(component.issueDistrict).toEqual(mockIssueDistrict);
    expect(component.ward).toEqual(mockWard);
  });

  it('should cast control to FormGroup using asFormGroup', () => {
    const control = component.landOwnerForm.at(0);
    const formGroup = component.asFormGroup(control);

    expect(formGroup).toBeInstanceOf(FormGroup);
  });

  it('should emit addForm event when onAddForm is called', () => {
    spyOn(component.addForm, 'emit');
    component.onAddForm();

    expect(component.addForm.emit).toHaveBeenCalled();
  });

  it('should emit removeForm event when onRemoveForm is called', () => {
    spyOn(component.removeForm, 'emit');
    const index = 0;
    component.onRemoveForm(index);

    expect(component.removeForm.emit).toHaveBeenCalledWith(index);
  });

  it('should render the form controls correctly', () => {
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('mat-select[formControlName="landOwnerType"]')).toBeTruthy();
    expect(compiled.querySelector('input[formControlName="landOwnerName"]')).toBeTruthy();
    expect(compiled.querySelector('button[mat-raised-button]')).toBeTruthy();
  });

  it('should render the correct number of form groups', () => {
    const compiled = fixture.nativeElement;
    const formGroups = compiled.querySelectorAll('.landOwnerForm');
    expect(formGroups.length).toBe(component.landOwnerForm.length);
  });
});
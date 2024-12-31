import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicantDetailsComponent } from './applicant-details.component';
import { ChangeDetectorRef, ElementRef } from '@angular/core';
import { CdkStepper } from '@angular/cdk/stepper';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

describe('ApplicantDetailsComponent', () => {
  let component: ApplicantDetailsComponent;
  let fixture: ComponentFixture<ApplicantDetailsComponent>;
  let secondFormGroup: FormGroup;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ApplicantDetailsComponent, BrowserAnimationsModule],
      providers: [
        ChangeDetectorRef,
        { provide: ElementRef, useValue: {} }, 
        CdkStepper,
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplicantDetailsComponent);
    component = fixture.componentInstance;

    // Create a FormGroup for the @Input() secondFormGroup
    const fb = new FormBuilder();
    secondFormGroup = fb.group({
      salutation: [''],
      applicantName: [''],
      phone: [''],
      email: [''],
      wardNo: [''],
      address: [''],
      houseNo: [''],
    });
    component.secondFormGroup = secondFormGroup;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

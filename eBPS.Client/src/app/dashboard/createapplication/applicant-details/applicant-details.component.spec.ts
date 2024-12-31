import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicantDetailsComponent } from './applicant-details.component';
import { ChangeDetectorRef, ElementRef } from '@angular/core';
import { CdkStepper } from '@angular/cdk/stepper';

describe('ApplicantDetailsComponent', () => {
  let component: ApplicantDetailsComponent;
  let fixture: ComponentFixture<ApplicantDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ApplicantDetailsComponent],
      providers: [
        ChangeDetectorRef,
        { provide: ElementRef, useValue: {} }, 
        CdkStepper,
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplicantDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

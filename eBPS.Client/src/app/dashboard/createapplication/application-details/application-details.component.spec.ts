import { TestBed, ComponentFixture } from '@angular/core/testing';
import { ApplicationDetailsComponent } from './application-details.component';
import { ReactiveFormsModule, FormGroup, FormControl } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatStepperModule } from '@angular/material/stepper';
import { CommonModule } from '@angular/common';
import { CdkStepper } from '@angular/cdk/stepper';
import { ChangeDetectorRef, ElementRef } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

describe('ApplicationDetailsComponent', () => {
  let component: ApplicationDetailsComponent;
  let fixture: ComponentFixture<ApplicationDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        ApplicationDetailsComponent, // Import the standalone component
        CommonModule,
        MatFormFieldModule,
        MatSelectModule,
        MatButtonModule,
        ReactiveFormsModule,
        MatStepperModule,
        BrowserAnimationsModule
      ],
      providers: [
        ChangeDetectorRef,
        { provide: ElementRef, useValue: {} }, // Mock ElementRef
        CdkStepper,
      ],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationDetailsComponent);
    component = fixture.componentInstance;

    // Initialize the FormGroup with the correct controls
    component.firstFormGroup = new FormGroup({
      transactionType: new FormControl(''),
      buildingPurpose: new FormControl(''),
      nbcClass: new FormControl(''),
      structureType: new FormControl(''),
      landUseZone: new FormControl(''),
      landUseSubZone: new FormControl(''),
    });

    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });
});

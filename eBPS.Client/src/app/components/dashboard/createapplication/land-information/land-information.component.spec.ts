import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule, FormArray, FormGroup, FormControl } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatStepperModule } from '@angular/material/stepper';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { DecimalOnlyDirective } from '../../../../directives/decimal-only.directive';
import { LandInformationComponent } from './land-information.component';
import { LandTotals } from '../../../../models/building-application/land-area-totals.model';
import { CdkStepper } from '@angular/cdk/stepper';
import { ChangeDetectorRef, ElementRef } from '@angular/core';

describe('LandInformationComponent', () => {
  let component: LandInformationComponent;
  let fixture: ComponentFixture<LandInformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        LandInformationComponent, 
        DecimalOnlyDirective,
        ReactiveFormsModule,
        MatButtonModule,
        MatCardModule,
        MatFormFieldModule,
        MatInputModule,
        MatGridListModule,
        MatIconModule,
        MatStepperModule,
        NoopAnimationsModule,
      ],
      providers: [
        CdkStepper,
        ChangeDetectorRef,
        { provide: ElementRef, useValue: jasmine.createSpyObj('ElementRef', ['nativeElement']) },
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(LandInformationComponent);
    component = fixture.componentInstance;
    component.landInformationForm = new FormArray([
      new FormGroup({
        mapSheetNumber: new FormControl(''),
        landParcelNumber: new FormControl(''),
        ropani: new FormControl(''),
        aana: new FormControl(''),
        paisa: new FormControl(''),
        daam: new FormControl(''),
        squareFeet: new FormControl(''),
        squareMeter: new FormControl(''),
        remarks: new FormControl(''),
      }),
    ]);
    component.totals = {
      totalRopani: 10,
      totalAana: 20,
      totalPaisa: 30,
      totalDaam: 40,
      totalSquareFeet: 50,
      totalSquareMeter: 60,
    };
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize the form array', () => {
    expect(component.landInformationForm).toBeInstanceOf(FormArray);
    expect(component.landInformationForm.length).toBe(1);
  });

  it('should emit addForm event when add button is clicked', () => {
    spyOn(component.addForm, 'emit');
    const addButton = fixture.nativeElement.querySelector('button[color="primary"]');
    addButton.click();
    expect(component.addForm.emit).toHaveBeenCalled();
  });

  it('should emit removeForm event when remove button is clicked', () => {
    spyOn(component.removeForm, 'emit');
    const removeButton = fixture.nativeElement.querySelector('.remove-button');
    removeButton.click();
    expect(component.removeForm.emit).toHaveBeenCalledWith(0);
  });

  it('should display the correct totals', () => {
    const totalsContainer = fixture.nativeElement.querySelector('.totals-container');
    expect(totalsContainer.textContent).toContain('Total Ropani:10');
    expect(totalsContainer.textContent).toContain('Total Aana:20');
    expect(totalsContainer.textContent).toContain('Total Paisa:30');
    expect(totalsContainer.textContent).toContain('Total Daam:40');
    expect(totalsContainer.textContent).toContain('Total Square Feet:50');
    expect(totalsContainer.textContent).toContain('Total Square Meter:60');
  });

  it('should convert control to FormGroup using asFormGroup', () => {
    const control = new FormGroup({
      mapSheetNumber: new FormControl(''),
    });
    const formGroup = component.asFormGroup(control);
    expect(formGroup).toBeInstanceOf(FormGroup);
  });
});
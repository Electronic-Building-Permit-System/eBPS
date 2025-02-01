import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule, FormArray, FormGroup, FormControl } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatStepperModule } from '@angular/material/stepper';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { DecimalOnlyDirective } from '../../../../directives/decimal-only.directive';
import { CharkillaComponent } from './charkilla.component';
import { ApplicationService } from '../../../../services/application/application.service';
import { of } from 'rxjs';
import { CdkStepper } from '@angular/cdk/stepper';
import { ChangeDetectorRef, ElementRef } from '@angular/core';

describe('CharkillaComponent', () => {
  let component: CharkillaComponent;
  let fixture: ComponentFixture<CharkillaComponent>;
  let mockApplicationService: jasmine.SpyObj<ApplicationService>;

  beforeEach(async () => {
    mockApplicationService = jasmine.createSpyObj('ApplicationService', ['getLandscapeType']);

    await TestBed.configureTestingModule({
      imports: [
        CharkillaComponent, 
        DecimalOnlyDirective,
        ReactiveFormsModule,
        MatButtonModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatOptionModule,
        MatCheckboxModule,
        MatStepperModule,
        NoopAnimationsModule,
      ],
      providers: [
        { provide: ApplicationService, useValue: mockApplicationService },
        CdkStepper,
        ChangeDetectorRef,
        { provide: ElementRef, useValue: jasmine.createSpyObj('ElementRef', ['nativeElement']) },
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(CharkillaComponent);
    component = fixture.componentInstance;

    // Initialize the form array with one form group
    component.charkillaForm = new FormArray([
      new FormGroup({
        direction: new FormControl(''),
        side: new FormControl(''),
        charkillaName: new FormControl(''),
        landscapeType: new FormControl(''),
        roadId: new FormControl(''),
        roadLength: new FormControl(''),
        proposedRow: new FormControl(''),
        existingRow: new FormControl(''),
        actualSetback: new FormControl(''),
        standardSetback: new FormControl(''),
        kitta: new FormControl(''),
      }),
    ]);

    // Mock the landscape type data
    mockApplicationService.getLandscapeType.and.returnValue(
      of([
        { id: 1, description: 'Type 1' },
        { id: 2, description: 'Type 2' },
      ])
    );

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize the form array', () => {
    expect(component.charkillaForm).toBeInstanceOf(FormArray);
    expect(component.charkillaForm.length).toBe(1);
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

  it('should fetch landscape type data on initialization', () => {
    expect(mockApplicationService.getLandscapeType).toHaveBeenCalled();
    expect(component.landscapeType.length).toBe(2);
    expect(component.landscapeType[0].description).toBe('Type 1');
    expect(component.landscapeType[1].description).toBe('Type 2');
  });

  it('should display the correct form controls', () => {
    const formControls = fixture.nativeElement.querySelectorAll('mat-form-field');
    expect(formControls.length).toBe(11); // 10 form fields in the template
  });

  it('should convert control to FormGroup using asFormGroup', () => {
    const control = new FormGroup({
      direction: new FormControl(''),
    });
    const formGroup = component.asFormGroup(control);
    expect(formGroup).toBeInstanceOf(FormGroup);
  });
});
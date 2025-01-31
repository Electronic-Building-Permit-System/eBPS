import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HouseOwnerComponent } from './house-owner.component';
import { ReactiveFormsModule, FormArray, FormGroup } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { By } from '@angular/platform-browser';
import { ApplicationService } from '../../../../services/application/application.service';
import { of } from 'rxjs';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatStepperModule } from '@angular/material/stepper';
import { CdkStepper } from '@angular/cdk/stepper';
import { ChangeDetectorRef, ElementRef } from '@angular/core';
class MockElementRef {}
describe('HouseOwnerComponent', () => {
  let component: HouseOwnerComponent;
  let fixture: ComponentFixture<HouseOwnerComponent>;
  let addFormSpy: jasmine.Spy;
  let removeFormSpy: jasmine.Spy;
  let applicationServiceSpy: jasmine.SpyObj<ApplicationService>;

  beforeEach(() => {
    applicationServiceSpy = jasmine.createSpyObj('ApplicationService', ['getWard', 'getIssueDistrict']);

    TestBed.configureTestingModule({
      imports: [
        HouseOwnerComponent,
        ReactiveFormsModule,
        MatButtonModule,
        MatOptionModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatDatepickerModule,
        MatStepperModule,
      ],
      providers: [
        { provide: ApplicationService, useValue: applicationServiceSpy },
        { provide: CdkStepper, useClass: CdkStepper },
        { provide: ElementRef, useClass: MockElementRef },
        ChangeDetectorRef
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(HouseOwnerComponent);
    component = fixture.componentInstance;

    // Mock the EventEmitter methods
    addFormSpy = spyOn(component.addForm, 'emit');
    removeFormSpy = spyOn(component.removeForm, 'emit');

    // Mock the application service's return values for the fetch methods
    applicationServiceSpy.getWard.and.returnValue(of([{ id: 1, wardNumber: '1' }]));
    applicationServiceSpy.getIssueDistrict.and.returnValue(of([{ id: 1, description: 'District 1' }]));

    // Initialize houseOwnerForm with a FormArray
    component.houseOwnerForm = new FormArray([new FormGroup({})]);

    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should emit addForm event when onAddForm is called', () => {
    component.onAddForm();
    expect(addFormSpy).toHaveBeenCalled();
  });

  it('should emit removeForm event when onRemoveForm is called', () => {
    const index = 0;
    component.houseOwnerForm = new FormArray([new FormGroup({})]);

    fixture.detectChanges();

    component.onRemoveForm(index);
    expect(removeFormSpy).toHaveBeenCalledWith(index);
  });

  it('should not emit removeForm event if no forms exist', () => {
    component.houseOwnerForm = new FormArray<FormGroup>([]);

    fixture.detectChanges();

    const index = 0;
    component.onRemoveForm(index);
    expect(removeFormSpy).not.toHaveBeenCalled();
  });

  it('should convert control to FormGroup in asFormGroup', () => {
    const mockControl = new FormGroup({});
    const result = component.asFormGroup(mockControl);
    expect(result).toBe(mockControl);
  });

  it('should trigger onAddForm when add button is clicked', () => {
    const button = fixture.debugElement.query(By.css('.add-button'));
    button.triggerEventHandler('click', null);
    expect(addFormSpy).toHaveBeenCalled();
  });

  it('should trigger onRemoveForm when remove button is clicked', () => {
    const index = 0;
    component.houseOwnerForm = new FormArray([new FormGroup({})]);

    fixture.detectChanges();

    const button = fixture.debugElement.query(By.css('.remove-button'));
    button.triggerEventHandler('click', index);

    expect(removeFormSpy).toHaveBeenCalledWith(index);
  });
});

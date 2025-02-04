import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule, FormArray, FormGroup, FormControl } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatStepperModule } from '@angular/material/stepper';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { HouseOwnerComponent } from './house-owner.component';
import { ApplicationService } from '../../../../services/application/application.service';
import { of } from 'rxjs';

describe('HouseOwnerComponent', () => {
  let component: HouseOwnerComponent;
  let fixture: ComponentFixture<HouseOwnerComponent>;
  let mockApplicationService: jasmine.SpyObj<ApplicationService>;

  beforeEach(async () => {
    // Create a spy object for ApplicationService with the required methods
    mockApplicationService = jasmine.createSpyObj('ApplicationService', ['getWard', 'getIssueDistrict']);

    await TestBed.configureTestingModule({
      imports: [
        HouseOwnerComponent,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatSelectModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatStepperModule,
        NoopAnimationsModule
      ],
      providers: [
        { provide: ApplicationService, useValue: mockApplicationService } // Provide the mock service
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(HouseOwnerComponent);
    component = fixture.componentInstance;

    // Mock the return values for the service methods
    mockApplicationService.getWard.and.returnValue(of([{ id: 1, wardNumber: '1' }]));
    mockApplicationService.getIssueDistrict.and.returnValue(of([{ id: 1, description: 'District 1' }]));

    // Initialize the component
    component.houseOwnerForm = new FormArray<FormGroup<any>>([]);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize with empty form array', () => {
    expect(component.houseOwnerForm.length).toBe(0);
  });

  it('should call fetchWard and fetchIssueDistrict on ngOnInit', () => {
    // Ensure the service methods were called
    expect(mockApplicationService.getWard).toHaveBeenCalled();
    expect(mockApplicationService.getIssueDistrict).toHaveBeenCalled();

    // Check if the data was assigned correctly
    expect(component.ward).toEqual([{ id: 1, wardNumber: '1' }]);
    expect(component.issueDistrict).toEqual([{ id: 1, description: 'District 1' }]);
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

  it('should return FormGroup when asFormGroup is called', () => {
    const formGroup = new FormGroup({
      salutation: new FormControl('1'),
      houseOwnerType: new FormControl('1'),
      houseOwnerName: new FormControl('John Doe'),
      fatherName: new FormControl('Father Name'),
      grandFatherName: new FormControl('Grand Father Name'),
      address: new FormControl('123 Main St'),
      citizenshipNumber: new FormControl('123456'),
      citizenshipIssueDistrict: new FormControl('1'),
      citizenshipIssueDate: new FormControl(new Date()),
      tole: new FormControl('Tole 1'),
      wardNumber: new FormControl('1'),
      phoneNumber: new FormControl('1234567890'),
      email: new FormControl('john.doe@example.com')
    });

    const result = component.asFormGroup(formGroup);
    expect(result).toBeInstanceOf(FormGroup);
  });
});
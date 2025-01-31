import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ApplicantDetailsComponent } from './applicant-details.component';
import { of } from 'rxjs';
import { ReactiveFormsModule, FormGroup } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatStepperModule } from '@angular/material/stepper';
import { CommonModule } from '@angular/common';
import { ApplicationService } from '../../../../services/application/application.service';

describe('ApplicantDetailsComponent', () => {
  let component: ApplicantDetailsComponent;
  let fixture: ComponentFixture<ApplicantDetailsComponent>;
  let applicationService: jasmine.SpyObj<ApplicationService>;

  beforeEach(() => {
    // Create a spy for the ApplicationService
    const spy = jasmine.createSpyObj('ApplicationService', ['getWard']);

    TestBed.configureTestingModule({
      imports: [
        CommonModule,
        MatIconModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatButtonModule,
        ReactiveFormsModule,
        MatStepperModule
      ],
      declarations: [ApplicantDetailsComponent],
      providers: [{ provide: ApplicationService, useValue: spy }]
    }).compileComponents();

    // Inject the spy service
    fixture = TestBed.createComponent(ApplicantDetailsComponent);
    component = fixture.componentInstance;
    applicationService = TestBed.inject(ApplicationService) as jasmine.SpyObj<ApplicationService>;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should fetch ward data on init', () => {
    const mockWardData = [{ id: 1, wardNumber: 'Ward 1' }, { id: 2, wardNumber: 'Ward 2' }];
    applicationService.getWard.and.returnValue(of(mockWardData));

    component.ngOnInit();

    expect(applicationService.getWard).toHaveBeenCalled();
    expect(component.ward).toEqual(mockWardData);
  });

  it('should handle file selection and generate a preview', () => {
    const mockFile = new File([''], 'test.txt');
    const event = { target: { files: [mockFile] } } as unknown as Event;

    component.onFileSelected(event);

    expect(component.selectedFile).toBe(mockFile);
    expect(component.preview).toBeTruthy(); // Ensure a preview URL is set
  });

  it('should not update file if no file is selected', () => {
    const event = { target: { files: [] } } as unknown as Event;

    component.onFileSelected(event);

    expect(component.selectedFile).toBeNull();
    expect(component.preview).toBeNull();
  });
});

import { ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';
import { ApplicantDetailsComponent } from './applicant-details.component';
import { ApplicationService } from '../../../../services/application/application.service';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';
import { NepaliDateAdapter } from '../../../../services/nepali-date/nepali-date-adapter';
import { of } from 'rxjs';
import { By } from '@angular/platform-browser';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatStepperModule } from '@angular/material/stepper';

describe('ApplicantDetailsComponent', () => {
  let component: ApplicantDetailsComponent;
  let fixture: ComponentFixture<ApplicantDetailsComponent>;
  let applicationService: jasmine.SpyObj<ApplicationService>;
  let testFormGroup: FormGroup;

  const mockWards = [{ id: 1, wardNumber: 'Ward 1' }, { id: 2, wardNumber: 'Ward 2' }];
  const mockDistricts = [{ id: 1, description: 'District 1' }, { id: 2, description: 'District 2' }];

  beforeEach(async () => {
    const applicationServiceSpy = jasmine.createSpyObj('ApplicationService', ['getWard', 'getIssueDistrict']);

    await TestBed.configureTestingModule({
      // Import standalone component directly
      imports: [
        ApplicantDetailsComponent, // Standalone component
        ReactiveFormsModule,
        MatStepperModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatSelectModule,
        MatInputModule,
        NoopAnimationsModule,
      ],
      providers: [
        { provide: ApplicationService, useValue: applicationServiceSpy },
        { provide: NepaliDateAdapter, useClass: NepaliDateAdapter },
        // Include component's providers if needed
        { provide: MAT_DATE_LOCALE, useValue: 'ne-NP' }
      ]
    }).compileComponents();

    applicationService = TestBed.inject(ApplicationService) as jasmine.SpyObj<ApplicationService>;
    applicationService.getWard.and.returnValue(of(mockWards));
    applicationService.getIssueDistrict.and.returnValue(of(mockDistricts));

    testFormGroup = new FormGroup({});
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicantDetailsComponent);
    component = fixture.componentInstance;
    // Set input property for standalone component
    component.secondFormGroup = testFormGroup;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize with input form group', () => {
    expect(component.secondFormGroup).toBe(testFormGroup);
  });

  it('should fetch wards and districts on init', () => {
    expect(applicationService.getWard).toHaveBeenCalled();
    expect(applicationService.getIssueDistrict).toHaveBeenCalled();
    expect(component.ward).toEqual(mockWards);
    expect(component.issueDistrict).toEqual(mockDistricts);
  });

  it('should render ward options', () => {
    fixture.detectChanges();
    const select = fixture.debugElement.query(By.css('#wardNumber')).nativeElement;
    expect(select.options.length).toBe(2);
    expect(select.options[0].textContent).toContain('Ward 1');
  });

  it('should handle file selection and preview', fakeAsync(() => {
    const mockFile = new File(['test'], 'test.png', { type: 'image/png' });
    const input = fixture.debugElement.query(By.css('input[type="file"]')).nativeElement;
    
    const event = new Event('change');
    Object.defineProperty(event, 'target', {
      writable: false,
      value: { files: [mockFile] }
    });

    input.dispatchEvent(event);
    fixture.detectChanges();

    tick(); // Wait for FileReader
    fixture.detectChanges();
    
    expect(component.selectedFile).toBe(mockFile);
    expect(component.preview).toContain('data:image/png;base64');
  }));

  it('should display preview when file is selected', fakeAsync(() => {
    component.preview = 'mock-url';
    fixture.detectChanges();
    const img = fixture.debugElement.query(By.css('img'));
    expect(img).toBeTruthy();
    expect(img.nativeElement.src).toContain('mock-url');
  }));

  it('should show error when invalid file type is selected', () => {
    const input = fixture.debugElement.query(By.css('input[type="file"]')).nativeElement;
    const invalidFile = new File(['test'], 'test.txt', { type: 'text/plain' });
    
    const event = new Event('change');
    Object.defineProperty(event, 'target', {
      value: { files: [invalidFile] }
    });

    input.dispatchEvent(event);
    fixture.detectChanges();

    const error = fixture.debugElement.query(By.css('.file-error'));
    expect(error.nativeElement.textContent).toContain('Invalid file type');
  });
});
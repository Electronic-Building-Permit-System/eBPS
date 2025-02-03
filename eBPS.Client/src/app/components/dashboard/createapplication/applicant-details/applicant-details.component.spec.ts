import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatStepperModule } from '@angular/material/stepper';
import { of } from 'rxjs';
import { ApplicantDetailsComponent } from './applicant-details.component';
import { ApplicationService } from '../../../../services/application/application.service';
import { CdkStepper } from '@angular/cdk/stepper';
import { ChangeDetectorRef, ElementRef } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

describe('ApplicantDetailsComponent', () => {
    let component: ApplicantDetailsComponent;
    let fixture: ComponentFixture<ApplicantDetailsComponent>;
    let applicationServiceMock: any;

    beforeEach(async () => {
        applicationServiceMock = {
            getWard: jasmine.createSpy('getWard').and.returnValue(of([{ id: 1, wardNumber: '1' }])),
            getIssueDistrict: jasmine.createSpy('getIssueDistrict').and.returnValue(of([{ id: 1, description: 'District 1' }]))
        };

        await TestBed.configureTestingModule({
            imports: [
                ApplicantDetailsComponent,
                ReactiveFormsModule,
                MatIconModule,
                MatFormFieldModule,
                MatInputModule,
                MatSelectModule,
                MatButtonModule,
                MatStepperModule,
                BrowserAnimationsModule
            ],
            providers: [
                FormBuilder,
                { provide: ApplicationService, useValue: applicationServiceMock },
                CdkStepper,
                ChangeDetectorRef,
                { provide: ElementRef, useValue: jasmine.createSpyObj('ElementRef', ['nativeElement']) },
            ]
        }).compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(ApplicantDetailsComponent);
        component = fixture.componentInstance;
        component.secondFormGroup = new FormBuilder().group({
            salutation: [''],
            applicantName: [''],
            applicationNumber: [''],
            fatherName: [''],
            grandFatherName: [''],
            tole: [''],
            phoneNumber: [''],
            email: [''],
            citizenshipNumber: [''],
            citizenshipIssueDate: [''],
            citizenshipIssueDistrict: [''],
            wardNumber: [''],
            address: [''],
            houseNumber: ['']
        });
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    it('should fetch wards on init', () => {
        component.ngOnInit();
        expect(applicationServiceMock.getWard).toHaveBeenCalled();
        expect(component.ward.length).toBeGreaterThan(0);
    });

    it('should fetch issue districts on init', () => {
        component.ngOnInit();
        expect(applicationServiceMock.getIssueDistrict).toHaveBeenCalled();
        expect(component.issueDistrict.length).toBeGreaterThan(0);
    });

    it('should select a file and generate a preview', () => {
        const file = new File([''], 'test-image.png', { type: 'image/png' });
        const event = { target: { files: [file] } } as unknown as Event;

        component.onFileSelected(event);

        expect(component.selectedFile).toBe(file);
        const reader = new FileReader();
        reader.onload = () => {
            expect(component.preview).toBe(reader.result as string);
        };
        reader.readAsDataURL(file);
    });
});
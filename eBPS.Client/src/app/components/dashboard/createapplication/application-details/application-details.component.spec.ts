import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatStepperModule } from '@angular/material/stepper';
import { of } from 'rxjs';
import { ApplicationDetailsComponent } from './application-details.component';
import { ApplicationService } from '../../../../services/application/application.service';
import { DecimalOnlyDirective } from '../../../../directives/decimal-only.directive';
import { CdkStepper } from '@angular/cdk/stepper';
import { ChangeDetectorRef, ElementRef } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

describe('ApplicationDetailsComponent', () => {
    let component: ApplicationDetailsComponent;
    let fixture: ComponentFixture<ApplicationDetailsComponent>;
    let applicationService: jasmine.SpyObj<ApplicationService>;
    let formBuilder: FormBuilder = new FormBuilder();

    beforeEach(async () => {
        const applicationServiceSpy = jasmine.createSpyObj('ApplicationService', [
            'getBuildingPurpose',
            'getTransactionType',
            'getStructureType',
            'getLandUseZone',
            'getNBCClass',
            'getLandUseSubZone',
            'getWard',
        ]);

        await TestBed.configureTestingModule({
            imports: [
                ApplicationDetailsComponent, 
                DecimalOnlyDirective,
                ReactiveFormsModule,
                MatFormFieldModule,
                MatInputModule,
                MatSelectModule,
                MatButtonModule,
                MatStepperModule,
                BrowserAnimationsModule
            ],
            providers: [
                { provide: ApplicationService, useValue: applicationServiceSpy },
                CdkStepper,
                ChangeDetectorRef,
                { provide: ElementRef, useValue: jasmine.createSpyObj('ElementRef', ['nativeElement']) },
            ],
        }).compileComponents();

        applicationService = TestBed.inject(ApplicationService) as jasmine.SpyObj<ApplicationService>;
        fixture = TestBed.createComponent(ApplicationDetailsComponent);
        component = fixture.componentInstance;
        component.firstFormGroup = formBuilder.group({
            transactionType: [''],
            buildingPurpose: [''],
            nbcClass: [''],
            structureType: [''],
            landUseZone: [''],
            landUseSubZone: [''],
            landLongitude: [''],
            landLatitude: [''],
            landSawikWard: [''],
            landSawikGabisa: [''],
            landToleName: [''],
            wardNumber: [''],
        });
        applicationService.getWard.and.returnValue(of([]));
        applicationService.getBuildingPurpose.and.returnValue(of([]));
        applicationService.getNBCClass.and.returnValue(of([]));
        applicationService.getStructureType.and.returnValue(of([]));
        applicationService.getLandUseSubZone.and.returnValue(of([]));
        applicationService.getLandUseZone.and.returnValue(of([]));
        applicationService.getTransactionType.and.returnValue(of([]));
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    it('should fetch building purposes on init', () => {
        const mockData = [{ id: 1, description: 'Residential' }];
        applicationService.getBuildingPurpose.and.returnValue(of(mockData));
        component.ngOnInit();
        expect(component.buildingPurpose).toEqual(mockData);
    });

    it('should fetch transaction types on init', () => {
        const mockData = [{ id: 1, description: 'Sale' }];
        applicationService.getTransactionType.and.returnValue(of(mockData));
        component.ngOnInit();
        expect(component.transactionType).toEqual(mockData);
    });

    it('should fetch structure types on init', () => {
        const mockData = [{ id: 1, description: 'Concrete' }];
        applicationService.getStructureType.and.returnValue(of(mockData));
        component.ngOnInit();
        expect(component.structureType).toEqual(mockData);
    });

    it('should fetch land use zones on init', () => {
        const mockData = [{ id: 1, description: 'Commercial' }];
        applicationService.getLandUseZone.and.returnValue(of(mockData));
        component.ngOnInit();
        expect(component.landUseZone).toEqual(mockData);
    });

    it('should fetch NBC classes on init', () => {
        const mockData = [{ id: 1, description: 'Class A' }];
        applicationService.getNBCClass.and.returnValue(of(mockData));
        component.ngOnInit();
        expect(component.nbcClass).toEqual(mockData);
    });

    it('should fetch land use sub zones on init', () => {
        const mockData = [{ id: 1, description: 'Sub Zone 1' }];
        applicationService.getLandUseSubZone.and.returnValue(of(mockData));
        component.ngOnInit();
        expect(component.landUseSubZone).toEqual(mockData);
    });

    it('should fetch wards on init', () => {
        const mockData = [{ id: 1, wardNumber: 'Ward 1' }];
        applicationService.getWard.and.returnValue(of(mockData));
        component.ngOnInit();
        expect(component.ward).toEqual(mockData);
    });
});
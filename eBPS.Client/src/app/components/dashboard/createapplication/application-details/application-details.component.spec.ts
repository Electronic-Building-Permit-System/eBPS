import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ApplicationDetailsComponent } from './application-details.component';
import { ApplicationService } from '../../../../services/application/application.service';
import { of } from 'rxjs';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatStepperModule } from '@angular/material/stepper';
import { DecimalOnlyDirective } from '../../../../directives/decimal-only.directive';
import { CommonModule } from '@angular/common';

describe('ApplicationDetailsComponent', () => {
  let component: ApplicationDetailsComponent;
  let fixture: ComponentFixture<ApplicationDetailsComponent>;
  let applicationServiceSpy: jasmine.SpyObj<ApplicationService>;

  beforeEach(async () => {
    const serviceSpy = jasmine.createSpyObj('ApplicationService', [
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
        CommonModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatButtonModule,
        ReactiveFormsModule,
        MatStepperModule,
      ],
      providers: [{ provide: ApplicationService, useValue: serviceSpy }],
    }).compileComponents();

    applicationServiceSpy = TestBed.inject(ApplicationService) as jasmine.SpyObj<ApplicationService>;
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationDetailsComponent);
    component = fixture.componentInstance;
    component.firstFormGroup = new FormGroup({});

    applicationServiceSpy.getBuildingPurpose.and.returnValue(of([]));
    applicationServiceSpy.getTransactionType.and.returnValue(of([]));
    applicationServiceSpy.getStructureType.and.returnValue(of([]));
    applicationServiceSpy.getLandUseZone.and.returnValue(of([]));
    applicationServiceSpy.getNBCClass.and.returnValue(of([]));
    applicationServiceSpy.getLandUseSubZone.and.returnValue(of([]));
    applicationServiceSpy.getWard.and.returnValue(of([]));
  });

  it('should create', () => {
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should fetch building purposes on init', () => {
    fixture.detectChanges();
    expect(applicationServiceSpy.getBuildingPurpose).toHaveBeenCalled();
  });

  it('should fetch transaction types on init', () => {
    fixture.detectChanges();
    expect(applicationServiceSpy.getTransactionType).toHaveBeenCalled();
  });

  it('should fetch structure types on init', () => {
    fixture.detectChanges();
    expect(applicationServiceSpy.getStructureType).toHaveBeenCalled();
  });

  it('should fetch land use zones on init', () => {
    fixture.detectChanges();
    expect(applicationServiceSpy.getLandUseZone).toHaveBeenCalled();
  });

  it('should fetch NBC classes on init', () => {
    fixture.detectChanges();
    expect(applicationServiceSpy.getNBCClass).toHaveBeenCalled();
  });

  it('should fetch land use sub-zones on init', () => {
    fixture.detectChanges();
    expect(applicationServiceSpy.getLandUseSubZone).toHaveBeenCalled();
  });

  it('should fetch wards on init', () => {
    fixture.detectChanges();
    expect(applicationServiceSpy.getWard).toHaveBeenCalled();
  });
});
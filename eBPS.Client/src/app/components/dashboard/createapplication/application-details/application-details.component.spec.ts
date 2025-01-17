import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ApplicationDetailsComponent } from './application-details.component';
import { of } from 'rxjs';
import { ReactiveFormsModule, FormGroup } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatStepperModule } from '@angular/material/stepper';
import { CommonModule } from '@angular/common';
import { ApplicationService } from '../../../../services/shared/application/application.service';

describe('ApplicationDetailsComponent', () => {
  let component: ApplicationDetailsComponent;
  let fixture: ComponentFixture<ApplicationDetailsComponent>;
  let applicationService: jasmine.SpyObj<ApplicationService>;

  beforeEach(() => {
    // Create a spy for the ApplicationService
    const spy = jasmine.createSpyObj('ApplicationService', [
      'getBuildingPurpose',
      'getStructureType',
      'getNBCClass'
    ]);

    TestBed.configureTestingModule({
      imports: [
        CommonModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatButtonModule,
        ReactiveFormsModule,
        MatStepperModule
      ],
      declarations: [ApplicationDetailsComponent],
      providers: [{ provide: ApplicationService, useValue: spy }]
    }).compileComponents();

    // Inject the spy service
    fixture = TestBed.createComponent(ApplicationDetailsComponent);
    component = fixture.componentInstance;
    applicationService = TestBed.inject(ApplicationService) as jasmine.SpyObj<ApplicationService>;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should fetch building purpose data on init', () => {
    const mockBuildingPurpose = [
      { id: 1, description: 'Residential' },
      { id: 2, description: 'Commercial' }
    ];
    applicationService.getBuildingPurpose.and.returnValue(of(mockBuildingPurpose));

    component.ngOnInit();

    expect(applicationService.getBuildingPurpose).toHaveBeenCalled();
    expect(component.buildingPurpose).toEqual(mockBuildingPurpose);
  });

  it('should fetch structure type data on init', () => {
    const mockStructureType = [
      { id: 1, description: 'Concrete' },
      { id: 2, description: 'Wood' }
    ];
    applicationService.getStructureType.and.returnValue(of(mockStructureType));

    component.ngOnInit();

    expect(applicationService.getStructureType).toHaveBeenCalled();
    expect(component.structureType).toEqual(mockStructureType);
  });

  it('should fetch NBC class data on init', () => {
    const mockNBCClass = [
      { id: 1, description: 'Class I' },
      { id: 2, description: 'Class II' }
    ];
    applicationService.getNBCClass.and.returnValue(of(mockNBCClass));

    component.ngOnInit();

    expect(applicationService.getNBCClass).toHaveBeenCalled();
    expect(component.nbcClass).toEqual(mockNBCClass);
  });
});

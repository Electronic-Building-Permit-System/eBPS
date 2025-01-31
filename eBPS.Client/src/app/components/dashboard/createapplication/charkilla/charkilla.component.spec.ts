import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CharkillaComponent } from './charkilla.component';
import { ReactiveFormsModule, FormArray, FormGroup, FormControl } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { ApplicationService } from '../../../../services/application/application.service';
import { of } from 'rxjs';
import { DecimalOnlyDirective } from '../../../../directives/decimal-only.directive';

describe('CharkillaComponent', () => {
  let component: CharkillaComponent;
  let fixture: ComponentFixture<CharkillaComponent>;
  let applicationService: jasmine.SpyObj<ApplicationService>;

  beforeEach(async () => {
    const applicationServiceSpy = jasmine.createSpyObj('ApplicationService', ['getLandscapeType']);

    await TestBed.configureTestingModule({
      imports: [
        ReactiveFormsModule,
        MatButtonModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatCheckboxModule,
        DecimalOnlyDirective
      ],
      providers: [
        { provide: ApplicationService, useValue: applicationServiceSpy }
      ]
    }).compileComponents();

    applicationService = TestBed.inject(ApplicationService) as jasmine.SpyObj<ApplicationService>;
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CharkillaComponent);
    component = fixture.componentInstance;

    // ✅ Initialize `charkillaForm` before calling detectChanges
    component.charkillaForm = new FormArray<FormGroup>([]);

    // Set up spy for landscape types
    applicationService.getLandscapeType.and.returnValue(of([
      { id: 1, description: 'Residential' },
      { id: 2, description: 'Commercial' }
    ]));

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should fetch landscape types on init', () => {
    const mockLandscapeTypes = [
      { id: 1, description: 'Residential' },
      { id: 2, description: 'Commercial' }
    ];
    
    applicationService.getLandscapeType.and.returnValue(of(mockLandscapeTypes));

    component.ngOnInit();

    expect(applicationService.getLandscapeType).toHaveBeenCalled();
    expect(component.landscapeType).toEqual(mockLandscapeTypes);
  });

  it('should emit addForm event when adding a new form', () => {
    spyOn(component.addForm, 'emit');

    component.onAddForm();

    expect(component.addForm.emit).toHaveBeenCalled();
  });

  it('should emit removeForm event when removing a form', () => {
    // Arrange: Ensure the FormArray has one form.
    component.charkillaForm = new FormArray<FormGroup>([
      new FormGroup({}) // Add a dummy FormGroup
    ]);
  
    // Spy on the removeForm emitter
    spyOn(component.removeForm, 'emit');
  
    // Act: Call onRemoveForm to remove the form at index 0
    component.onRemoveForm(0);
  
    // Assert: The removeForm event should have been emitted with index 0
    expect(component.removeForm.emit).toHaveBeenCalledWith(0);
  });

  it('should not emit removeForm event if no forms exist', () => {
    spyOn(component.removeForm, 'emit');

    expect(component.charkillaForm.length).toBe(0); // Ensure it's empty

    component.onRemoveForm(0); // Try removing

    expect(component.removeForm.emit).not.toHaveBeenCalled(); // Should NOT emit
  });
});

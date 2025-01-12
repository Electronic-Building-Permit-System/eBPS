import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CharkillaComponent } from '../../../../../../charkilla.component';
import { ReactiveFormsModule, FormArray, FormGroup } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { EventEmitter } from '@angular/core';
import { By } from '@angular/platform-browser';

describe('CharkillaComponent', () => {
  let component: CharkillaComponent;
  let fixture: ComponentFixture<CharkillaComponent>;
  let addFormSpy: jasmine.Spy;
  let removeFormSpy: jasmine.Spy;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        ReactiveFormsModule,
        MatButtonModule,
        MatOptionModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatCheckboxModule
      ],
      declarations: [CharkillaComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(CharkillaComponent);
    component = fixture.componentInstance;

    // Mock the EventEmitter methods
    addFormSpy = spyOn(component.addForm, 'emit');
    removeFormSpy = spyOn(component.removeForm, 'emit');

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
    const index = 1; // Example index
    component.onRemoveForm(index);

    expect(removeFormSpy).toHaveBeenCalledWith(index);
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
    component.charkillaForm = new FormArray([new FormGroup({})]);

    fixture.detectChanges();

    const button = fixture.debugElement.query(By.css('.remove-button'));
    button.triggerEventHandler('click', index);

    expect(removeFormSpy).toHaveBeenCalledWith(index);
  });
});

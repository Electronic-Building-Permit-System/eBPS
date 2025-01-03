import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormArray, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-land-information',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  templateUrl: './land-information.component.html',
  styleUrl: './land-information.component.css'
})
export class LandInformationComponent {
  @Input() dynamicForms!: FormArray;
  @Output() addForm = new EventEmitter<void>();
  @Output() removeForm = new EventEmitter<number>();

  asFormGroup(control: any): FormGroup {
    return control as FormGroup;
  }

  onAddForm() {
    this.addForm.emit(); // Notify parent to add a new form
  }

  onRemoveForm(index: number) {
    this.removeForm.emit(index); // Notify parent to remove a form
  }
}
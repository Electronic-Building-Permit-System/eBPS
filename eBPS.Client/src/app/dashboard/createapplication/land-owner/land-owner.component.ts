import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormArray, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatOption, MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-land-owner',
  imports: [CommonModule,
      ReactiveFormsModule,
      MatFormFieldModule,
      MatInputModule,
      MatButtonModule,
    MatButtonModule,MatOptionModule,MatSelectModule],
  templateUrl: './land-owner.component.html',
  styleUrl: './land-owner.component.css'
})
export class LandOwnerComponent {
 @Input() landOwnerForm!: FormArray;
  @Output() addForm = new EventEmitter<void>();
  @Output() removeForm = new EventEmitter<number>();
 
  wards: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]; 
  

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

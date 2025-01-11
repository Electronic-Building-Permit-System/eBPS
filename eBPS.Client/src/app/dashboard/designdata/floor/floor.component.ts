import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormArray, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatStepperModule } from '@angular/material/stepper';

@Component({
  selector: 'app-floor',
  imports: [CommonModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
      MatButtonModule,MatOptionModule,MatSelectModule,MatStepperModule],
  templateUrl: './floor.component.html',
  styleUrl: './floor.component.css'
})
export class FloorComponent {
 
  @Input() floorForm!: FormArray;

  getFormGroup(control: any): FormGroup {
    return control as FormGroup;
  }
}

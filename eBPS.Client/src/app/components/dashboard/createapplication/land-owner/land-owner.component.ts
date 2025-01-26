import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormArray, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import {
  MatNativeDateModule,
  MatOption,
  MatOptionModule,
} from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ApplicationService } from '../../../../services/application/application.service';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatStepperModule } from '@angular/material/stepper';

@Component({
  selector: 'app-land-owner',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatButtonModule,
    MatOptionModule,
    MatSelectModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatStepperModule
  ],
  templateUrl: './land-owner.component.html',
  styleUrl: './land-owner.component.css',
})
export class LandOwnerComponent {
  @Input() landOwnerForm!: FormArray;
  @Output() addForm = new EventEmitter<void>();
  @Output() removeForm = new EventEmitter<number>();

  ward: { id: number; wardNumber: string }[] = [];
  issueDistrict: { id: number; description: string }[] = [];

  asFormGroup(control: any): FormGroup {
    return control as FormGroup;
  }

  onAddForm() {
    this.addForm.emit(); // Notify parent to add a new form
  }

  onRemoveForm(index: number) {
    this.removeForm.emit(index); // Notify parent to remove a form
  }

  constructor(private applicationService: ApplicationService) {}
  ngOnInit(): void {
    this.fetchIssueDistrict();
    this.fetchWard();
  }
  fetchIssueDistrict() {
    this.applicationService
      .getIssueDistrict()
      .subscribe((data: { id: number; description: string }[]) => {
        this.issueDistrict = data;
      });
  }
  fetchWard() {
    this.applicationService
      .getWard()
      .subscribe((data: { id: number; wardNumber: string }[]) => {
        this.ward = data;
      });
  }
}

import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormArray, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ApplicationService } from '../../../../services/application/application.service';

@Component({
  selector: 'app-house-owner',
  imports: [  CommonModule,
      ReactiveFormsModule,
      MatFormFieldModule,
      MatInputModule,
      MatButtonModule, MatOptionModule, MatSelectModule],
  templateUrl: './house-owner.component.html',
  styleUrl: './house-owner.component.css'
})
export class HouseOwnerComponent {
  issueDistrict: { id: number; description: string }[] = [];
  ward: { id: number; wardNumber: string }[] = [];
 @Input() houseOwnerForm!: FormArray;
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
   constructor(private applicationService: ApplicationService){}
    ngOnInit(): void {
      this.fetchIssueDistrict();
      this.fetchWard();
      
    } 
  fetchWard() {
    this.applicationService.getWard().subscribe((data: { id: number; wardNumber: string }[]) => {
      this.ward = data;
    });
  }
    fetchIssueDistrict() {
      this.applicationService.getIssueDistrict().subscribe((data: { id: number; description: string }[]) => {
        this.issueDistrict = data;
      });
      
    }
}

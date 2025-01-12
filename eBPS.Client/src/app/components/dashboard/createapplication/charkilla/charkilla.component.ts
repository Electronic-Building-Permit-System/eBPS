import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormArray, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { ApplicationService } from '../../../../services/shared/application/application.service';


@Component({
  selector: 'app-charkilla',
  imports: [CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule, MatOptionModule, MatCheckboxModule, MatSelectModule],
  templateUrl: './charkilla.component.html',
  styleUrl: './charkilla.component.css'
})
export class CharkillaComponent {
  landscapeType: { id: number; description: string }[] = [];
 @Input() charkillaForm!: FormArray;
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
          this.fetchLandscapeType();
      
        } 
        fetchLandscapeType() {
          this.applicationService.getLandscapeType().subscribe((data: { id: number; description: string }[]) => {
            this.landscapeType = data;
          });
        }
        
}

import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatStepperModule } from '@angular/material/stepper';
import { ApplicationService } from '../../../../services/shared/application/application.service';

@Component({
  selector: 'app-applicant-details',
  imports: [CommonModule,MatIconModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule, ReactiveFormsModule, MatStepperModule],
  templateUrl: './applicant-details.component.html',
  styleUrl: './applicant-details.component.css'
})
export class ApplicantDetailsComponent {
  ward: { id: number; wardNumber: string }[] = [];
  @Input() secondFormGroup!: FormGroup;
  selectedFile: File | null = null;
  preview: string | null = null;
  constructor(private applicationService: ApplicationService){}
  ngOnInit(): void {
    this.fetchWard();
    
  } 
  fetchWard() {
    this.applicationService.getWard().subscribe((data: { id: number; wardNumber: string }[]) => {
      this.ward = data;
    });
    
  }

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      this.selectedFile = input.files[0];

      // Generate preview URL
      const reader = new FileReader();
      reader.onload = () => {
        this.preview = reader.result as string;
      };
      reader.readAsDataURL(this.selectedFile);
    }
  }
}

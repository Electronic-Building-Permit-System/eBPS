import { Component } from '@angular/core';
import { NavbarComponent } from "../navbar/navbar.component";
import { CommonModule } from '@angular/common';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatStepperModule } from '@angular/material/stepper';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { Router } from '@angular/router';
import { FloorComponent } from './floor/floor.component';

@Component({
  selector: 'app-designdata',
  imports: [NavbarComponent, CommonModule,
    ReactiveFormsModule,
    MatStepperModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatIconModule, FloorComponent],
  templateUrl: './designdata.component.html',
  styleUrl: './designdata.component.css'
})
export class DesigndataComponent {
  floorForm!: FormArray;


   constructor(private _formBuilder: FormBuilder, private router: Router) { }

  navigateToDashboard() {
    this.router.navigate(['/dashboard']);
  }
  ngOnInit() {
  this.floorForm = this._formBuilder.array([ this.createFloorGroup(),]);
  }

  createFloorGroup(): FormGroup {
    return this._formBuilder.group({
     
      
    });
  }
  
  getfloorFormControls() {
    return this.floorForm.controls;
  }


  submitForm() {
    if (this.floorForm.valid) {
      console.log(this.floorForm.value);
      alert('Form submitted successfully!');
    } else {
      alert('Please fill out all required fields!');
    }
  }

}

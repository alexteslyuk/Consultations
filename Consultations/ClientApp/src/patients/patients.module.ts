import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CreatePatientComponent } from "./create-patient/create-patient.component";
import { EditPatientComponent } from "./edit-patient/edit-patient.component";
import { PatientsComponent } from "./patients/patients.component";
import { MatFormFieldModule } from '@angular/material/form-field';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from "ng-pick-datetime";
import { MatTableModule } from '@angular/material/table';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CommonModule } from "@angular/common";
import { MatButtonModule } from "@angular/material/button";
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

@NgModule({
  declarations: [PatientsComponent, CreatePatientComponent, EditPatientComponent],
  imports: [
    RouterModule.forChild(
      [
        { path: 'patients', component: PatientsComponent },
        { path: 'patients/create', component: CreatePatientComponent },
        { path: 'patients/edit/:id', component: EditPatientComponent }
      ]
    ),
    MatFormFieldModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    MatTableModule,
    FormsModule,
    ReactiveFormsModule,
    MatProgressSpinnerModule,
    CommonModule,
    MatButtonModule,
    MatInputModule,
    BrowserAnimationsModule
  ],
  exports: [PatientsComponent, CreatePatientComponent, EditPatientComponent]
})
export class PatientsModule { }

import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { MatFormFieldModule } from '@angular/material/form-field';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from "ng-pick-datetime";
import { MatTableModule } from '@angular/material/table';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CommonModule } from "@angular/common";
import { MatButtonModule } from "@angular/material/button";
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ConsultationsComponent } from "./consultations/consultations.component";
import { CreateConsultationComponent } from "./create-consultation/create-consultation.component";
import { EditConsultationComponent } from "./edit-consultation/edit-consultation.component";

@NgModule({
  declarations: [ConsultationsComponent, CreateConsultationComponent, EditConsultationComponent],
  imports: [
    RouterModule.forChild(
      [
        { path: 'consultations/:patientId', component: ConsultationsComponent },
        { path: 'consultations/create/:patientId', component: CreateConsultationComponent },
        { path: 'consultations/edit/:id', component: EditConsultationComponent }
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
  exports: [ConsultationsComponent, CreateConsultationComponent, EditConsultationComponent]
})
export class ConsultationsModule { }

import { HttpClient } from "@angular/common/http";
import { Component, Inject } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { Router } from "@angular/router";

@Component({
  selector: 'patients-create-patient',
  templateUrl: './create-patient.component.html'
})
export class CreatePatientComponent {
  createPatientForm;

  constructor(
    formBuilder: FormBuilder,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private router: Router
  ){
    this.createPatientForm = formBuilder.group({
      surname: ['', Validators.required],
      name: ['', Validators.required],
      patronymic: [''],
      birthdate: [new Date()],
      gender: ['', Validators.required],
      snils: ['', Validators.required],
      weight: null,
      height: null
    });
  }

  get form() {
    return this.createPatientForm.controls;
  }

  async onSubmit(data: any) {
    if (this.createPatientForm.invalid)
      return;

    this.http.post(this.baseUrl + 'api/Patient/Create', data).subscribe(() => this.router.navigate(['/patients']));
  }
}

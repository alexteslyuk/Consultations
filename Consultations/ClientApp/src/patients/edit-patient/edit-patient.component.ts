import { HttpClient } from "@angular/common/http";
import { Component, Inject } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: 'patients-edit-patient',
  templateUrl: './edit-patient.component.html'
})
export class EditPatientComponent {
  editPatientForm;
  patientLoaded: boolean = false;
  id: number | null = null;

  constructor(
    formBuilder: FormBuilder,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private router: Router,
    private route: ActivatedRoute,
  ) {
    this.editPatientForm = formBuilder.group({
      surname: ['', Validators.required],
      name: ['', Validators.required],
      patronymic: [''],
      birthdate: [new Date()],
      gender: ['', Validators.required],
      snils: ['', Validators.required],
      weight: null,
      height: null
    });

    var id = this.route.snapshot.paramMap.get('id');

    if (id != null) {
      this.id = +id;
      this.http.get<any>(this.baseUrl + `api/Patient/Get?id=${this.id}`).subscribe(result => {
        this.editPatientForm = formBuilder.group({
          surname: [result.surname, Validators.required],
          name: [result.name, Validators.required],
          patronymic: [result.patronymic],
          birthdate: [result.birthDate],
          gender: [result.surname, Validators.required],
          snils: [result.surname, Validators.required],
          weight: [result.weight],
          height: [result.height]
        });
      });
      this.patientLoaded = true;
    }
  }

  get form() {
    return this.editPatientForm.controls;
  }

  async onSubmit(data: any) {
    if (this.editPatientForm.invalid || this.id == null)
      return;

    this.http.post(this.baseUrl + `api/Patient/Edit?id=${this.id}`, data).subscribe(() => this.router.navigate(['/patients']));
  }
}

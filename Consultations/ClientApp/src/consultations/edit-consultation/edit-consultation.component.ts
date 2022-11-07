import { HttpClient } from "@angular/common/http";
import { Component, Inject } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: 'consultations-edit-consultation',
  templateUrl: './edit-consultation.component.html'
})
export class EditConsultationComponent {
  editConsultationForm;
  consultationLoaded: boolean = false;
  id: number | null = null;
  patientId: number | null = null;

  constructor(
    formBuilder: FormBuilder,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private router: Router,
    private route: ActivatedRoute,
  ) {
    this.editConsultationForm = formBuilder.group({
      startDate: [new Date(), Validators.required],
      endDate: [new Date(), Validators.required],
      symptoms: [''],
    });

    var id = this.route.snapshot.paramMap.get('id');

    if (id != null) {
      this.id = +id;
      this.http.get<any>(`${this.baseUrl}api/Consultation/Get?id=${this.id}`).subscribe(result => {
        this.editConsultationForm = formBuilder.group({
          startDate: [result.startDate, Validators.required],
          endDate: [result.endDate, Validators.required],
          symptoms: [result.symptoms],
        });
        this.patientId = result.patientId;
      });
      this.consultationLoaded = true;
    }
  }

  get form() {
    return this.editConsultationForm.controls;
  }

  async onSubmit(data: any) {
    if (this.editConsultationForm.invalid || this.id == null)
      return;

    data.patientId = this.patientId;

    this.http.post(`${this.baseUrl}api/Consultation/Edit?id=${this.id}`, data).subscribe(() => this.router.navigate([`/consultations/${this.patientId}`]));
  }
}

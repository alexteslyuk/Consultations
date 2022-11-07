import { HttpClient } from "@angular/common/http";
import { Component, Inject } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: 'consultations-create-consultation',
  templateUrl: './create-consultation.component.html'
})
export class CreateConsultationComponent {
  createConsultationForm;
  patientId: number | null = null;

  constructor(
    formBuilder: FormBuilder,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private router: Router,
    private route: ActivatedRoute
  ) {
    var patientId = this.route.snapshot.paramMap.get('patientId');
    if (patientId != null) {
      this.patientId = +patientId;
    }
    this.createConsultationForm = formBuilder.group({
      startDate: [new Date(), Validators.required],
      endDate: [new Date(), Validators.required],
      symptoms: ['']
    });
  }

  get form() {
    return this.createConsultationForm.controls;
  }

  async onSubmit(data: any) {
    if (this.createConsultationForm.invalid)
      return;

    data.patientId = this.patientId;

    this.http.post(`${this.baseUrl}api/Consultation/Create`, data).subscribe(() => this.router.navigate([`/consultations/${this.patientId}`]));
  }
}

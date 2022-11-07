import { HttpClient } from "@angular/common/http";
import { Component, Inject } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'consultations-consultations',
  templateUrl: './consultations.component.html'
})

export class ConsultationsComponent {
  displayedColumns = ['startDate', 'endDate', 'symptoms', 'edit', 'delete'];
  public patient: any;
  patientLoaded = false;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private route: ActivatedRoute
  ) {
    var id = this.route.snapshot.paramMap.get('patientId');
    if (id != null) {
      this.http.get<any>(`${this.baseUrl}api/Patient/Get?id=${+id}&withConsultations=true`).subscribe(result => {
        this.patient = result;
        this.patientLoaded = true;
      });
    }
  }

  delete(consultation: any) {
    this.patient.consultations = this.patient.consultations.filter((e: any) => e != consultation);
    this.http.delete(this.baseUrl + `api/Consultation/Delete?id=${consultation.id}`).subscribe();
  }
}

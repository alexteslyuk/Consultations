import { HttpClient } from "@angular/common/http";
import { Component, Inject } from "@angular/core";

@Component({
  selector: 'patients-patients',
  templateUrl: './patients.component.html',
  styleUrls: ['./patients.component.css']
})

export class PatientsComponent {
  displayedColumns = ['surname', 'name', 'patronymic', 'birthdate', 'gender', 'snils', 'height', 'weight', 'age', 'consultations', 'edit', 'delete' ];
  public patients: any;
  patientsLoaded = false;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) {
    this.http.get<any>(this.baseUrl + `api/Patient/GetAll/`).subscribe(result => {
      this.patients = result;
      this.patientsLoaded = true;
    });
  }

  delete(patient: any) {
    this.patients = this.patients.filter((e: any) => e != patient);
    this.http.delete(this.baseUrl + `api/Patient/Delete?id=${patient.id}`).subscribe();
  }
}

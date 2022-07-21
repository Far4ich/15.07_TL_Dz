import { Injectable } from "@angular/core";
import { IPatient } from './patient.interface';
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class PatientService {
    private readonly apiUrl: string = 'http://localhost:4200/api/patient';

    constructor(private httpClient: HttpClient) {
    }

    public addPatient(patient: IPatient): Observable<null> {
        return this.httpClient.post<null>(`${this.apiUrl}/create`, patient);
    }

    public updatePatient(patient: IPatient): Observable<null> {
        return this.httpClient.put<null>(`${this.apiUrl}/update`, patient);
    }

    public deletePatient(id: number): Observable<object> {
        return this.httpClient.delete(`${this.apiUrl}/${id}/delete`);
    }

    public getPatients(): Observable<IPatient[]> {
        return this.httpClient.get<IPatient[]>(`${this.apiUrl}/list`);
    }
}

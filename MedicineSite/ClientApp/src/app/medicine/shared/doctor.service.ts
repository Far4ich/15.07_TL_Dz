import { Injectable } from "@angular/core";
import { IDoctor } from './doctor.interface';
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class DoctorService {
    private readonly apiUrl: string = 'http://localhost:4200/api/doctor';

    constructor(private httpClient: HttpClient) {
    }

    public addDoctor(doctor: IDoctor): Observable<null> {
        return this.httpClient.post<null>(`${this.apiUrl}/create`, doctor);
    }

    public updateDoctor(doctor: IDoctor): Observable<null> {
        return this.httpClient.put<null>(`${this.apiUrl}/update`, doctor);
    }

    public deleteDoctor(id: number): Observable<object> {
        return this.httpClient.delete(`${this.apiUrl}/${id}/delete`);
    }

    public getDoctors(): Observable<IDoctor[]> {
        return this.httpClient.get<IDoctor[]>(`${this.apiUrl}/list`);
    }
}

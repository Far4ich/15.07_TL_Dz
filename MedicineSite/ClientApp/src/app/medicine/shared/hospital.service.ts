import { Injectable } from "@angular/core";
import { IHospital } from './hospital.interface';
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class HospitalService {
    private readonly apiUrl: string = 'http://localhost:4200/api/hospital';

    constructor(private httpClient: HttpClient) {
    }

    public addHospital(hospital: IHospital): Observable<null> {
        return this.httpClient.post<null>(`${this.apiUrl}/create`, hospital);
    }

    public updateHospital(hospital: IHospital): Observable<null> {
        return this.httpClient.put<null>(`${this.apiUrl}/update`, hospital);
    }

    public deleteHospital(id: number): Observable<object> {
        return this.httpClient.delete(`${this.apiUrl}/${id}/delete`);
    }

    public getHospitals(): Observable<IHospital[]> {
        return this.httpClient.get<IHospital[]>(`${this.apiUrl}/list`);
    }
}

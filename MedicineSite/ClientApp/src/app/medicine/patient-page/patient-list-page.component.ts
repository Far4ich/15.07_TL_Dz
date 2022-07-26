import { Component, OnInit } from '@angular/core';
import { IPatient } from "../shared/patient.interface";
import { PatientService } from "../shared/patient.service";
import { AbstractControl, FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
    selector: 'patient-list-page',
    templateUrl: './patient-list-page.component.html',
    styleUrls: ['./patient-list-page.component.scss'],
    providers: [PatientService]
})
export class PatientListPageComponent implements OnInit {
    public items: IPatient[];
    public form: FormGroup;

    constructor(private patientService: PatientService) {
        this.reloadPatients();
    }

    public reloadPatients(): void {
        this.patientService.getPatients().subscribe(patients => {
            this.items = patients;
        })
    }

    public ngOnInit(): void {
        this.form = new FormGroup({
            id: new FormControl(null),
            name: new FormControl(null, [Validators.required]),
            healthCardNumber: new FormControl(null, [Validators.required]),
            doctorId: new FormControl(null, [Validators.required])
        });
    }

    public addItem(): void {
        if (this.form.invalid) {
            return;
        }
        this.patientService.addPatient({
            name: this.nameControl.value,
            healthCardNumber: this.healthCardNumberControl.value,
            doctorId: this.doctorIdControl.value
        }).subscribe(() => {
            this.reloadPatients();
            this.nameControl.setValue(null);
            this.healthCardNumberControl.setValue(null);
            this.doctorIdControl.setValue(null);
            this.form.markAsUntouched();
        });
    }

    public updatePatient(): void {
        this.patientService.updatePatient({
            id: this.idControl.value,
            name: this.nameControl.value,
            healthCardNumber: this.healthCardNumberControl.value,
            doctorId: this.doctorIdControl.value
        }).subscribe(() => {
            this.reloadPatients();
            this.nameControl.setValue(null);
            this.healthCardNumberControl.setValue(null);
            this.doctorIdControl.setValue(null);
            this.form.markAsUntouched();
        });
    }

    public deletePatient(patient: IPatient): void {
        this.patientService.deletePatient(patient.id).subscribe(() => {
            this.reloadPatients();
        });
    }

    get idControl(): AbstractControl {
        return this.form.get('id');
    }

    get nameControl(): AbstractControl {
        return this.form.get('name');
    }
    get healthCardNumberControl(): AbstractControl {
        return this.form.get('healthCardNumber');
    }
    get doctorIdControl(): AbstractControl {
        return this.form.get('doctorId');
    }
}

import { Component, OnInit, ViewChild } from '@angular/core';
import { IHospital } from "../shared/hospital.interface";
import { HospitalService } from "../shared/hospital.service";
import { AbstractControl, FormControl, FormGroup, Validators } from "@angular/forms";
import { DoctorListPageComponent } from '../doctor-page/doctor-list-page.component';

@Component({
    selector: 'hospital-list-page',
    templateUrl: './hospital-list-page.component.html',
    styleUrls: ['./hospital-list-page.component.scss'],
    providers: [HospitalService]
})
export class HospitalListPageComponent implements OnInit {
    public items: IHospital[];

    public form: FormGroup;

    @ViewChild(DoctorListPageComponent) doctorPage:DoctorListPageComponent;

    constructor(private hospitalService: HospitalService) {
        this.reloadHospitals();
    }

    private reloadHospitals(): void {
        this.hospitalService.getHospitals().subscribe(hospitals => {
            this.items = hospitals;
        })
    }

    public ngOnInit(): void {
        this.form = new FormGroup({
            name: new FormControl(null, [Validators.required]),
            address: new FormControl(null, [Validators.required]),
            telephoneNumber: new FormControl(null, [Validators.required])
        });
    }

    public addItem(): void {
        if (this.form.invalid) {
            return;
        }
        this.hospitalService.addHospital({
            name: this.nameControl.value,
            address: this.addressControl.value,
            telephoneNumber: this.telephoneNumberControl.value
        }).subscribe(() => {
            this.reloadHospitals();
            this.nameControl.setValue(null);
            this.addressControl.setValue(null);
            this.telephoneNumberControl.setValue(null);
            this.form.markAsUntouched();
        });
    }

    public updateHospital(todo: IHospital): void {
        this.hospitalService.updateHospital({
                id: todo.id,
                name: this.nameControl.value,
                address: this.addressControl.value,
                telephoneNumber: this.telephoneNumberControl.value
        }).subscribe(() => {
            this.reloadHospitals();
            this.nameControl.setValue(null);
            this.addressControl.setValue(null);
            this.telephoneNumberControl.setValue(null);
            this.form.markAsUntouched();
        });
    }

    public deleteHospital(todo: IHospital): void {
        this.hospitalService.deleteHospital(todo.id).subscribe(() => {
            this.reloadHospitals();
            this.doctorPage.reloadDoctorsPatients();
        });
    }

    get nameControl(): AbstractControl {
        return this.form.get('name');
    }

    get addressControl(): AbstractControl {
        return this.form.get('address');
    }
    get telephoneNumberControl(): AbstractControl {
        return this.form.get('telephoneNumber');
    }
}

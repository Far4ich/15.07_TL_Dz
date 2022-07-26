import { Component, OnInit } from '@angular/core';
import { IDoctor } from "../shared/doctor.interface";
import { DoctorService } from "../shared/doctor.service";
import { AbstractControl, FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
    selector: 'doctor-list-page',
    templateUrl: './doctor-list-page.component.html',
    styleUrls: ['./doctor-list-page.component.scss'],
    providers: [DoctorService],
})

export class DoctorListPageComponent implements OnInit {
    public items: IDoctor[];
    public form: FormGroup;

    constructor(private doctorService: DoctorService) {
        this.reloadDoctors();
    }

    public reloadDoctors(): void {
        this.doctorService.getDoctors().subscribe(doctors => {
            this.items = doctors;
        })
    }

    public ngOnInit(): void {
        this.form = new FormGroup({
            id: new FormControl(null),
            name: new FormControl(null, [Validators.required]),
            hospitalId: new FormControl(null, [Validators.required]),
            telephoneNumber: new FormControl(null, [Validators.required])
        });
    }

    public addItem(): void {
        if (this.form.invalid) {
            return;
        }
        this.doctorService.addDoctor({
            name: this.nameControl.value,
            hospitalId: this.hospitalIdControl.value,
            telephoneNumber: this.telephoneNumberControl.value
        }).subscribe(() => {
            this.reloadDoctors();
            this.nameControl.setValue(null);
            this.hospitalIdControl.setValue(null);
            this.telephoneNumberControl.setValue(null);
            this.form.markAsUntouched();
        });
    }

    public updateDoctor(): void {
        this.doctorService.updateDoctor({
                id: this.idControl.value,
                name: this.nameControl.value,
                hospitalId: this.hospitalIdControl.value,
                telephoneNumber: this.telephoneNumberControl.value
        }).subscribe(() => {
            this.reloadDoctors();
            this.nameControl.setValue(null);
            this.hospitalIdControl.setValue(null);
            this.telephoneNumberControl.setValue(null);
            this.form.markAsUntouched();
        });
    }

    public deleteDoctor(todo: IDoctor): void {
        this.doctorService.deleteDoctor(todo.id).subscribe(() => {
            this.reloadDoctors();
        });
    }

    get idControl(): AbstractControl {
        return this.form.get('id');
    }

    get nameControl(): AbstractControl {
        return this.form.get('name');
    }

    get telephoneNumberControl(): AbstractControl {
        return this.form.get('telephoneNumber');
    }
    
    get hospitalIdControl(): AbstractControl {
        return this.form.get('hospitalId');
    }
}

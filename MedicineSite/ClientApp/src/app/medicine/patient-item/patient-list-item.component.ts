import { Component, EventEmitter, Input, Output } from "@angular/core";
import { IPatient } from "../shared/patient.interface";

@Component({
    selector: 'tl-patient-list-item',
    templateUrl:'./patient-list-item.component.html',
    styleUrls: ['patient-list-item.css'],
})

export class PatientListItemComponent {
    @Input() public item: IPatient;
    @Output() public update: EventEmitter<IPatient> = new EventEmitter<IPatient>();
    @Output() public delete: EventEmitter<IPatient> = new EventEmitter<IPatient>();

    public deleteClicked(): void {
        this.delete.emit(this.item);
    }

    public updateClicked(): void {
        this.update.emit(this.item);
    }
}

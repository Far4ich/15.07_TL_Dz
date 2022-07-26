import { Component, EventEmitter, Input, Output } from "@angular/core";
import { IPatient } from "../shared/patient.interface";

@Component({
    selector: 'tl-patient-list-item',
    templateUrl:'./patient-list-item.component.html',
    styleUrls: ['patient-list-item.css'],
})

export class PatientListItemComponent {

    displayedColumns: string[] = ['id', 'name', 'healthCardNumber', 'doctorId', 'actions'];
    @Input() public dataSource: IPatient[];
    @Output() public delete: EventEmitter<IPatient> = new EventEmitter<IPatient>();

    public deleteClicked(element: IPatient): void {
        this.delete.emit(element);
    }
}

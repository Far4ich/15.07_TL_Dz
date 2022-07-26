import { Component, EventEmitter, Input, Output } from "@angular/core";
import { IDoctor } from "../shared/doctor.interface";

@Component({
    selector: 'tl-doctor-list-item',
    templateUrl:'./doctor-list-item.component.html',
    styleUrls: ['doctor-list-item.css']
})

export class DoctorListItemComponent { 
    displayedColumns: string[] = ['id', 'name', 'telephoneNumber', 'hospitalId', 'actions'];
    @Input() public dataSource: IDoctor[];
    @Output() public delete: EventEmitter<IDoctor> = new EventEmitter<IDoctor>();

    public deleteClicked(element: IDoctor): void {
        this.delete.emit(element);
    }
}

import { Component, EventEmitter, Input, Output } from "@angular/core";
import { IHospital } from "../shared/hospital.interface";

@Component({
    selector: 'tl-hospital-list-item',
    templateUrl:'./hospital-list-item.component.html',
    styleUrls: ['hospital-list-item.css']
})

export class HospitalListItemComponent {
    displayedColumns: string[] = ['id', 'name', 'address', 'telephoneNumber', 'actions'];
    @Input() public dataSource: IHospital[];
    @Output() public delete: EventEmitter<IHospital> = new EventEmitter<IHospital>();

    public deleteClicked(element:IHospital): void {
        this.delete.emit(element);
    }
}

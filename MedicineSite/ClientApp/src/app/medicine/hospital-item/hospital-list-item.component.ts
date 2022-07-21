import { Component, EventEmitter, Input, Output } from "@angular/core";
import { IHospital } from "../shared/hospital.interface";

@Component({
    selector: 'tl-hospital-list-item',
    templateUrl:'./hospital-list-item.component.html'
})

export class HospitalListItemComponent {
    @Input() public item: IHospital;
    @Output() public update: EventEmitter<IHospital> = new EventEmitter<IHospital>();
    @Output() public delete: EventEmitter<IHospital> = new EventEmitter<IHospital>();

    public deleteClicked(): void {
        this.delete.emit(this.item);
    }

    public updateClicked(): void {
        this.update.emit(this.item);
    }
}

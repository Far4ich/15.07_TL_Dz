import { Component, EventEmitter, Input, Output } from "@angular/core";
import { IDoctor } from "../shared/doctor.interface";

@Component({
    selector: 'tl-doctor-list-item',
    templateUrl:'./doctor-list-item.component.html'
})

export class DoctorListItemComponent {
    @Input() public item: IDoctor;
    @Output() public update: EventEmitter<IDoctor> = new EventEmitter<IDoctor>();
    @Output() public delete: EventEmitter<IDoctor> = new EventEmitter<IDoctor>();

    public deleteClicked(): void {
        this.delete.emit(this.item);
    }

    public updateClicked(): void {
        this.update.emit(this.item);
    }
}

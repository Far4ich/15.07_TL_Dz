import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatListModule } from "@angular/material/list";
import { MatIconModule } from "@angular/material/icon";
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatSliderModule } from '@angular/material/slider';
import {MatPaginatorModule} from "@angular/material/paginator";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner"
import {MatSortModule} from "@angular/material/sort";
import {MatTableModule } from "@angular/material/table";
import {MatToolbarModule} from '@angular/material/toolbar';

import { MedicinePageComponent } from './medicine-page/medicine-page.component';
import { MedicineRoutingModule } from './medicine-routing.module';

import { HospitalService } from './shared/hospital.service';
import { HospitalListItemComponent } from './hospital-item/hospital-list-item.component'
import { HospitalListPageComponent } from './hospital-page/hospital-list-page.component';

import { DoctorService } from './shared/doctor.service';
import { DoctorListItemComponent } from './doctor-item/doctor-list-item.component'
import { DoctorListPageComponent } from './doctor-page/doctor-list-page.component';

import { PatientService } from './shared/patient.service';
import { PatientListItemComponent } from './patient-item/patient-item.component'
import { PatientPageComponent } from './patient-page/patient-page.component';

@NgModule({
  declarations: [
    MedicinePageComponent,
    HospitalListItemComponent,
    DoctorListItemComponent,
    PatientListItemComponent,
    HospitalListPageComponent,
    DoctorListPageComponent,
    PatientPageComponent
  ],
  imports: [
    MatToolbarModule,
    CommonModule,
    MedicineRoutingModule,
    MatCardModule,
    MatButtonModule,
    MatListModule,
    MatIconModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSliderModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatSortModule,
    MatTableModule
  ],
  providers: [
    HospitalService,
    DoctorService,
    PatientService
  ]
})
export class MedicineModule { }

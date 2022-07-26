import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorListPageComponent } from './medicine/doctor-page/doctor-list-page.component';
import { HospitalListPageComponent } from './medicine/hospital-page/hospital-list-page.component';
import { MedicinePageComponent } from './medicine/medicine-page/medicine-page.component';
import { PatientListPageComponent } from './medicine/patient-page/patient-list-page.component';

const routes: Routes = [
    
    {
        path:'hospital',
        component: HospitalListPageComponent
    },
    {
        path:'doctor',
        component: DoctorListPageComponent
    },
    {
        path:'patient',
        component: PatientListPageComponent
    },
    {
        path: '**',
        component: MedicinePageComponent
    },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

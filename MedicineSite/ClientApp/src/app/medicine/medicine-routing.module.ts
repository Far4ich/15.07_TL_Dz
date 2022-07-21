import { NgModule } from '@angular/core';
import { DoctorListPageComponent } from './doctor-page/doctor-list-page.component';
import { RouterModule, Routes } from '@angular/router';
import { HospitalListPageComponent } from './hospital-page/hospital-list-page.component';

const routes: Routes = [
  {
    path: "hospital",
    component: HospitalListPageComponent
  },
  {
    path:"doctor",
    component: DoctorListPageComponent
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class MedicineRoutingModule { }

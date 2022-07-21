import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MedicinePageComponent } from './medicine/medicine-page/medicine-page.component';

const routes: Routes = [
    {
        path: '**',
        component: MedicinePageComponent
    }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

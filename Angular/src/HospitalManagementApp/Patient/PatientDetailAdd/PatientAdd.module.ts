import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import { HttpClientModule } from '@angular/common/http';
import { PatientAddComponent } from './PatientAdd.component';
import { CommonModule } from '@angular/common';
import { AuthGuard } from 'src/HospitalManagementApp/Shared/Auth.guard';
@NgModule({
  declarations: [
    PatientAddComponent
  ],
  imports: [
    RouterModule.forChild([
      {path:'Add', component:PatientAddComponent}
    ]),
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [PatientAddComponent]
})
export class PatientAddModule { }

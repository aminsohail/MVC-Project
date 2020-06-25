
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms"
import {RouterModule} from "@angular/router";
import { HttpClientModule } from '@angular/common/http';
import { PatientSearchComponent } from './PatientSearch.component';
import { CommonModule } from '@angular/common';
@NgModule({
  declarations: [
    PatientSearchComponent
  ],
  imports: [
    RouterModule.forChild([
      {path:'Search', component:PatientSearchComponent}
    ]),
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [PatientSearchComponent]
})
export class PatientSearchModule { }

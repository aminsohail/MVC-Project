import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms"
import {RouterModule} from "@angular/router"
import { HospitalManagementComponent } from './HospitalManagement.component';
import { HttpClientModule } from '@angular/common/http';
import { HospitalManagementSearchComponent } from './hospital-management-search/hospital-management-search.component';
import { HospitalManagementMasterPageComponent } from './hospital-management-master-page/hospital-management-master-page.component';
@NgModule({
  declarations: [
    HospitalManagementComponent,
    HospitalManagementSearchComponent,
    HospitalManagementMasterPageComponent
  ],
  imports: [
    RouterModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [HospitalManagementComponent]
})
export class HospitalManagementModule { }

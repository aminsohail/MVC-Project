import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from "@angular/forms"
import {RouterModule} from "@angular/router"
import { HospitalManagementComponent } from './HospitalManagement.component';
import { HttpClientModule } from '@angular/common/http';
@NgModule({
  declarations: [
    HospitalManagementComponent
  ],
  imports: [
    RouterModule,
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [HospitalManagementComponent]
})
export class HospitalManagementModule { }

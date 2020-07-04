
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms"
import {RouterModule} from "@angular/router";
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { PatientSearchComponent } from './PatientSearch.component';
import { CommonModule } from '@angular/common';
import { AuthGuard } from 'src/HospitalManagementApp/Shared/Auth.guard';
import { TokenInterceptor } from 'src/HospitalManagementApp/Shared/Token.Interceptor';
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
  providers: [
    { 
      provide: HTTP_INTERCEPTORS, 
      useClass: TokenInterceptor, 
      multi: true }
  ],
  bootstrap: [PatientSearchComponent]
})
export class PatientSearchModule { }

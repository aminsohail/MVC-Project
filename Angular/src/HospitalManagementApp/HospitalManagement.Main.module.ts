import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms"
import {RouterModule} from "@angular/router"
import { HttpClientModule } from '@angular/common/http';
import { HospitalManagementMasterPageComponent } from './HospitalManagementMasterPage/HospitalManagementMasterPage.component';
@NgModule({
  declarations: [
    HospitalManagementMasterPageComponent
  ],
  imports: [
    RouterModule.forRoot([
      
      {path:'PatientAdd', loadChildren:'./Patient/PatientDetailAdd/PatientAdd.module#PatientAddModule'},
             //   loadChildren:()=> 
              //  import('./Patient/PatientDetailAdd/PatientAdd.module')
              // .then(m =>m.PatientAddModule)},
      {path:'PatientSearch',loadChildren:'./Patient/PatientSearch/PatientSearch.module#PatientSearchModule'}
            //    loadChildren:()=>
            //    import('./Patient/PatientSearch/PatientSearch.module')
             //   .then(m=>m.PatientSearchModule)}
   //   {path:'**', component:HospitalManagementMasterPageComponent}
    ]),
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [HospitalManagementMasterPageComponent]
})
export class HospitalManagementModule { }

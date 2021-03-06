import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms"
import {RouterModule} from "@angular/router"
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HospitalManagementMasterPageComponent } from './HospitalManagementMasterPage/HospitalManagementMasterPage.component';
import { PatientLoginComponent } from './HospitalManagementMasterPage/PatientLogin/PatientLogin.component';
import { User } from './HospitalManagementMasterPage/PatientLogin/PatientLogin.Model';
import { AuthGuard } from './Shared/Auth.guard';
import { HomeComponent } from './HospitalManagementMasterPage/home/home.component';
import { TokenInterceptor } from './Shared/Token.Interceptor';
import { RegistrationModule } from './registration/registration.module';
import { RegistrationComponent } from './registration/registration.component';
import { RegisterService } from './Shared/services';
import {MatTableModule} from '@angular/material/table';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 

@NgModule({
  declarations: [
    HospitalManagementMasterPageComponent,
    PatientLoginComponent,
    HomeComponent,
  ],
  imports: [
    RouterModule.forRoot([
      {path:'', component:HomeComponent, canActivate:[AuthGuard]},
     //{path:'', component:HomeComponent},
    //  {path:'Home', component:HomeComponent, canActivate:[AuthGuard]},
    {path:'Home', component:HomeComponent, canActivate:[AuthGuard]},
      {path:'Patient', 
              loadChildren:'./Patient/PatientDetailAdd/PatientAdd.module#PatientAddModule',
                canActivate:[AuthGuard]},
             //   loadChildren:()=> 
              //  import('./Patient/PatientDetailAdd/PatientAdd.module')
              // .then(m =>m.PatientAddModule)},
      {path:'Patient',
              loadChildren:'./Patient/PatientSearch/PatientSearch.module#PatientSearchModule', 
              canActivate:[AuthGuard]},
            //    loadChildren:()=>
            //    import('./Patient/PatientSearch/PatientSearch.module')
             //   .then(m=>m.PatientSearchModule)}
   //   {path:'**', component:HospitalManagementMasterPageComponent}

      {path:'PatientLogin', component:PatientLoginComponent},
      {path:'Registration', component:RegistrationComponent}
    ]),
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RegistrationModule,
    MatTableModule,
    BrowserAnimationsModule
    
  ],
  providers: [
    User, 
    AuthGuard, 
       { 
          provide: HTTP_INTERCEPTORS, 
          useClass: TokenInterceptor, 
          multi: true },
          RegisterService
         
    ],
  bootstrap: [HospitalManagementMasterPageComponent]
})
export class HospitalManagementModule { }

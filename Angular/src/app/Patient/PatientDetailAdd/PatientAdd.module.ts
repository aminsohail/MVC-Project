import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { PatientAddComponent } from './PatientAdd.component';
import { CommonModule } from '@angular/common';
import { AuthGuard } from 'src/app/Shared/Auth.guard';
import { TokenInterceptor } from 'src/app/Shared/Token.Interceptor';
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
  providers: [ { 
    provide: HTTP_INTERCEPTORS, 
    useClass: TokenInterceptor, 
    multi: true }],
  bootstrap: [PatientAddComponent]
})
export class PatientAddModule { }

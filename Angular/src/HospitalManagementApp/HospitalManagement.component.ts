import { Component } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {PatientModel} from './HospitalManagement.model'
import { e } from '@angular/core/src/render3';


@Component({
  selector: 'app-root',
  templateUrl: './HospitalManagement.component.html',
})
export class HospitalManagementComponent {
  title = 'HospitalManagement';
  constructor(public Http:HttpClient){
    this.patientObj=new PatientModel()
  }
  errorMsg=[];
  patientObj:PatientModel= null;
  patientList:Array<PatientModel>=new Array<PatientModel>();
  
  // Add(){
  //   this.PatientList.push(this.patientObj)
  // }

   Submit(){
     
        //  this.Http.post("https://localhost:44372/Patient/Submit",this.patientObj)
        //  .subscribe(data => {
        //   let res:any = data; 
        // },);

      
          this.Http.post("https://localhost:44372/Patient/Submit", this.patientObj)
              .subscribe(
                res=>this.Success(res),
                res=>this.Error(res)
            );

   }
  Success(res){
    this.patientList=res;
    this.patientObj=new PatientModel();
  }
   
   Error(res){
    this.errorMsg=res;
    
    
   }
}

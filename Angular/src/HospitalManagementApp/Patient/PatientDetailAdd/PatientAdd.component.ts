import { Component } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {PatientModel} from './PatientAdd.model';


@Component({
  selector: 'app-root',
  templateUrl: './PatientAdd.component.html',
})
export class PatientAddComponent {
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

        let patientDetail={
          id:this.patientObj.id,
          name: this.patientObj.name,
          problemDescription:this.patientObj.problemDescription
        }

              this.Http.post("https://localhost:44372/api/PatientAPI", patientDetail)
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
   // this.errorMsg=res;
    alert(res)
    
   }
}

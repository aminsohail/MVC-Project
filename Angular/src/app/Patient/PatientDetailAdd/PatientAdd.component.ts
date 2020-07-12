import { Component } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {PatientModel, PatientProblem} from './PatientAdd.model';


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
  patientProblem:PatientProblem = new PatientProblem();
  
  // Add(){
  //   this.PatientList.push(this.patientObj)
  // }
  successMessage=0;

  AddProblem(){
      this.patientObj.patientProblemCollection.push(this.patientProblem);
      this.patientProblem = new PatientProblem();
   }
   Submit(){
    
    var patientDetail:any={}
       // let patientDetail={
        patientDetail.id=this.patientObj.id;
        patientDetail.name= this.patientObj.name;
        patientDetail.problems=[];
        patientDetail.problems= this.patientObj.patientProblemCollection;
       //   problemDescription:this.patientObj.problemDescription
          
//}

              this.Http.post("https://localhost:44372/api/PatientAPI", patientDetail)
                  .subscribe(
                    res=>this.Success(res),
                    res=>this.Error(res)
                );

      }
  Success(res){
    this.successMessage=1
    debugger;
    this.patientList=res;
    this.patientObj=new PatientModel();
  }
   
   Error(res){
   // this.errorMsg=res;
    alert(res)
    
   }
}

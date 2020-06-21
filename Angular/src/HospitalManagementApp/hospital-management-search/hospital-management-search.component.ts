import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PatientModel } from '../HospitalManagement.model';

@Component({
  selector: 'hospital-management-search',
  templateUrl: './hospital-management-search.component.html',
  styleUrls: ['./hospital-management-search.component.css']
})
export class HospitalManagementSearchComponent{
  patientName:string = "";
  patientModel: Array<PatientModel>=new Array <PatientModel>();
  constructor(public Http:HttpClient) { 

  }

        Search(){
          this.Http.get("https://localhost:44372/api/PatientAPI?patientName="+this.patientName)
                   .subscribe(
                    res=>this.Success(res),
                    res=>this.Error(res)
                   );

        }

        Success(res){
          this.patientModel=res;
        
        }

        Error(res){
          
        }

}

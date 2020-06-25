import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PatientModel } from '../PatientDetailAdd/PatientAdd.model';

@Component({
  selector: 'hospital-management-search',
  templateUrl: './PatientSearch.component.html',
  styleUrls: ['./PatientSearch.component.css']
})
export class PatientSearchComponent{
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

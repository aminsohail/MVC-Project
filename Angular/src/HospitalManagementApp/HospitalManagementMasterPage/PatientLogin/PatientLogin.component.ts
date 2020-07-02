import { Component, OnInit } from '@angular/core';
import { PatientLogin } from './PatientLogin.Model';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-patient-login',
  templateUrl: './PatientLogin.component.html',
  styleUrls: ['./PatientLogin.component.css']
})
export class PatientLoginComponent{
  patientLoginObj:PatientLogin=new PatientLogin()
  
  constructor(private Http:HttpClient) { }
  
  Login(){
    let loginDetail={
      userName:this.patientLoginObj.userName,
      password:this.patientLoginObj.password
    }
      this.Http.post("https://localhost:44372/api/SecurityAPI", loginDetail)
          .subscribe(
              res=>this.Success(res),
              res=>this.Error(res)
                    );
  }

 

  Success(res){
    alert(res.token)
  }
  Error(res){}
 

}

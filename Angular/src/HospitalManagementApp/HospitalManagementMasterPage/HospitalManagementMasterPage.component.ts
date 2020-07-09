import { Component, OnInit } from '@angular/core';
import { User } from './PatientLogin/PatientLogin.Model';

@Component({
  selector: 'app-root',
  templateUrl: './HospitalManagementMasterPage.component.html',
  styleUrls: ['./HospitalManagementMasterPage.component.css']
})
export class HospitalManagementMasterPageComponent implements OnInit {

  constructor(private _user: User) { }

  ngOnInit() {
  }
  

}

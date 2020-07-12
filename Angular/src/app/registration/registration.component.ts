import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterService } from '../Shared/services';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent{

  constructor(private route:Router, private service:RegisterService) { 
  }
  
  signIn(){
    this.route.navigate(['PatientLogin']);
  }

  Register(){
     this.service.register().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.service.formModel.reset();
          alert('New user created!, Registration successful.');
        } else {
          res.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                alert('Username is already Exist, Please Try Again.');
                break;

              default:
              alert('Registration failed.');
                break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    );

    this.route.navigate(["PatientLogin"]);
  }

  }



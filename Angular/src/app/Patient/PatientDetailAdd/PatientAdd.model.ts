import{ NgForm,
           FormGroup,
                FormControl,
                   Validators,
        FormBuilder} from '@angular/forms'

export class PatientModel{
    id: number=0;
    name:string = "";
  //  problemDescription:string = "";

    patientProblemCollection: Array<PatientProblem>= new Array<PatientProblem>();  //  Just an Array to store multiple Problem Description

    // Create object of FormGroup
    formPatientGroup: FormGroup = null;

    constructor(){

        var _builder = new FormBuilder();

        // Use the builder to create 
        this.formPatientGroup = _builder.group({}); 

        this.formPatientGroup.
        addControl("NameControl",
                    new FormControl('',Validators.required)
        );

        this.formPatientGroup.
        addControl("ProblemDescriptionControl",
                    new FormControl('',Validators.required)
        );

    }


}


export class PatientProblem{
    id: number=0;
    problemDescription:string="";
}
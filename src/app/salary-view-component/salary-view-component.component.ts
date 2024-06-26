import { Component, OnInit } from '@angular/core';
import {EmploymentPercentage, ProfessionalLevel, ManagementLevel, AdditionGroup, EmployeeDetails, EmployeeSalaryDetails} from "src/app/models/employee-model"
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { CalculationService } from '../services/calculation.service';

@Component({
  selector: 'app-salary-view-component',
  templateUrl: './salary-view-component.component.html',
  styleUrls: ['./salary-view-component.component.scss']
})
export class SalaryViewComponentComponent implements OnInit {

  EmploymentPercentage = EmploymentPercentage;
  ProfessionalLevel = ProfessionalLevel;
  ManagementLevel = ManagementLevel;
  AdditionGroup = AdditionGroup;

//   פרטי העובד שיתמלאו בהטופס
employee!: EmployeeDetails;
// הטופס שממלא המשתמש
  salaryForm!: FormGroup;

  formSubmitted = false;
  //פרטי המשכורת שיחזרו מהשרת
  calculationResult: EmployeeSalaryDetails | null = null;
  formBuilder: any;


  constructor(private calculationService: CalculationService,  private fb: FormBuilder) { }
  ngOnInit(): void {
    //ולידציה לטופס
    this.salaryForm = this.fb.group({
      employmentPercentage: ['', Validators.required], 
      professionalLevel: ['', Validators.required], 
      managementLevel: ['', Validators.required], 
      yearsOfExperience: ['', Validators.min(0)], 
      isEligibleForAddition: ['', Validators.required], 
      additionGroup: [''] 
    });
  }
  onSubmit() {
    //מילוי פרטי העובד בהתאם לטופס שמילא המשתמש ע"מ לשלוח לשרת
    this.employee = {
      employmentPercentage: +this.salaryForm.value.employmentPercentage, 
      professionalLevel: +this.salaryForm.value.professionalLevel, 
      managementLevel: +this.salaryForm.value.managementLevel, 
      yearsOfExperience: +this.salaryForm.value.yearsOfExperience, 
      isEligibleForAddition: this.salaryForm.value.isEligibleForAddition === 'true',  
      additionGroup: +this.salaryForm.value.additionGroup 
    };
    if(this.employee.isEligibleForAddition == false)
      this.employee.additionGroup = undefined;

    this.formSubmitted = true;

    //קריאה לסרוויס שמשם נשלחת הקריאה לשרת
       this.calculationService.calculateSalary(this.employee)
    .subscribe( result => {
      this.calculationResult = result;
    },
    error => {
      console.error('Error occurred:', error);
      // תפיסת שגיאה אם יש
    }
  );
  }



}

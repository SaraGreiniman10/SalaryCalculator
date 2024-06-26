import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {EmploymentPercentage, ProfessionalLevel, ManagementLevel, AdditionGroup, EmployeeDetails, EmployeeSalaryDetails} from "src/app/models/employee-model"


@Injectable({
  providedIn: 'root'
})
export class CalculationService {
  urlString = 'https://localhost:7218/api/Salary/CalculateSalary';


  constructor(private http: HttpClient) {}

   calculateSalary(details: EmployeeDetails): Observable<EmployeeSalaryDetails> {
    return this.http.post<EmployeeSalaryDetails>(this.urlString, details);
  }

}

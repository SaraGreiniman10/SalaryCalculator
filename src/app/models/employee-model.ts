export enum EmploymentPercentage {
      Percent100 = 100,
      Percent75 = 75,
      Percent50 = 50
  }
  
  export enum ProfessionalLevel {
    Beginner,
    Experienced
  }
  
  export enum ManagementLevel {
    None = 0,
    Level1 = 1,
    Level2 = 2,
    Level3 = 3,
    Level4 = 4
  }
  
  export enum AdditionGroup {
    GroupA,
    GroupB
  }
  
  export interface EmployeeDetails {
    employmentPercentage: EmploymentPercentage;
    professionalLevel: ProfessionalLevel;
    managementLevel: ManagementLevel;
    yearsOfExperience: number;
    isEligibleForAddition: boolean;
    additionGroup?: AdditionGroup;
  }
  
  export interface EmployeeSalaryDetails {
    basicSalary: number;
    seniorityBonus: number;
    seniorityBonusPercentage: number;
    lawAddition: number;
    totalBaseSalary: number;
    salaryIncreasePercentage: number;
    salaryIncrease: number;
    newBaseSalary: number;
  }
  
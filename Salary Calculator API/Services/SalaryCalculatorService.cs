using Salary_Calculator_API.Models;

namespace SalaryCalculatorAPI.Services
{
    public class SalaryCalculatorService
    {

        public async Task<EmployeeSalaryDetails> CalculateSalaryAsync(EmployeeDetails employeeDetails)
        {
            // כאן יבוצעו החישובים השונים על פי הדרישות של המטלה
            var baseSalary = CalculateBaseSalary(employeeDetails);
            var seniorityBonus = CalculateSeniorityBonus(employeeDetails);
            var seniorityBonusPercentage = GetSeniorityBonusPercentage(seniorityBonus, baseSalary);
            var lawAddition = CalculateLawAddition(employeeDetails);
            var totalBaseSalary = baseSalary + seniorityBonus + lawAddition;
            var salaryIncrease = CalculateSalaryIncrease(totalBaseSalary, employeeDetails.ManagementLevel);
            
            // יצירת אובייקט מסוג EmployeeSalaryDetails והחזרתו כתוצאה
            var result = new EmployeeSalaryDetails
            {
                BasicSalary = baseSalary,
                SeniorityBonus = seniorityBonus,
                seniorityBonusPercentage = seniorityBonusPercentage,
                LawAddition = lawAddition,
                TotalBaseSalary = totalBaseSalary,
                SalaryIncrease = salaryIncrease,
                SalaryIncreasePercentage = GetSalaryIncreasePercentage(salaryIncrease, totalBaseSalary),
                NewBaseSalary = totalBaseSalary + salaryIncrease
            };

            return result;
        }

        // פונקציה לחישוב שכר היסוד
        private decimal CalculateBaseSalary(EmployeeDetails employeeDetails)
        {
            decimal baseSalary = 0;

            // חישוב שעות העבודה החודשיות של העובד בהתאם לחלקיות המשרה
            decimal workHours = (decimal)(170 * ((int)employeeDetails.EmploymentPercentage * 0.01));

            //חישוב תוספת לשכר לפי רמת מקצועיות
            if (employeeDetails.ProfessionalLevel == ProfessionalLevel.Beginner)
                baseSalary = workHours * 100;
            else
                baseSalary = workHours * 120;

            //חישוב תוספת לשכר לפי דרגת ניהול
            baseSalary += workHours * (((int)employeeDetails.ManagementLevel) * 20); 
            

            return baseSalary;
        }

        // חישוב תוספת וותק לשכר בהתאם לשנות הותק של העובד
        private decimal CalculateSeniorityBonus(EmployeeDetails employeeDetails)
        {
            decimal seniorityBonus = employeeDetails.YearsOfExperience * 0.0125m * CalculateBaseSalary(employeeDetails);
            return seniorityBonus;
        }
        //חישוב שיעור בונוס הוותק מתוך שכר היסוד
        private decimal GetSeniorityBonusPercentage(decimal seniorityBonus, decimal baseSalary)
        {
            decimal seniorityBonusPercentage = 0;

            seniorityBonusPercentage = (seniorityBonus / baseSalary) * 100;

            return seniorityBonusPercentage;
        }
        // חישוב תוספת עבודה בהתאם להכנסת העובד בחוק
        private decimal CalculateLawAddition(EmployeeDetails employeeDetails)
        {
            decimal addition = 0;

            if (employeeDetails.IsEligibleForAddition)
            {
                if (employeeDetails.AdditionGroup == AdditionGroup.GroupA)
                {
                    addition = 0.01m * CalculateBaseSalary(employeeDetails);
                }
                else if (employeeDetails.AdditionGroup == AdditionGroup.GroupB)
                {
                    addition = 0.005m * CalculateBaseSalary(employeeDetails);
                }
            }

            return addition;
        }

        // חישוב תוספת העלאת שכר בהתאם לגובה שכר הבסיס
        private decimal CalculateSalaryIncrease(decimal totalBaseSalary, ManagementLevel ManagementLevel)
        {
            decimal salaryIncrease = 0;

            if (totalBaseSalary <= 20000)
            {
                salaryIncrease = totalBaseSalary * 0.015m;
            }
            else if (totalBaseSalary <= 30000)
            {
                salaryIncrease = totalBaseSalary * 0.0125m;
            }
            else
            {
                salaryIncrease = totalBaseSalary * 0.01m;
            }
            // חישוב תוספת העלאת שכר בהתאם לדרגת הניהול
            salaryIncrease += totalBaseSalary * (int)ManagementLevel * 0.001m ;


            return salaryIncrease;
        }

        // חישוב שיעור העלאת השכר באחוזים מתוך שכר הבסיס
        private decimal GetSalaryIncreasePercentage(decimal salaryIncrease, decimal totalBaseSalary)
        {
            decimal salaryIncreasePercentage = 0;

            salaryIncreasePercentage = (salaryIncrease / totalBaseSalary) * 100;

            return salaryIncreasePercentage;
        }


    }
}


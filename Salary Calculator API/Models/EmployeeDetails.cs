namespace Salary_Calculator_API.Models
{
    public class EmployeeDetails
    {
        public EmploymentPercentage EmploymentPercentage { get; set; }
        public ProfessionalLevel ProfessionalLevel { get; set; }
        public ManagementLevel ManagementLevel { get; set; }
        public int YearsOfExperience { get; set; }
        public bool IsEligibleForAddition { get; set; }
        public AdditionGroup AdditionGroup { get; set; }
    }

}

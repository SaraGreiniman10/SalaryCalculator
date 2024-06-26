using Microsoft.AspNetCore.Mvc;
using Salary_Calculator_API.Models;
using SalaryCalculatorAPI.Services;

namespace SalaryCalculatorAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SalaryController : ControllerBase
    {

        private readonly SalaryCalculatorService _salaryCalculatorService;

        public SalaryController(SalaryCalculatorService salaryCalculatorService)
        {
            _salaryCalculatorService = salaryCalculatorService;
        }



        [HttpPost("CalculateSalary")]
        public async Task<IActionResult> CalculateSalary([FromBody] EmployeeDetails details)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
               
                // קריאה לסרוויס לחישוב השכר של העובד עם הפרטים שהתקבלו מהלקוח
                var result = await _salaryCalculatorService.CalculateSalaryAsync(details);

                // החזרת פרטי שכר העובד לאחר החישוב
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred while calculating salary: {ex.Message}");
                return StatusCode(500, "An error occurred while calculating salary");
            }
        }

    }

}
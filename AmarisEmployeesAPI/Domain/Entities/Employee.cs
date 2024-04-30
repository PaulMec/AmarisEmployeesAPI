using Newtonsoft.Json;
using System.Collections.Generic;

namespace AmarisEmployeesAPI.Domain.Entities
{
    public class Employee
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("employee_name")]
        public string EmployeeName { get; set; }

        [JsonProperty("employee_salary")]
        public decimal EmployeeSalary { get; set; }

        [JsonProperty("employee_age")]
        public int EmployeeAge { get; set; }

        [JsonProperty("profile_image")]
        public string ProfileImage { get; set; }


        [JsonProperty("employee_email")]
        public string EmployeeEmail { get; set; }
    }
}

using AmarisEmployeesAPI.Domain.Entities;

namespace AmarisEmployeesAPI.BL.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> CalculateAnnualSalaryAsync(int id);
    }
}

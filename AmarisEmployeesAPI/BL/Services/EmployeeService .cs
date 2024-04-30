using AmarisEmployeesAPI.BL.Interfaces;
using AmarisEmployeesAPI.DAL.Interfaces;
using AmarisEmployeesAPI.Domain.Entities;

namespace AmarisEmployeesAPI.BL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Recupera todos los empleados disponibles en el repositorio.
        /// </summary>
        /// <returns>Una colección de empleados como una tarea asíncrona.</returns>
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        /// <summary>
        /// Busca un empleado por su ID.
        /// </summary>
        /// <param name="id">El ID del empleado a buscar.</param>
        /// <returns>El empleado encontrado como una tarea asíncrona, o null si no se encuentra ningún empleado con ese ID.</returns>
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        /// <summary>
        /// Calcula el salario anual de un empleado específico multiplicando su salario mensual por 12.
        /// </summary>
        /// <param name="id">El ID del empleado para calcular su salario anual.</param>
        /// <returns>El empleado con el salario anual actualizado como una tarea asíncrona, o null si el empleado no se encuentra.</returns>
        public async Task<Employee> CalculateAnnualSalaryAsync(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee != null)
            {
                employee.EmployeeSalary *= 12;
            }
            return employee;
        }
    }
}

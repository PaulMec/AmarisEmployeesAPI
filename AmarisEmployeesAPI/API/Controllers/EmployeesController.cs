using AmarisEmployeesAPI.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmarisEmployeesAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Obtiene todos los empleados disponibles en el sistema.
        /// </summary>
        /// <returns>Una acción de IActionResult que contiene la lista de todos los empleados.</returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        /// <summary>
        /// Obtiene la información de un empleado específico por su ID.
        /// </summary>
        /// <param name="id">El ID del empleado a buscar.</param>
        /// <returns>Una acción de IActionResult que contiene la información del empleado o un estado NotFound si no se encuentra.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }
            return Ok(employee);
        }

        /// <summary>
        /// Calcula el salario anual de un empleado específico basado en su salario mensual.
        /// </summary>
        /// <param name="id">El ID del empleado para el cual calcular el salario anual.</param>
        /// <returns>Una acción de IActionResult que contiene el salario anual calculado o un estado NotFound si el empleado no se encuentra.</returns>
        [HttpGet("calculate-salary/{id}")]
        public async Task<IActionResult> CalculateAnnualSalary(int id)
        {
            var employee = await _employeeService.CalculateAnnualSalaryAsync(id);
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }
            return Ok(employee);
        }
    }
}

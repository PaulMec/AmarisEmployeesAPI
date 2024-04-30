using AmarisEmployeesAPI.DAL.Interfaces;
using AmarisEmployeesAPI.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AmarisEmployeesAPI.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Recupera todos los empleados disponibles haciendo una solicitud GET a la API configurada.
        /// </summary>
        /// <returns>Una tarea asíncrona que devuelve una colección de empleados.</returns>
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var baseUrl = _configuration["EmployeeApi:BaseUrl"];
                    var url = $"{baseUrl}/employees";
                    Console.WriteLine($"Requesting URL: {url}");

                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var employees = JsonConvert.DeserializeObject<List<Employee>>(jsonResponse);

                    return employees;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred while fetching employees: {ex.Message}");
                return new List<Employee>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Recupera un empleado específico por su ID haciendo una solicitud GET a la API configurada.
        /// </summary>
        /// <param name="id">El ID del empleado a buscar.</param>
        /// <returns>Una tarea asíncrona que devuelve un objeto Employee, o un nuevo objeto Employee si no se encuentra.</returns>
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var baseUrl = _configuration["EmployeeApi:BaseUrl"];
                    var url = $"{baseUrl}/employees/{id}";
                    Console.WriteLine($"Requesting URL: {url}");

                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var employee = JsonConvert.DeserializeObject<Employee>(jsonResponse);

                    return employee ?? new Employee();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred while fetching employee {id}: {ex.Message}");
                return new Employee();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Agrega un nuevo empleado a la base de datos haciendo una solicitud POST a la API configurada.
        /// </summary>
        /// <param name="employee">El empleado a agregar.</param>
        /// <returns>Una tarea asíncrona que no devuelve ningún valor.</returns>
        public async Task AddEmployeeAsync(Employee employee)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var baseUrl = _configuration["EmployeeApi:BaseUrl"];
                    var url = $"{baseUrl}/employees";
                    Console.WriteLine($"Posting to URL: {url}");

                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, employee);
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred while adding employee: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Actualiza la información de un empleado existente haciendo una solicitud PUT a la API configurada.
        /// </summary>
        /// <param name="employee">El empleado a actualizar.</param>
        /// <returns>Una tarea asíncrona que no devuelve ningún valor.</returns>
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var baseUrl = _configuration["EmployeeApi:BaseUrl"];
                    var url = $"{baseUrl}/employees/{employee.Id}";
                    Console.WriteLine($"Updating URL: {url}");

                    HttpResponseMessage response = await httpClient.PutAsJsonAsync(url, employee);
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred while updating employee {employee.Id}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Elimina un empleado específico por su ID haciendo una solicitud DELETE a la API configurada.
        /// </summary>
        /// <param name="id">El ID del empleado a eliminar.</param>
        /// <returns>Una tarea asíncrona que no devuelve ningún valor.</returns>
        public async Task DeleteEmployeeAsync(int id)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var baseUrl = _configuration["EmployeeApi:BaseUrl"];
                    var url = $"{baseUrl}/employees/{id}";
                    Console.WriteLine($"Deleting at URL: {url}");

                    HttpResponseMessage response = await httpClient.DeleteAsync(url);
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred while deleting employee {id}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }

    }
}

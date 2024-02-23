using EmployeeManagement.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            HttpResponseMessage response2 = await httpClient.PostAsJsonAsync<Employee>("api/employees", newEmployee);
            var result2 = await response2.Content.ReadAsStringAsync();
            Employee createEmployee2 = JsonConvert.DeserializeObject<Employee>(result2);
            return createEmployee2;
        }

        public async Task DeleteEmployee(int id)
        {
            await httpClient.DeleteAsync($"api/employees/{id}");
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        }

        /*
        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            return await httpClient.PutAsJsonAsync<Employee>("api/employees", updatedEmployee);
        }
        */

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            HttpResponseMessage response = await httpClient.PutAsJsonAsync<Employee>("api/employees", updatedEmployee);
            Employee updatedEmployee2 = await response.Content.ReadAsAsync<Employee>();
            return updatedEmployee2;
        }
    }
}

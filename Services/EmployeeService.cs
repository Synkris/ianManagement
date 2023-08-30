using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ianManagement.Models;
using Newtonsoft.Json;

namespace ianManagement.Services
{
    //public interface IEmployeeService
    //{
    //    Task<List<Employee>> GetAllEmployeesAsync();
    //    Task<Employee> CreateEmployeeAsync(Employee employee);
    //}
    public class EmployeeService
    {
        private readonly string baseUrl = "https://gorest.co.in/public/v2/";
        private readonly string accessToken = "0bf7fb56e6a27cbcadc402fc2fce8e3aa9ac2b40d4190698eb4e8df9284e2023"; // Replace with your access token

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage response = await client.GetAsync(baseUrl + "users");
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<Employee>>(responseBody);
                    //var result = JsonConvert.DeserializeObject<EmployeeResponse>(responseBody);
                    return result;
                }
                return null;
            }
            return new List<Employee>();
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var json = JsonConvert.SerializeObject(employee);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(baseUrl + "users", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Employee>(responseBody);
                }
                return null;
            }
        }
    }
}

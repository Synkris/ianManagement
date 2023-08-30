using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ianManagement.Models
{
    public class EmployeeResponse
    {
        public int Code { get; set; }
        public Meta Meta { get; set; }
        public List<Employee> Data { get; set; }
    }

    public class Meta
    {
        public Pagination Pagination { get; set; }
    }

    public class Pagination
    {
        public int Total { get; set; }
        public int Pages { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public Link Links { get; set; }
    }

    public class Link
    {
        public string Previous { get; set; }
        public string Current { get; set; }
        public string Next { get; set; }
    }
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public DateTime DOB { get; set; }
        public int EmployeeAge { get; set; }
        public DateTime DateHired { get; set; }
        public string Department { get; set; }
        public string Job { get; set; }
        public string Gender { get; internal set; }
        public string Salary { get; internal set; }
    }
}

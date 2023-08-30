using ianManagement.Models;
using ianManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ianManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EmployeeService employeeService = new EmployeeService();

        public MainWindow()
        {
            InitializeComponent();
        }
        private async void View_Click(object sender, RoutedEventArgs e)
        {
            List<Employee> employees = await employeeService.GetAllEmployeesAsync();
            EmployeeDataGrid.ItemsSource = employees;
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            Employee newEmployee = new Employee
            {
                Name = Name.Text,
                Address = Address.Text,
                Email = Email.Text,
                Phone = PhoneNumber.Text,
                DOB = Convert.ToDateTime(DOB.SelectedDate),
                EmployeeAge = Convert.ToInt32(Age.Text),
                Country = Country.Text,
                State = State.Text,
                DateHired = Convert.ToDateTime(HireDate.SelectedDate),
                Department = Department.Text,
                Region = Religion.Text,
                Job = Job.Text,
                Gender = Gender.Text,
                Salary = Salary.Text,

            };

            Employee addedEmployee = await employeeService.CreateEmployeeAsync(newEmployee);
            if (addedEmployee != null)
            {
                MessageBox.Show("Employee added successfully.");
            }
            else
            {
                MessageBox.Show("Failed to add employee.");
            }
        }
    }
}

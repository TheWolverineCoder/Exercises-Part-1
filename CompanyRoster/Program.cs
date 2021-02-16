using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments= new List<Department>();
            Console.WriteLine("Enter the number of employees you want to enter: ");
            int numberOfEmployees = int.Parse(Console.ReadLine());
            for(int i = 0; i < numberOfEmployees; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                if(!departments.Any(d => d.DepartmentName == input[2]))
                {
                    departments.Add(new Department(input[2]));
                }

                departments.Find(d => d.DepartmentName == input[2]).AddNewEmployee(input[0], decimal.Parse(input[1]));
            }

            Department bestDepartment = departments.OrderByDescending(d => d.TotalSalaries / d.Employees.Count()).First();

            Console.WriteLine("Highest average salary: " + bestDepartment.DepartmentName);
            foreach(var employee in bestDepartment.Employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine(employee.Name + " {0:F2}",employee.Salary);
            }

            
        }
    }

    class Employee
    {
        public Employee(string name,decimal salary)
        {
            Name = name;
            Salary = salary;
        }
        public string Name { get; set; }
        public decimal Salary { get; set; }

    }

    class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public decimal TotalSalaries { get; set; }

        public void AddNewEmployee(string empName,decimal empSalary)
        {
            this.TotalSalaries += empSalary;
            this.Employees.Add(new Employee(empName, empSalary));
        }

        public Department(string departmentName)
        {
            this.DepartmentName = departmentName;
        }

    }
}

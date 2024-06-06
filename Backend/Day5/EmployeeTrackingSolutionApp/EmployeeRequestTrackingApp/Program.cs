﻿using EmployeeRequestTrackingAppModelLibrary;
namespace EmployeeRequestTrackingApp
{
    internal class Program
    {
        Employee[] employees;
        public Program()
        {
            employees = new Employee[3];
        }
        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Update the Employee Name by ID");
            Console.WriteLine("5. Delete the Employee by ID");
            Console.WriteLine("0. Exit");
        }
        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        SearchAndPrintEmployee();
                        break;
                    case 4:
                        UpdateNameOfEmployee();
                        break;
                    case 5:
                        DeleteEmployeeByID();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        void AddEmployee()
        {
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                }
            }

        }

        void PrintAllEmployees()
        {
            if (employees[0] == null)
            {
                Console.WriteLine("No Employees available");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                    PrintEmployee(employees[i]);
            }
        }
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }

        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }
        int GetIdFromConsole()
        {
            int id = 0;
            Console.WriteLine("Please enter the employee Id");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            return id;
        }
        void SearchAndPrintEmployee()
        {
            Console.WriteLine("Print One employee");
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            PrintEmployee(employee);
        }
        Employee SearchEmployeeById(int id)
        {
            Employee employee = null;
            for (int i = 0; i < employees.Length; i++)
            {

                if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }
        String GetUpdatedNameFromConsole(int i)
        {
            Console.WriteLine("Please enter the updated name for the employee ID :" + i);
            String name = Console.ReadLine();
            return name;
        }

        void UpdateNameOfEmployee()
        {
            int ID=GetIdFromConsole();
            Employee employee = SearchEmployeeById(ID);
            if (employee == null)
            {
                Console.WriteLine("No Employee Found !");
                return;
            }
            String updatedName = GetUpdatedNameFromConsole(ID);
            if (updatedName != String.Empty)
            {
                employee.Name = updatedName;
            }
            Console.WriteLine("update Employee Details");
            PrintEmployee(employee);

        }

        void DeleteEmployeeByID()
        {
            int ID = GetIdFromConsole();
            Employee employee = SearchEmployeeById(ID);
            
            if (employee == null)
            {
                Console.WriteLine("Employee not found !");
            }

            else
            {
                Console.WriteLine("The Below Employee was deleted");
                PrintEmployee(employee);
                employees[((employee.Id) % 10)-1] = null;
                Console.WriteLine("Employee Deleted Successfully and the below is the list of Employees after deletion !");
                PrintAllEmployees();
            }

        }

        static void Main(string[] args)
        {
            Program program = new Program();
            
            program.EmployeeInteraction();
        }
    }
}
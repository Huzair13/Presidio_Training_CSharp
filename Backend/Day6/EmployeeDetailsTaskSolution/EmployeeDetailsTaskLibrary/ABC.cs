using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetailsTaskLibrary
{
    public class ABC : IGovRules
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; } = string.Empty;
        public string Department { get; set; }
        public string Designation { get; set; }
        public double Salary { get; set; }

        public ABC(int empID, string empName, string department, string designation, double salary)
        {
            EmpID = empID;
            EmpName = empName;
            Department = department;
            Designation = designation;
            Salary = salary;

        }

        //ABC Company PF Amount Calculation
        public double EmployeePF(double basicSalary)
        {
            double empPF = basicSalary * 0.0367;
            return empPF;
        }

        //ABC Company Gratuity Amount Calculation
        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            if (serviceCompleted > 20)
                return 3 * basicSalary;
            else if (serviceCompleted > 10)
                return 2 * basicSalary;
            else if (serviceCompleted > 5)
                return basicSalary;
            else
                return 0;
        }

        //ABC Company Leave Details
        public string LeaveDetails()
        {
            return "Leave Details for ABC:\n" +
                "1 day of Casual Leave per month\n" +
                "12 days of Sick Leave per year\n" +
                "10 days of Privilege Leave per year";
        }

        //printABCCompanyDetails
        public void printABCEmployeeDetails()
        {
            Console.WriteLine("Please enter the service years");
            float serviceYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

            Console.WriteLine("Employee ID : " + EmpID);
            Console.WriteLine("Employee Name : " + EmpName);
            Console.WriteLine("Employee Department " + Department);
            Console.WriteLine("Employee Designation : " + Designation);
            Console.WriteLine("Employee Basic Salary : " + Salary);

            double PFAmount = EmployeePF(Salary);
            Console.WriteLine("Employee PF Contribution : " + PFAmount);

            Console.WriteLine("Employee salary after PF :" + (Salary - PFAmount));

            string leaveDetails = LeaveDetails();
            Console.WriteLine(leaveDetails);
            double gratuity = GratuityAmount(serviceYear, Salary);
            Console.WriteLine("Employee Gratuity  " + gratuity);

        }

    }
}

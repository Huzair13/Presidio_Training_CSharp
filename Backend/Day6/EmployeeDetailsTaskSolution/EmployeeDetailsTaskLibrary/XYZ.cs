using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeDetailsTaskLibrary
{
    public class XYZ : IGovRules
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; } = string.Empty;
        public string Department { get; set; }
        public string Designation { get; set; }
        public double Salary { get; set; }

        public XYZ(int empID, string empName, string department, string designation, double salary)
        {
            EmpID = empID;
            EmpName = empName;
            Department = department;
            Designation = designation;
            Salary = salary;

        }

        public double EmployeePF(double basicSalary)
        {
            //12 % given by the employer from the total 12 percentage
            int empPF = 0;
            return empPF;
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            //GratuityAmount amout is not applicable
            return 0;
        }

        public string LeaveDetails()
        {
            return "Leave Details for XYZ: \n" +
                "2 days of Casual Leave per month\n" +
                "5 days of Sick Leave per year\n" +
                "5 days of Privilege Leave per year";
        }

        //printXYZEmployeeDetails
        public void printXYZEmployeeDetails()
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
            Console.WriteLine("Employee PF from basic salary : " + PFAmount);

            Console.WriteLine("Employee PF Contribution : " + (Salary - PFAmount));

            string leaveDetails = LeaveDetails();
            Console.WriteLine(leaveDetails);

            double gratuity = GratuityAmount(serviceYear,Salary);
            Console.WriteLine("Employee Gratuity  " + gratuity);
            Console.WriteLine("Gratuity is not applicable for XYZ Company");

        }
    }
}

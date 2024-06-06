using EmployeeDetailsTaskLibrary;
internal class Program
{

    int empID;
    string empName;
    string department;
    string designation;
    double salary;

    public Program()
    {
        empID= 0;
        empName= string.Empty;
        department= string.Empty;
        designation= string.Empty;
        salary= 0;
    }
    void PrintMenu()
    {
        Console.WriteLine("1. ABC Company");
        Console.WriteLine("2. XYZ Company");
        Console.WriteLine("0. Exit");
    }

    void CompanyChoice()
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
                    ABCCompany();
                    break;
                case 2:
                    XYZCompany();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again");
                    break;
            }
        } while (choice != 0);
    }

    private void XYZCompany()
    {
        getEmployeeDetails();
        XYZ company = new XYZ(empID,empName,department,designation,salary);
        company.printXYZEmployeeDetails();
        Console.WriteLine("\n");
    }

    private void ABCCompany()
    {
        getEmployeeDetails();
        ABC company = new ABC(empID, empName, department, designation, salary);
        company.printABCEmployeeDetails();
        Console.WriteLine("\n");
    }

    private void getEmployeeDetails()
    {
        Console.WriteLine("Please Employee ID :");
        empID = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please Employee Name :");
        empName = Console.ReadLine();
        Console.WriteLine("Please Enter the Department :");
        department = Console.ReadLine();
        Console.WriteLine("Please Enter the Designation :");
        designation = Console.ReadLine();
        Console.WriteLine("Please Enter Your Basic Salary :");
        salary = Convert.ToDouble(Console.ReadLine());
    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        program.CompanyChoice();
    }
}
using RequestTrackerBL;
using RequestTrackerLibrary;
using RequestTrackerModelLibrary;


namespace RequestTrackerApp
{
    public class Program
    {
        public static Employee loggedInEmployee;

        //LOGIN
        async Task EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password, Id = username };
            IEmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
            var result = await employeeLoginBL.Login(employee);
            var loggedUserDetails = await employeeLoginBL.getUserDetails(username);

            if (result)
            {
                loggedInEmployee = loggedUserDetails;
                await Console.Out.WriteLineAsync("Login Success");
                await LoginBasedOnRoles();
            }
            else
            {
                await Console.Out.WriteLineAsync("Invalid username or password");
            }
        }

        //GET LOGIN DETAILS
        async Task GetLoginDeatils()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            await EmployeeLoginAsync(id, password);
        }

        //GET REGISTER DETAILS
        async Task GetRegisterDetails()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Name");
            string name = Console.ReadLine();
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            string role = "User";

            await EmployeeRegisterAsync(name, password, role);
        }


        //RESGISTER
        async Task EmployeeRegisterAsync(string name, string password, string role)
        {
            Employee newEmployee = new Employee { Name = name, Password = password, Role = role };
            EmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();

            var result = await employeeLoginBL.Register(newEmployee);
            if (result != null)
            {
                Console.WriteLine($"Register Successful and Your Employee ID is {result.Id}");
            }
        }


        //LOGIN BASED ON ROLES

        public async Task LoginBasedOnRoles()
        {
            IFrontend frontend;
            if (loggedInEmployee != null)
            {
                if (loggedInEmployee.Role == "Admin")
                {
                    frontend = new AdminFrontend(loggedInEmployee);
                }
                else
                {
                    frontend = new UserFrontend(loggedInEmployee);
                }
            }
            else
            {
                frontend = new UserFrontend(loggedInEmployee);
            }

            await frontend.DisplayMenu();
        }

        //UNREGISTER
        async Task UnRegister()
        {
            await Console.Out.WriteAsync("Enter the UserID to UnRegister : ");
            int userId = Convert.ToInt32(Console.ReadLine());

            EmployeeLoginBL employeeLoginBL= new EmployeeLoginBL();

            var results= await employeeLoginBL.Unregister(userId);

            if (results != null)
            {
                await Console.Out.WriteAsync($"user {userId} UnRegistered successfully ");
            }
            else
            {
                await Console.Out.WriteAsync($"user {userId} not exists or already unRegistered");
            }
            
        }



        static async Task Main(string[] args)
        {

            // Menu loop
            bool exit = false;
            while (!exit)
            {
                await Console.Out.WriteLineAsync("Login Menu:");
                await Console.Out.WriteLineAsync("1. Login");
                await Console.Out.WriteLineAsync("2. Register");
                await Console.Out.WriteLineAsync("3. UnRegister");
                await Console.Out.WriteLineAsync("4. Exit");
                await Console.Out.WriteAsync("Enter your choice (1-4): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await new Program().GetLoginDeatils();                
                        break;
                    case "2":
                        await new Program().GetRegisterDetails();
                        break;
                    case "3":
                        await new Program().UnRegister();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        await Console.Out.WriteLineAsync("Invalid choice. Please enter a number between 1 and 4");
                        break;
                }
            }
        }
    }
}

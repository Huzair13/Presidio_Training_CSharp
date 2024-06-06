namespace UnderstandingBasicsApp.Models
{
    class LoginUsers
    {
        public void login()
        {
            string username = "ABC";
            string password = "123";
            int attempts = 0;

            while (attempts < 3)
            {
                Console.WriteLine("Enter username:");
                string inputUsername = Console.ReadLine();

                Console.WriteLine("Enter password:");
                string inputPassword = Console.ReadLine();

                if (inputUsername == username && inputPassword == password)
                {
                    Console.WriteLine("Login successful!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                    attempts++;
                }
            }

            if (attempts == 3)
            {
                Console.WriteLine("You have exceeded the number of attempts. Login failed.");
            }
        }

    }

}


namespace UnderstandingBasicsApp.Models
{
    class GreaterOfAllNumbers
    {
        public void findGreaterNumber()
        {
            double greatestNumber = double.MinValue;

            while (true)
            {
                Console.WriteLine("Enter a number or enter a negative number to exit:");
                double number;
                while (!double.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Invalid entry. Please try again.");
                }

                if (number < 0)
                {
                    break;
                }

                if (number > greatestNumber)
                {
                    greatestNumber = number;
                }
            }

            Console.WriteLine($"The greatest number entered is: {greatestNumber}");
        }

    }

}


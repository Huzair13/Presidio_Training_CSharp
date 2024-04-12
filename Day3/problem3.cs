namespace UnderstandingBasicsApp.Models
{
    class AverageDivisibleBySeven
    {
        public void FindAverage()
        {
            int count = 0;
            double sum = 0;

            while (true)
            {
                Console.WriteLine("Enter a number or enter a negative number to exit:");
                double number = Convert.ToDouble(Console.ReadLine());

                if (number < 0)
                {
                    break;
                }

                if (number % 7 == 0)
                {
                    sum += number;
                    count++;
                }
            }

            if (count > 0)
            {
                double average = sum / count;
                Console.WriteLine($"The average of numbers divisible by 7 entered is: {average}");
            }
            else
            {
                Console.WriteLine("No numbers divisible by 7 entered.");
            }
        }

    }

}


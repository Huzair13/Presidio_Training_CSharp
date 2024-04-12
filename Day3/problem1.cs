namespace UnderstandingBasicsApp.Models
{
    class SimpleCalculation
    {
        public void calculate()
        {
            Console.WriteLine("Enter the first number:");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            double num2 = Convert.ToDouble(Console.ReadLine());

            //sum, product, division, subtraction, Remainder
            Console.WriteLine($"Sum: {num1 + num2}");
            Console.WriteLine($"Product: {num1 * num2}");
            Console.WriteLine($"Division: {num1 / num2}");
            Console.WriteLine($"Subtraction: {num1 - num2}");

            Console.WriteLine($"Remainder: {FindRemainder(num1, num2)}");
        }
        public double FindRemainder(double num1, double num2)
        {
            return num1 % num2;
        }

    }

}


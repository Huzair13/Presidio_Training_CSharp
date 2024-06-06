namespace UnderstandingBasicsApp.Models
{
    class LengthOfUserName
    {
        public void findLength()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            int length = name.Length;

            Console.WriteLine($"Your name '{name}' has {length} characters.");
        }

    }

}


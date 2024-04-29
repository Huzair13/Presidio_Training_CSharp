namespace ExcelSheetColumnTitle
{
    public class Program
    {
        static async Task<string> GetExcelColumnName(int columnNumber)
        {
            int baseValue = 'A' - 0;
            string columnName = "";

            while (columnNumber > 0)
            {
                int remainder = (columnNumber - 1) % 26;
                columnName = (char)(baseValue + remainder) + columnName;
                columnNumber = (columnNumber - 1) / 26;
            }

            return columnName;
        }
        static async Task Main()
        {
            //int columnNumber = 2147483647;
            //int columnNumber = 701;
            //int columnNumber = 25;

            string columnNumberString = Console.ReadLine();
            int columnNumber;
            if (!int.TryParse(columnNumberString, out columnNumber))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

            string columnName = GetExcelColumnName(columnNumber).Result;
            Console.WriteLine($"Column Name for Column Number {columnNumber} is {columnName}");
        }
    }
}

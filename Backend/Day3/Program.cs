using System.Numerics;
using UnderstandingBasicsApp.Models;

namespace UnderstandingBasicsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem 1 to sum, sub, divide , multiply and remainder finding
            SimpleCalculation simpleCalculation = new SimpleCalculation();
            simpleCalculation.calculate();

            //problem 2 to find the greater numbr of all
            GreaterOfAllNumbers greaterOfAllNumbers= new GreaterOfAllNumbers();
            greaterOfAllNumbers.findGreaterNumber();   

            //problem 3 to find average divisible by 7
            AverageDivisibleBySeven averageDivisibleBySeven =new AverageDivisibleBySeven();
            averageDivisibleBySeven.FindAverage();
            
            //problem 4 to find the length of the user name
            LengthOfUserName lengthOfUserName = new LengthOfUserName();
            lengthOfUserName.findLength();

            //problem 5 to login user based on username and password
            LoginUsers loginUsers = new LoginUsers();
            loginUsers.login();

            //problem 6 to find the repeating vowels
            RepeatingVowel repeatingVowel=new RepeatingVowel();
            repeatingVowel.findRepeatVowels();
        }
    }
}
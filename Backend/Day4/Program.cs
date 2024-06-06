using System.Numerics;
using UnderstandingBasicsApp.Models;

namespace UnderstandingBasicsApp
{
    class Program
    {

        Doctor CreateDoctorsByTakingInputFromConsole(int id,int n)
        {
            //1)create a doctor class with details ID, Name, Age, Exp, Qualification, Speciality
            Doctor doctor = new Doctor(id);

            //Read Name from console
            Console.WriteLine($"Please enter the {n+1} Doctor name");
            doctor.Name = Console.ReadLine();

            //Read age from console
            Console.WriteLine("Please enter the Doctor Age");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            doctor.Age = age;

            //Read experience from console
            Console.WriteLine("Please enter the Doctor Experience");
            int exp;
            while (!int.TryParse(Console.ReadLine(), out exp))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            doctor.Exp = exp;

            //Read qualification from console
            Console.WriteLine("Please enter the Doctor Qualification");
            doctor.Qualification = Console.ReadLine();

            //Read speciality from console
            Console.WriteLine("Please enter the Doctor Speciality");
            doctor.Speciality = Console.ReadLine();

            return doctor;
        }
        static void Main(string[] args)
        {

            //2)create an array
            Program program = new Program();
            Doctor[] doctors = new Doctor[3];
            for (int i = 0; i < doctors.Length; i++)
            {

                doctors[i] = program.CreateDoctorsByTakingInputFromConsole(301 + i,i);
            }

            //3)print the array
            for (int i = 0; i < doctors.Length; i++)
            {
                doctors[i].PrintDoctorDetails();
            }

            //4)given a speciality print the doctor details
            Console.WriteLine("Please Give the speciality to print the doctor details");
            string specialityInputFromConsole= Console.ReadLine();

            for(int i = 0; i < doctors.Length; i++)
            {
               if (doctors[i].Speciality == specialityInputFromConsole)
              {
                 doctors[i].PrintDoctorDetails();
             }
            }

            //5)CardNumber Problem
            //Enter the 16 digit Card Number
            Console.WriteLine("Please enter the 16 digit card numbers");
            long cardNumber;
            while (!long.TryParse(Console.ReadLine(), out cardNumber))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }

            CardProblem cardProblem = new CardProblem();
            Console.WriteLine(cardProblem.IsValid(cardNumber));

        }
    }
}
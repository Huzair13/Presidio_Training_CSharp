using Microsoft.EntityFrameworkCore;
using SampleEFApp.Model;

namespace SampleEFApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Data Source = DESKTOP - 92EC60F\\SQLEXPRESS; Integrated Security = true; Initial Catalog = dbEmployeeTracker

            //Scaffold - DbContext "Data Source=DESKTOP-92EC60F\\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbEmployeeTracker" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Model

            //Area area = new Area();
            //area.Area1 = "POPO";
            //area.Zipcode = "44332";
            dbEmployeeTrackerContext context = new dbEmployeeTrackerContext();
            //context.Areas.Add(area);
            //context.SaveChanges();

            //var areas = context.Areas.ToList();
            //foreach (var area in areas)
            //{
            //    Console.WriteLine(area.Area1 + " " + area.Zipcode);
            //}

            var areas = context.Areas.ToList();
            var area = areas.SingleOrDefault(a => a.Area1 == "DDDD");
            area.Zipcode = "00000";
            context.Areas.Update(area);
            context.SaveChanges();

            area = areas.SingleOrDefault(a => a.Area1 == "HHHH");
            context.Areas.Remove(area);
            context.SaveChanges();
            foreach (var a in areas)
            {
                Console.WriteLine(a.Area1 + " " + a.Zipcode);
            }

        }
    }

}

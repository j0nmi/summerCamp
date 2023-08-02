using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
   class Program
   {
      static void Main(string[] args)
      {
         Employee emp = new Employee(5, 101);
         Console.WriteLine($"emp years of service: {emp.YearsOfService}");
         Console.WriteLine($"emp office: {emp.Office}");

         Employee emp2 = new Employee();
         emp2.YearsOfService = 15;
         emp2.Office = 201;
         Console.WriteLine($"emp2 years of service: {emp2.YearsOfService}");
         Console.WriteLine($"emp2 office: {emp2.Office}");

         Employee emp3 = new Employee()
         {
            YearsOfService = 20,
            Office = 301
         };
         Console.WriteLine($"emp3 years of service: {emp3.YearsOfService}");
         Console.WriteLine($"emp3 office: {emp3.Office}");



      }
   }

}

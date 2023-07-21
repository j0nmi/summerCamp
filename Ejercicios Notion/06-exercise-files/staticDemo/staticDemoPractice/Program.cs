using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staticDemoPractice
{
   public class Program
   {
      static void Main(string[] args)
      {
         string selection = String.Empty;

         while (selection != "q" && selection != "Q")
         {
            Console.Write("Enter C)elsius to Fahrenheit or F)arenheit to Celsius or Q)uit:");

            selection = Console.ReadLine();
            double farenheit, celsius = 0;

            switch (selection)
            {
               case "C":
               case "c":
                  Console.Write("Please enter the Celsius temperature: ");
                  farenheit = TemperatureConverter.CelsiusToFahrenheit(Console.ReadLine());
                  Console.WriteLine($"Temperature in Fahrenheit: {farenheit:f2}");
                  break;

               case "F":
               case "f":
                  Console.Write("Please enter the Fahrenheit temperature: ");
                  celsius = TemperatureConverter.FahrenheitToCelsius(Console.ReadLine());
                  Console.WriteLine($"Temperature in Celsius: {celsius:f2}");
                  break;

               case "q":
               case "Q":
                  break;

               default:
                  Console.WriteLine("Please try again.");
                  break;
            }
         }

      }






   }
}

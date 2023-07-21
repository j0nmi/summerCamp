using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      int myAge = 21;  //That's a lie
      int x = 5;
      double myHourlyRate = 150.00;
      var myName = "Jesse Liberty";

      Console.WriteLine($"myAge: {myAge}, x: {x}, myHourlyRate: {myHourlyRate}, myName: {myName}");

      myAge = 35;
      x = 20;
      myHourlyRate = 85.00;
      myName = "George Washington";
      Console.WriteLine($"myAge: {myAge}, x: {x}, myHourlyRate: {myHourlyRate}, myName: {myName}");

    }
  }
}

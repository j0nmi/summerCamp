using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ifDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      int Rachel = 20;
      int Robin = 26;
      int Stacey = 54;
      int Jesse = 60;

      if (Rachel > 18)
      {
        Console.WriteLine("Rachel can vote");
      }

      if (Rachel >= 21 && Robin >= 21)
      {
        Console.WriteLine("Rachel and Robin can drink");
      }
      else if (Rachel >= 21 || Robin >= 21)
      {
        Console.WriteLine("At least one can drink");
      }


    }
  }
}

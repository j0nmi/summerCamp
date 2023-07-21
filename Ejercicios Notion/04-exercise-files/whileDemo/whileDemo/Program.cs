using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whileDemo
{
   class Program
   {
      static void Main(string[] args)
      {
         int myLittleHorses = -1000;
         do
         {
            Console.WriteLine($"myLittleHorses = {myLittleHorses}");
            myLittleHorses++;
         } while (myLittleHorses < 0);
      }
   }
}

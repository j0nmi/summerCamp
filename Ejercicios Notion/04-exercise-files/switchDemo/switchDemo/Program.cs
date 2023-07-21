using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace switchDemo
{
   class Program
   {
      enum Movies
      {
         Casablanca ,
         Godfather,
         Matrix,
         IndianaJones
      }


      static void Main(string[] args)
      {
         Movies bestMovie = Movies.IndianaJones;

          
         switch (bestMovie)
         {
            case Movies.Casablanca:
               Console.WriteLine("Ahhh, Bogie and Bacall...");
               break;
            case Movies.Godfather:
               Console.WriteLine("I'll make him an offer...");
               break;
            case Movies.Matrix:
               Console.WriteLine("Will you take the red pill or the blue?");
               break;
            default:
               Console.WriteLine("You gotta pick one");
               break;
         }
      }
   }
}

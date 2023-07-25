using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constantsDemo
{  
    
    


    /// <summary>
       /// constantsDemo.Program.Ages
       /// </summary>   
    enum Ages
      {
         DemadiadoPequeño = 5,
         PuedeBeber = 18,
         DemasiadoMayor = 85
      }
   class Program
   {
       

      static void Main(string[] args)
      {
         const int age = 20;

         if ( age < (int)Ages.DemadiadoPequeño)
         {
            Console.WriteLine("Sorry, you are too young to play");
         }
         else if (age < (int)Ages.PuedeBeber)
         {
            Console.WriteLine("You can play, but no drinking!");
         }
         else if (age < (int)Ages.DemasiadoMayor)
         {
            Console.WriteLine("Have fun!");
         }
         else
         {
            Console.WriteLine("How about a nice nap?");
         }
      }
   }
}

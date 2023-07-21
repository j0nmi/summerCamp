using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var fechaInicio = new DateTime(2010,01,01);
            var fechaFin = new DateTime(2010,01,02);
            TimeSpan diferencia = fechaFin - fechaInicio;
            
            

            List<Employee> empleados = new List<Employee>();

            Employee tony = new Employee
            {
                Nombre    = "Tony",
                FechaAlta = new DateTime(1998, 01, 01),
                Income    = 120000
            };
            tony.SetRating(Employee.Rating.excellent);
            //tony.FechaAlta = "01/01/2010";



            empleados.Add(tony);

            Employee pepe = new 
                Employee("Pepe",new DateTime(2010,01,01),160000);
            pepe.SetRating(Employee.Rating.poor);
            

            empleados.Add(pepe);


            foreach (Employee empleado in empleados)
            {
                empleado.CalculateRaise();
            }

        }

    }

    public class Employee
    {
        public enum Rating
        {
            poor,
            good,
            excellent

        }

        private Rating rating;

        public Employee()
        {
            Debugger.Break();
        }

        public Employee(string v1, DateTime dateTime, int v2)
        {
            Nombre = v1;
            FechaAlta = dateTime;
            Income = v2;
        }

        public double Income { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaAlta {get; set;}



        public void SetRating(Rating rating)
        {
            this.rating = rating;
        }

        public void CalculateRaise()
        {

            
            var años = YearsOfService();

            double baseRaise = Income * 0.05;
            double bonus = años * 1000;

            Income += baseRaise + bonus;

            switch (rating)
            {
                case Rating.poor:
                    Income -= años * 2000;
                    break;
                case Rating.good:
                    break;
                    case Rating.excellent:
                        Income += años * 500;
                        break;
            }

            Console.WriteLine($"{Nombre} lleva {años} y cobra {Income}");
        }

        private int YearsOfService()
        {

            return DateTime.Now.Year - FechaAlta.Year;

        }


    }
}

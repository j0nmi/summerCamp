using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoredApiService.Clases
{
    internal class BoredActivity
    {
        public class BoredApiResponse
        {
            public string Activity { get; set; }
            public string Type { get; set; }
            public int Participants { get; set; }
            public double Price { get; set; }
            public string Key { get; set; }
            public double Accessibility { get; set; }
        }
    }
}

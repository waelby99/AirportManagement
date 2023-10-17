using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveller : Passenger
    {
        public string HealthyInformation { get; set; }
        public string Nationality { get; set; }
        public override string ToString()
        {
            return base.ToString() + "Nationalité=" + Nationality;
        }
    }
}

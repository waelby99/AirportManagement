using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passeneger
    {
        public DateTime EmploymentDate { get; set; }
        public string Function { get; set; }
        public float Salary { get; set; }
        public override string ToString()
        {
            return base.ToString()+"Fonction=" + Function ;
        }
    }
}

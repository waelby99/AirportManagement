using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType { Boing,Airbus}
    public class Plane
    {
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        public ICollection<Flight> ListFlight { get; set; }
        public override string ToString()
        {
            return "PlaneId=" + PlaneId + " , Capacité=" + Capacity + " , Type d'avion=" + PlaneType ;
        }
        /*public Plane(PlaneType pt, int capacity, DateTime date)
        {
            this.PlaneType = pt;
            this.Capacity = capacity;
            this.ManufactureDate = date;
        }
        public Plane() { }*/
    }
}

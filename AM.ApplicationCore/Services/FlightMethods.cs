using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods:IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            foreach (Flight f in Flights)


            {
                if (f.Destination == destination)
                    dates.Add(f.FlightDate);

            }
            return dates;
        }
        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (var item in Flights)
                    {
                        if (item.Destination == filterValue)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case "Depature":
                    foreach (var item in Flights)
                    {
                        if (item.Depature == filterValue)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (var item in Flights)
                    {
                        if (item.FlightDate == DateTime.Parse(filterValue))
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case "EffectiveArrival":
                    foreach (var item in Flights)
                    {
                        if (item.EffectiveArrival == DateTime.Parse(filterValue))
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case "FlightId":
                    foreach (var item in Flights)
                    {
                        if (item.FlightId == int.Parse(filterValue))
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
            }


        }
    }

}

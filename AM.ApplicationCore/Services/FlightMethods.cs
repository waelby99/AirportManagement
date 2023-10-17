using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethodes : IFlightMethods
    {

        public List<Flight> Flights { get; set; } = new List<Flight>();

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlight()
        {
            var requet = from f in Flights
                         group f by f.Destination;
            foreach (var g in requet)
            {
                Console.WriteLine(g.Key);
                foreach (var f in g)
                {
                    Console.WriteLine(f.FlightDate);
                }
            }
            return requet;
        }

        public double DurationAvrage(string destination)
        {
            var requet = from f in Flights
                         where f.Destination == destination
                         select f.EstimatedDuration;
            return requet.Average();
        }

        public List<DateTime> GetFlightDates(string destination)
        {
            //List<DateTime> dates = new List<DateTime>();
            //for(int i = 0; i < Flights.Count; i++)
            //{
            //    if (Flights[i].Destination == destination) {
            //        dates.Add(Flights[i].FlightDate);
            //    }
            //}

            //foreach (var item in Flights)
            //{
            //    if (item.Destination == destination)
            //    {
            //        dates.Add(item.FlightDate);
            //    }
            //}
            //return dates;

            IEnumerable<DateTime> request = from f in Flights
                                            where (f.Destination == destination)
                                            select f.FlightDate;
            return request.ToList();
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
                        if (item.Departure == filterValue)
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

        public IEnumerable<Flight> OrderedDurationsFlight()
        {
            var requet = from f in Flights
                         orderby f.EstimatedDuration descending
                         select f;
            return requet;
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var requete = from f in Flights
                          where (f.FlightDate - startDate).TotalDays < 7 && DateTime.Compare(f.FlightDate, startDate) > 0
                          select f;
            return requete.Count();
        }

        public IEnumerable<Passeneger> SeniorTravellers(Flight flight)
        {
            var request = from p in flight.ListPassengers.OfType<Traveller>()
                          orderby p.BirthDate ascending
                          select p;
            return request.Take(3);

        }

        public void ShowFligthDetails(Plane plane)
        {
            var requet = from f in Flights
                         where (f.Plane == plane)
                         //select new{ f.Destination, f.FlightDate };
                         select f;
            foreach (var f in requet)
            {
                Console.WriteLine(f.FlightDate + "/" + f.Destination);
            }
        }
    }
}
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

FlightMethodes flightMethode = new FlightMethodes();
flightMethode.Flights = TestData.listFlights;

foreach (var item in flightMethode.GetFlightDates("Paris"))
{
    Console.WriteLine(item);
}
flightMethode.GetFlights("Destination", "Paris");

flightMethode.DestinationGroupedFlight();
Console.WriteLine("-------------------------");
flightMethode.ShowFligthDetails(TestData.BoingPlane);
Console.WriteLine("*****");
Console.WriteLine(flightMethode.ProgrammedFlightNumber(new DateTime(2022, 01, 31)));
Console.WriteLine("++++++++++");
Console.WriteLine(flightMethode.DurationAvrage("Paris"));
Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*");
foreach (var item in flightMethode.OrderedDurationsFlight())
{
    Console.WriteLine(item);
}
Console.WriteLine("==========================");
foreach (var item in flightMethode.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(item);
}
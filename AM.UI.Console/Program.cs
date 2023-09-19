// See https://aka.ms/new-console-template for more information

using AM.ApplicationCore.Domain;

/*Plane p1 = new Plane(); 
p1.Capacity = 200;
p1.PlaneId = 23;
p1.ManufactureDate = new DateTime(2007,12,12);
p1.PlaneType= PlaneType.Airbus;
Plane p2 = new Plane(PlaneType.Boing,114, new DateTime(2008, 07, 07));*/
Plane p3 =new Plane { Capacity=300, PlaneType = PlaneType.Airbus, ManufactureDate = new DateTime(2012, 12, 12), PlaneId = 121 };
/*Console.WriteLine(p1.ToString());
Console.WriteLine(p2.ToString());*/
Passeneger pa1 = new Passeneger { FirstName = "Wael", LastName="Ben youssef",EmailAdress="wael@gmail.com"};
Console.WriteLine(pa1.CheckProfile("Wael", "Benyoussef"));

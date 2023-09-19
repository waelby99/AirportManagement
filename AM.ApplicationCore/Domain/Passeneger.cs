using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passeneger
    {
        public DateOnly BirthDate { get; set; }
        public int PasseportNumber { get; set; }
        public string EmailAdress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelNumber { get; set; }
        public ICollection<Flight> ListFlights { get; set; }
        public override string ToString()
        {
            return "Nom=" + FirstName + " , Prenom=" + LastName + " , Date de naiisance=" + BirthDate + " , Email =" + EmailAdress;
        }
        public bool CheckProfile(string firstname, string lastname,string emailaddress=null)
        {
            if (emailaddress != null) 
            { 
                return FirstName==firstname && LastName== lastname && EmailAdress == emailaddress;
            }
            else
            {
                 return FirstName == firstname && LastName == lastname;
            }
        }
    }
}

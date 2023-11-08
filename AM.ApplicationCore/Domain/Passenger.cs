﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int Id { get; set; }

        [Key]
        [StringLength(7)]
        public string PassengerNumber { get; set; }
        [MaxLength(25, ErrorMessage = "Langeur maximale = 25")]
        [MinLength(3, ErrorMessage = "Langeur minimale=3")]
        public FullName FullName { get; set; }
        
        [Display(Name = "Date of birth ")]
        public DateTime BirthDate { get; set; }
        [RegularExpression(@"^[0-9]{8}$")]
        public int TelNumber { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        //prop de navigation
       // public virtual List<Flight> Flights { get; set; }
       public virtual List<Ticket> Tickets { get; set; }    

        //TP1-Q6: Réimplémenter la méthode ToString()
        public override string ToString()
        {
            return "FirstName: " + FullName.FirstName + " LastName: " + FullName.LastName + " date of Birth: "+ BirthDate;
        }

        //TP1-Q10: Créer les trois méthodes bool CheckProfile(...)
        //public bool CheckProfile(string firstName, string lastName)
        //{
        //    return FirstName == firstName && LastName == lastName;
        //}

        //public bool CheckProfile(string firstName, string lastName, string email)
        //{
        //    return FirstName == firstName && LastName == lastName && EmailAddress == email;
        //}

        public bool CheckProfile(string firstName, string lastName, string email = null)
        {
            if (email != null)
                return FullName.FirstName == firstName && FullName.LastName == lastName && EmailAddress == email;
            else
                return FullName.FirstName == firstName && FullName.LastName == lastName;
        }

        //TP1-Q11.a: Implémenter la méthode PassengerType()
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a Passenger");
        }

    }
}

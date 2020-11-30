using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skateshop.Models
{
    public enum State
    {
        Österreich, Deutschland, Schweitz, notSpecified
    }

    public class User
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }

        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public State State { get; set; }

        public User() : this(0, "", "", "", DateTime.MinValue, 
                            "", "", "", "", State.notSpecified) { }
        public User(int id, string firstname, string lastname, string email, DateTime birthdate,
                    string street, string streetNumber, string zipcode, string city, State state)
        {
            this.ID = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Email = email;
            this.Birthdate = birthdate;

            this.Street = street;
            this.StreetNumber = streetNumber;
            this.Zipcode = zipcode;
            this.City = city;
            this.State = state;
        }

        public override string ToString()
        {
            return this.ID + " " + this.Firstname + " " + this.Lastname + "\n" +
                this.Email + " " + this.Birthdate.ToLongDateString() + "\n" +
                this.Street + " " + this.StreetNumber + "\n" +
                this.Zipcode + " " + this.City + "\n" +
                this.State;
        }
    }
}

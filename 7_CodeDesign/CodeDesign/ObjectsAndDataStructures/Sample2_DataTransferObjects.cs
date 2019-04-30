using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsAndDataStructures
{
    public class Sample2_DataTransferObjects
    {
        // A Data Transfer Object (DTO) is a class with public variables and no functions.
        // They are useful when communicating with databases or parsing messages from sockets, or to cross boundaries between
        // software layers. They are often the first in a series of translation stages that convert raw data in a database
        // into objects in the application code.

        public class Address
        {

            public Address(string street, string streetExtra, string city, string postalCode, string state)
            {
                this.Street = street;
                this.StreetExtra = streetExtra;
                this.City = city;
                this.PostalCode = postalCode;
                this.State = state;
            }

            public string Street { get; set; }

            public string StreetExtra { get; set; }

            public string City { get; set; }

            public string PostalCode { get; set; }

            public string State { get; set; }
        }
    }
}

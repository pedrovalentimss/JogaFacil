using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.App.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Neighbourhood { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}

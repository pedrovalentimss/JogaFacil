using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.Api.Entities
{
    public class Place
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }

        public OpenHours OpenHours { get; set; }

        public List<Arena> Arenas { get; set; }

        public User Owner { get; set; }

        public List<User> Admins { get; set; }
    }

    [Owned]
    public class Address
    {
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

    [Owned]
    public class OpenHours
    {
        public OpenHoursDay Monday { get; set; }

        public OpenHoursDay Tuesday { get; set; }

        public OpenHoursDay Wednesday { get; set; }

        public OpenHoursDay Thursday { get; set; }

        public OpenHoursDay Friday { get; set; }

        public OpenHoursDay Saturday { get; set; }

        public OpenHoursDay Sunday { get; set; }
    }

    [Owned]
    public class OpenHoursDay
    {
        public DateTime OpeningHour { get; set; }

        public DateTime ClosingHour { get; set; }
    }
}

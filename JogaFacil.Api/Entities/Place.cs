using JogaFacil.Api.Data;
using JogaFacil.Api.Util;
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

        public virtual List<Arena> Arenas { get; set; }

        public virtual User Owner { get; set; }

        public virtual List<User> Admins { get; set; }
    }
}

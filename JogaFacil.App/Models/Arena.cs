using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.App.Models
{
    public class Arena
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ArenaType Type { get; set; }

        public string Description { get; set; }
    }

    public enum ArenaType
    {
        Indoor,
        Outdoor
    }
}

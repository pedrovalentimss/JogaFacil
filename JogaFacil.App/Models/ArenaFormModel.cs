using JogaFacil.App.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace JogaFacil.App.Models
{
    public class ArenaFormModel
    {
        public ArenaFormModel(Arena arena)
        {
            Name = arena.Name;
            Type = arena.Type.ToString();
            Sport = arena.Sport;
            Description = arena.Description;
        }

        public ArenaFormModel()
        {

        }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Sport { get; set; }

        public string Description { get; set; }

    }
}

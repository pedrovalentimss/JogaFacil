using JogaFacil.App.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace JogaFacil.App.Models
{
    public class PlaceFormModel
    {
        public PlaceFormModel(Place place)
        {
            Name = place.Name;
            Phone = place.Phone;
            Street = place.Address.Street;
            Number = place.Address.Number;
            Neighbourhood = place.Address.Neighbourhood;
            State = place.Address.State;
            City = place.Address.City;
            PostalCode = place.Address.PostalCode;
        }

        public PlaceFormModel()
        {

        }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Neighbourhood { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }
    }
}

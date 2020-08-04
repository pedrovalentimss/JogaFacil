using JogaFacil.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.Client.Services
{
    public interface IPlacesService
    {
        Task<Place[]> GetAllPlaces();

        Task<Place> GetPlace(int id);
    }
}

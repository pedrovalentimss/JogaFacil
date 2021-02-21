using JogaFacil.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.App.Services
{
    public interface IPlacesService
    {
        Task<Place[]> GetAllPlaces();

        Task<Place> GetPlace(int id);

        Task<Place> GetPlaceFromOwner(int ownerId);

        void CreatePlace(Place place);

        Task EditPlace(Place place);
    }
}

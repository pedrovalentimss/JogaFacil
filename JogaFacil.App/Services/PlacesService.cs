using JogaFacil.App.Models;
using JogaFacil.App.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace JogaFacil.App.Services
{
    public class PlacesService : IPlacesService
    {
        private readonly HttpClient _http;
        private const string API_URL = "https://localhost:44360/";

        public PlacesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Place[]> GetAllPlaces()
        {
            var route = API_URL + "api/places";
            return await _http.GetJsonAsync<Place[]>(route);
        }

        public async Task<Place> GetPlace(int id)
        {
            var route = API_URL + "api/places/" + id;
            return await _http.GetJsonAsync<Place>(route);
        }

        public async Task<Place> GetPlaceFromOwner(int ownerId)
        {
            var builder = new UriBuilder(API_URL);
            builder.Path = "api/places/owner/" + ownerId;

            var route = builder.ToString();
            return await _http.GetJsonAsync<Place>(route);
        }

        public void CreatePlace(Place place)
        {
            var builder = new UriBuilder(API_URL);
            builder.Path = "api/places";

            var route = builder.ToString();
            _http.PostJsonAsync(route, place);
        }

        public async Task EditPlace(Place place)
        {
            var builder = new UriBuilder(API_URL);
            builder.Path = "api/places/" + place.Id;

            var route = builder.ToString();
            await _http.PutJsonAsync(route, place);
        }
    }
}

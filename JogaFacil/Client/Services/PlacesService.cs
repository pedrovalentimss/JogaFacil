using JogaFacil.Client.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JogaFacil.Client.Services
{
    public class PlacesService : IPlacesService
    {
        private readonly HttpClient _http;
        private const string API_URL = "https://localhost:44360/api";

        public PlacesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Place[]> GetAllPlaces()
        {
            var route = API_URL + "/places";
            return await _http.GetJsonAsync<Place[]>(route);
        }

        public async Task<Place> GetPlace(int id)
        {
            var route = API_URL + "/places/" + id;
            return await _http.GetJsonAsync<Place>(route);
        }
    }
}

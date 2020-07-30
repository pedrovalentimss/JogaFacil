using JogaFacil.App.Models;
using JogaFacil.App.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JogaFacil.App.Services
{
    public class ArenasService : IArenasService
    {
        private readonly HttpClient _http;
        private const string API_URL = "https://localhost:44360/api";

        public ArenasService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Arena> GetArena(int id)
        {
            var route = API_URL + "/arenas/" + id;
            return await _http.GetJsonAsync<Arena>(route);
        }
    }
}

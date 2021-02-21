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
    public class UsersService : IUsersService
    {
        private readonly HttpClient _http;
        private const string API_URL = "https://localhost:44360/api";

        public UsersService(HttpClient http)
        {
            _http = http;
        }

        public async Task<User> GetUser(string id)
        {
            var route = API_URL + "/accounts/" + Convert.ToInt32(id);
            return await _http.GetJsonAsync<User>(route);
        }
    }
}

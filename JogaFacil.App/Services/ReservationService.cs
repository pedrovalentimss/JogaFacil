using JogaFacil.App.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JogaFacil.App.Services
{
    public class ReservationService : IReservationService
    {
        private readonly HttpClient _http;
        private const string API_URL = "https://localhost:44360/api";

        public ReservationService(HttpClient http)
        {
            _http = http;
        }

        public void AddReservation(Reservation reservation)
        {
            var route = API_URL + "/reservations";
            _http.PostJsonAsync(route, reservation);
        }

        public void EditReservation(Reservation reservation)
        {
            var route = API_URL + "/reservations/" + reservation.Id;
            _http.PutJsonAsync(route, reservation);
        }

        public async Task<Reservation[]> GetAllReservations()
        {
            var route = API_URL + "/reservations";
            return await _http.GetJsonAsync<Reservation[]>(route);
        }
    }
}

using JogaFacil.Client.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace JogaFacil.Client.Services
{
    public class ReservationService : IReservationService
    {
        private readonly HttpClient _http;
        private const string API_URL = "https://localhost:44360/";

        public ReservationService(HttpClient http)
        {
            _http = http;
        }

        public void AddReservation(Reservation reservation)
        {
            var builder = new UriBuilder(API_URL);
            builder.Path = "api/reservations";

            var route = builder.ToString();
            _http.PostJsonAsync(route, reservation);
        }

        public void EditReservation(Reservation reservation)
        {
            var builder = new UriBuilder(API_URL);
            builder.Path = "api/reservations/" + reservation.Id;

            var route = builder.ToString();
            _http.PutJsonAsync(route, reservation);
        }

        public async Task<Reservation[]> GetAllReservations()
        {
            var builder = new UriBuilder(API_URL);
            builder.Path = "api/reservations";

            var route = builder.ToString();
            return await _http.GetJsonAsync<Reservation[]>(route);
        }
        
        public async Task<Reservation[]> GetReservationsByStatus(int status)
        {
            var builder = new UriBuilder(API_URL);
            builder.Path = "api/reservations";

            var query = HttpUtility.ParseQueryString(builder.Query);
            query.Add("status", status.ToString());

            builder.Query = query.ToString();
            var route = builder.ToString();
            return await _http.GetJsonAsync<Reservation[]>(route);
        }
    }
}

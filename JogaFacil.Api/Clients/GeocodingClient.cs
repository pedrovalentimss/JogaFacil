using JogaFacil.Api.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace JogaFacil.Api.Clients
{
    public class GeocodingClient
    {
        private readonly HttpClient _http;
        private const string GEOCODING_API_URL = "http://open.mapquestapi.com/geocoding/v1/address?key=l9kEICAueQ5xkd6PCdJPqe8t34yK0we4&";
        private const string GEOCODING_API_TOKEN = "l9kEICAueQ5xkd6PCdJPqe8t34yK0we4";
    
        public GeocodingClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<Coordinates> GetCoordinatesFromAddress(Address address)
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString.Add("street", address.Street);
            queryString.Add("city", address.City);
            queryString.Add("state", address.State);
            queryString.Add("postalCode", address.PostalCode);

            var response = await _http.GetAsync(GEOCODING_API_URL + queryString.ToString());

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                dynamic data = JObject.Parse(jsonString);
                double lat = data.results[0].locations[0].latLng.lat;
                double lng = data.results[0].locations[0].latLng.lng;

                return new Coordinates
                {
                    Latitude = lat,
                    Longitude = lng
                };
            }

            return null;
        }
    }

    public class Coordinates
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}

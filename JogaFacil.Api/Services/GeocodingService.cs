using JogaFacil.Api.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace JogaFacil.Api.Services
{
    public class GeocodingService : IGeocodingService
    {
        private readonly HttpClient _http;
        private readonly IOptions<AppSettings> _appSettings;
    
        public GeocodingService(HttpClient http, IOptions<AppSettings> appSettings)
        {
            _http = http;
            _appSettings = appSettings;
        }

        public async Task<Coordinates> GetCoordinatesFromAddress(Address address)
        {
            var builder = new UriBuilder(_appSettings.Value.GeocodingApiUrl);
            builder.Port = -1;

            var query = HttpUtility.ParseQueryString(builder.Query);
            query.Add("key", _appSettings.Value.GeocodingApiToken);
            query.Add("street", address.Street);
            query.Add("city", address.City);
            query.Add("state", address.State);
            query.Add("postalCode", address.PostalCode);

            builder.Query = query.ToString();
            string url = builder.ToString();

            var response = await _http.GetAsync(url);

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

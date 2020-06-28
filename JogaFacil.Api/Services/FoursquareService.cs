using JogaFacil.Api.Entities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace JogaFacil.Api.Services
{
    public class FoursquareService : IFoursquareService
    {
        private readonly HttpClient _http;
        private readonly IOptions<AppSettings> _appSettings;

        public FoursquareService(HttpClient http, IOptions<AppSettings> appSettings)
        {
            _http = http;
            _appSettings = appSettings;
        }

        public async Task<IEnumerable<Place>> GetPlacesFromCity(string city)
        {
            var builder = new UriBuilder(_appSettings.Value.FoursquareApiUrl);
            builder.Path = "v2/venues/search";
            builder.Port = -1;

            var query = HttpUtility.ParseQueryString(builder.Query);
            query.Add("client_id", _appSettings.Value.FoursquareApiId);
            query.Add("client_secret", _appSettings.Value.FoursquareApiSecret);
            query.Add("near", city);
            query.Add("query", "quadra de futsal");
            query.Add("v", "20200501");
            //query.Add("categoryId", "4f4528bc4b90abdf24c9de85");

            builder.Query = query.ToString();
            string url = builder.ToString();

            var response = await _http.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                dynamic data = JObject.Parse(jsonString);
                var venues = data.response.venues;

                var places = new List<Place>();

                foreach (var item in venues)
                {
                    var place = new Place { 
                        Name = item.name,
                    };

                    places.Add(place);
                }

                return places;
            }

            return null;
        }
    }
}

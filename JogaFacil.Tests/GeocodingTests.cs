using Microsoft.VisualStudio.TestTools.UnitTesting;
using JogaFacil.Api.Clients;
using System.Net.Http;
using JogaFacil.Api.Entities;

namespace JogaFacil.Tests
{
    [TestClass]
    public class GeocodingTests
    {
        [TestMethod]
        public void GetCoordinates()
        {
            HttpClient httpClient = new HttpClient();
            GeocodingClient geocodingClient = new GeocodingClient(httpClient);

            var address = new Address
            {
                Street = "1600 Pennsylvania Ave NW",
                Number = "",
                Neighbourhood = "",
                PostalCode = "20500",
                City = "Washington",
                State = "DC", 
                Country = ""
            };

            var coordinates = geocodingClient.GetCoordinatesFromAddress(address);
            var lat = coordinates.Result.Latitude;
            var lng = coordinates.Result.Longitude;
        }
    }
}

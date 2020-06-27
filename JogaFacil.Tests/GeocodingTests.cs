using Microsoft.VisualStudio.TestTools.UnitTesting;
using JogaFacil.Api.Clients;
using System.Net.Http;
using JogaFacil.Api.Entities;
using Microsoft.Extensions.Options;
using JogaFacil.Api;
using Moq;

namespace JogaFacil.Tests
{
    [TestClass]
    public class GeocodingTests
    {
        [TestMethod]
        public void GetCoordinates()
        {
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
        }
    }
}

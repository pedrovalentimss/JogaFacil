using JogaFacil.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.Api.Services
{
    public interface IGeocodingService
    {
        Task<Coordinates> GetCoordinatesFromAddress(Address address);
    }
}

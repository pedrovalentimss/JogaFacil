using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JogaFacil.Api.Data;
using JogaFacil.Api.Entities;
using JogaFacil.Api.Services;
using Microsoft.Extensions.Options;
using JogaFacil.Api.Clients;
using System.Net.Http;

namespace JogaFacil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly Context _context;
        private readonly IGeocodingService _geocodingClient;

        public PlacesController(Context context, IGeocodingService geocodingClient)
        {
            _context = context;
            _geocodingClient = geocodingClient;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetAllPlaces()
        {
            return await _context.Places
                .Include(p => p.Address)
                .Include(p => p.OpenHours)
                .Include(p => p.Arenas)
                .Include(p => p.Owner)
                .Include(p => p.Admins)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> GetPlace(int id)
        {
            var place = await _context.Places
                .Include(p => p.Address)
                .Include(p => p.OpenHours)
                .Include(p => p.Arenas)
                .Include(p => p.Owner)
                .Include(p => p.Admins)
                .SingleAsync(p => p.Id == id);

            if (place == null)
            {
                return NotFound();
            }

            return place;
        }

        [HttpGet("coordinates/")]
        public async Task<ActionResult<Coordinates>> GetCoordinates()
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

            return await _geocodingClient.GetCoordinatesFromAddress(address);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlace(int id, Place place)
        {
            if (id != place.Id)
            {
                return BadRequest();
            }

            _context.Entry(place).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Place>> PostPlace(Place place)
        {
            _context.Places.Add(place);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlace", new { id = place.Id }, place);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Place>> DeletePlace(int id)
        {
            var place = await _context.Places.FindAsync(id);
            if (place == null)
            {
                return NotFound();
            }

            _context.Places.Remove(place);
            await _context.SaveChangesAsync();

            return place;
        }

        private bool PlaceExists(int id)
        {
            return _context.Places.Any(e => e.Id == id);
        }
    }
}

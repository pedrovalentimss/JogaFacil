﻿using System;
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
using System.Net.Http;

namespace JogaFacil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly Context _context;
        private readonly IGeocodingService _geocodingService;
        private readonly IFoursquareService _foursquareService;

        public PlacesController(Context context,
            IGeocodingService geocodingService,
            IFoursquareService foursquareService)
        {
            _context = context;
            _geocodingService = geocodingService;
            _foursquareService = foursquareService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlaces(string city = null, string sport = null)
        {
            if (city != null)
            {
                var places = GetPlacesFromCity(city); 

                if (places.Result.Any())
                {
                    return places.Result.ToList();
                }

                var placesFromService = GetPlacesFromService(city);

                placesFromService.Result.ToList().ForEach(async p => await PostPlace(p));

                places = GetPlacesFromCity(city);

                return places.Result.ToList();
            }

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

        public async Task<IEnumerable<Place>> GetPlacesFromService(string city)
        
        {
            var places = await _foursquareService.GetPlacesFromCity(city);
            return places.ToList();
        }

        public async Task<IEnumerable<Place>> GetPlacesFromCity(string city)
        {
            return await _context.Places
                .Include(p => p.Address)
                .Include(p => p.OpenHours)
                .Include(p => p.Arenas)
                .Include(p => p.Owner)
                .Include(p => p.Admins)
                .Where(p => p.Address.City.ToLower().Equals(city.ToLower()))
                .ToListAsync();
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
            //if (place.Address.Latitude == null || place.Address.Longitude == null)
            //{
            //    var coordinates = await _geocodingService.GetCoordinatesFromAddress(place.Address);
            //    place.Address.Latitude = coordinates.Latitude.ToString();
            //    place.Address.Longitude = coordinates.Longitude.ToString();
            //}

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

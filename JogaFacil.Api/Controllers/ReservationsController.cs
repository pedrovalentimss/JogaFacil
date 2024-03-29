﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JogaFacil.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using JogaFacil.Api.Auth;

namespace JogaFacil.Api.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly AuthContext _context;

        public ReservationsController(AuthContext context)
        {
            _context = context;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations(int placeId = 0, int status = 0, int userId = 0)
        {
            if (placeId != 0 && status == 0)
                return GetReservationsFromPlace(placeId).Result;

            if (placeId == 0 && status != 0)
                return GetReservationsByStatus(status).Result;

            if (placeId != 0 && status != 0)
                return GetReservationsFromPlaceByStatus(status, placeId).Result;

            if (userId != 0)
                return GetReservationsFromUser(userId).Result;

            return await _context.Reservations
                .Include(r => r.Place)
                .Include(r => r.Place.Arenas)
                .Include(r => r.User)
                .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservationsFromPlace(int placeId)
        {
            return await _context.Reservations
            .Include(r => r.Place)
            .Include(r => r.Place.Arenas)
            .Include(r => r.User)
            .Where(r => r.Place.Id == placeId)
            .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservationsByStatus(int status)
        {
            return await _context.Reservations
            .Include(r => r.Place)
            .Include(r => r.Place.Arenas)
            .Include(r => r.User)
            .Where(r => r.Status == (ReservationStatus)status)
            .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservationsFromPlaceByStatus(int status, int placeId)
        {
            return await _context.Reservations
            .Include(r => r.Place)
            .Include(r => r.Place.Arenas)
            .Include(r => r.User)
            .Where(r => r.Place.Id == placeId)
            .Where(r => r.Status == (ReservationStatus)status)
            .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservationsFromUser(int userId)
        {
            return await _context.Reservations
            .Include(r => r.Place)
            .Include(r => r.Place.Arenas)
            .Include(r => r.User)
            .Where(r => r.User.Id == userId)
            .ToListAsync();
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        // PUT: api/Reservations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!ReservationExists(id))
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
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            try
            {
                _context.Places.Attach(reservation.Place);
                _context.Users.Attach(reservation.User);
                _context.Reservations.Add(reservation);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservation>> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}

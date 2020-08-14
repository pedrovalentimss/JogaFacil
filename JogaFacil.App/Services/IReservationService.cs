using JogaFacil.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.App.Services
{
    public interface IReservationService
    {
        void AddReservation(Reservation reservation);

        Task EditReservation(Reservation reservation);

        Task<Reservation[]> GetAllReservations();

        Task<Reservation[]> GetReservationsByStatus(int status);

        Task<Reservation[]> GetReservationsFromPlace(int status);
    }
}

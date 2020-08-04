using JogaFacil.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.Client.Services
{
    public interface IReservationService
    {
        void AddReservation(Reservation reservation);

        void EditReservation(Reservation reservation);

        Task<Reservation[]> GetAllReservations();

        Task<Reservation[]> GetReservationsByStatus(int status);
    }
}

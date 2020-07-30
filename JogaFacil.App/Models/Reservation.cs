using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.App.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public Place Place { get; set; }

        public int ArenaId { get; set; }

        public User User { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public ReservationStatus Status { get; set; }
    }

    public enum ReservationStatus
    {
        WaitingApprovement = 0,
        Approved = 1,
        Denied = 2,
        Canceled = 3
    }
}

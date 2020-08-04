using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.Client.Models
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
        WaitingApprovement = 1,
        Approved = 2,
        Denied = 3,
        Canceled = 4
    }
}

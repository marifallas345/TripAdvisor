using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TripAdvisor.Views;

namespace TripAdvisor.Models
{
    public class Booked
    {
        public int BookedId { get; set; }
        public int TripId { get; set; }
        public string Email { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public int Adults { get; set; }
        public string BookedHour { get; set; }
        public decimal Total { get; set; }
    }
}
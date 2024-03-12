using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TripAdvisor.Models;

namespace TripAdvisor.Controllers
{
    public class BookedController
    {
        public void SaveBooked(Booked booked)
        {
            DatabaseHelper.Database database = new DatabaseHelper.Database();

            database.SaveBooked(booked);
        }
    }
}
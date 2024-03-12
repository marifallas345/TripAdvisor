using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TripAdvisor.Models;

namespace TripAdvisor.Controllers
{
    public class TripController
    {
        public List<Trip> GetTrips()
        {
            List<Trip> tripList = new List<Trip>();

            //Trip trip = new Trip()
            //{
            //	Id = 1,
            //	Name = "Excursión de aventura de un día desde San José",
            //	Description = "Esta excursión de aventura desde San José reúne lo mejor de las playas, ríos y selvas tropicales en un día repleto de acción. Tome el sol en la playa popular de Jacó",
            //	Price = 2820,
            //	PhotoPath = "../Assets/images/1.jpg"
            //};
            //Trip trip2 = new Trip()
            //{
            //	Id = 2,
            //	Name = "La Paz Waterfall Gardens",
            //	Description = "Sumérjase con seguridad en la naturaleza y vida salvaje de Costa Rica con esta excursión de 7 horas por las cascadas de los jardines de la Paz",
            //	Price = 2291,
            //	PhotoPath = "../Assets/images/2.jpg"
            //};
            //Trip trip3 = new Trip()
            //{
            //	Id = 3,
            //	Name = "Parque Nacional Manuel Antonio",
            //	Description = "Explore el Parque Nacional Manuel Antonio en esta excursión de un día desde San José. En el camino hacia el parque, se hará una parada para disfrutar de un tradicional desayuno costarricense",
            //	Price = 3084,
            //	PhotoPath = "../Assets/images/3.jpg"
            //};

            //tripList.Add(trip);
            //tripList.Add(trip2);
            //tripList.Add(trip3);

            //Ahora usamos la base de datos
            DatabaseHelper.Database database = new DatabaseHelper.Database();
            DataTable dsTrips = database.GetTrips();

            foreach (DataRow dr in dsTrips.Rows)
            {
                tripList.Add(new Trip
                {
                    Id = (int)dr["id"],
                    Name = dr["name"].ToString(),
                    Description = dr["description"].ToString(),
                    Price = (decimal)dr["price"],
                    PhotoPath = dr["photoPath"].ToString()
                });
            }

            return tripList;
        }

        public List<Trip> GetTrip(int id)
        {
            List<Trip> tripList = GetTrips();

            foreach (Trip trip in tripList)
            {
                if (trip.Id == id)
                {
                    tripList.Clear();
                    tripList.Add(trip);
                    return tripList;
                }
            }

            return null;
        }
    }
}
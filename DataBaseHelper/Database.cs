using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TripAdvisor.Models;

namespace TripAdvisor.DatabaseHelper
{
    public class Database
    {
        const string database = "TripAdvisor";
        const string server = "LAPTOP-ILQCD4II";
        SqlConnection connection = new SqlConnection($"Data Source={server};Initial Catalog={database};Integrated Security=True");

        public DataTable GetTrips()
        {
            return Fill("spGetTrips");
        }

        public void SaveBooked(Booked booked)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@tripId", booked.TripId));
            paramList.Add(new SqlParameter("@email", booked.Email));
            paramList.Add(new SqlParameter("@checkin", booked.Checkin));
            paramList.Add(new SqlParameter("@checkout", booked.Checkout));
            paramList.Add(new SqlParameter("@adults", booked.Adults));
            paramList.Add(new SqlParameter("@bookedHour", booked.BookedHour));
            paramList.Add(new SqlParameter("@total", booked.Total));

            Execute("spSaveBooked", paramList);
        }


        public DataTable Fill(string storedProcedure)
        {
            //control de errores
            try
            {
                //usamos la conexion
                using (this.connection)
                {
                    //abra la conexion a la base de datos
                    connection.Open();
                    //creamos un comando de base de datos
                    SqlCommand cmd = connection.CreateCommand();
                    //el comando es de tipo store procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    //le damos el noombre del store procedure
                    cmd.CommandText = storedProcedure;

                    //creamos el objeto que almacena los datos
                    DataTable ds = new DataTable();
                    //el adaptador ejecuta el comando a la base de datos
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    //llena el objeto con los datos que devolvio el adapter
                    adapter.Fill(ds);
                    //retornamos el objeto lleno de datos
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Execute(string storedProcedure, List<SqlParameter> paramList)
        {
            //control de errores
            try
            {
                //usamos la conexion
                using (this.connection)
                {
                    //abra la conexion a la base de datos
                    connection.Open();
                    //creamos un comando de base de datos
                    SqlCommand cmd = connection.CreateCommand();
                    //el comando es de tipo store procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    //le damos el noombre del store procedure
                    cmd.CommandText = storedProcedure;

                    foreach (SqlParameter param in paramList)
                    {
                        cmd.Parameters.Add(param);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
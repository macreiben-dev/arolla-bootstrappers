using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TrainReservationRepos;

namespace TrainReservationCore
{
    public class TrainRepository : ITrainRepository
    {
        /**
         * SURTOUT NE PAS FAIRE CA EN VRAI, C'eST MAL !!!
         * */
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LocalTrainReservation;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public TrainRepository()
        {
        }

        public IEnumerable<Seat> GetAvaibleSeats(string trainName)
        {
            List<SeatDto> data = new List<SeatDto>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var temp = connection.Query<SeatDto>(@"SELECT CoachName, SeatNumber 
                    FROM TrainReservations 
                    WHERE TrainName = @TrainName", new { TrainName = trainName });

                return temp.Select(c => new Seat(c.CoachName, c.SeatNumber));
            }
        }

        public int GetAvailableSeatCountByTrainName(string trainName)
        {
            throw new NotImplementedException();
        }
    }
}

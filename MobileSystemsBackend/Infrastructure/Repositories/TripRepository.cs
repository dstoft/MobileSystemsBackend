using MobileSystemsBackend.Domain;
using Npgsql;

namespace MobileSystemsBackend.Infrastructure.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly string _connectionString;
        private readonly string _table = "\"Trip\"";

        public TripRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int Create(Trip trip)
        {
            var returnValue = -1;
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using var cmd = BuildInsertSqlCommand(trip);
                cmd.Connection = conn;
                returnValue += cmd.ExecuteNonQuery();
            }

            return returnValue;
        }

        public Trip Read(int id)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            using var cmd =
                new NpgsqlCommand(
                    $"SELECT * FROM {_table} WHERE id=@Id", conn);
            cmd.Parameters.AddWithValue("id", id);
            using var reader = cmd.ExecuteReader();

            reader.Read();
            return new Trip {Id = reader.GetInt32(0), Time = reader.GetInt64(1)};
        }

        private NpgsqlCommand BuildInsertSqlCommand(Trip trip)
        {
            var cmd =
                new NpgsqlCommand(
                    $"INSERT INTO {_table}(time) VALUES (@time)");
            cmd.Parameters.AddWithValue("time", trip.Time);
            return cmd;
        }
    }
}
using System.Collections.Generic;
using MobileSystemsBackend.Domain;
using Npgsql;

namespace MobileSystemsBackend.Infrastructure.Repositories
{
    public class CoordinateRepository : ICoordinateRepository
    {
        private readonly string _connectionString;
        private readonly string _table = "Coordinate";

        public CoordinateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Create(Coordinate coordinate)
        {
            var returnValue = -1;
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using var cmd = BuildSqlCommand(coordinate);
                cmd.Connection = conn;
                returnValue += cmd.ExecuteNonQuery();
            }

            return returnValue;
        }

        public int CreateBulk(List<Coordinate> coordinates)
        {
            var cmds = new List<NpgsqlCommand>();
            foreach (var coordinate in coordinates) cmds.Add(BuildSqlCommand(coordinate));

            var returnValue = -cmds.Count;
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                cmds.ForEach(cmd =>
                {
                    cmd.Connection = conn;
                    returnValue += cmd.ExecuteNonQuery();
                });
            }

            return returnValue;
        }

        public List<Coordinate> ReadAll()
        {
            var returnList = new List<Coordinate>();
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using var cmd =
                    new NpgsqlCommand(
                        $"SELECT * FROM {_table}", conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                    returnList.Add(new Coordinate
                    {
                        Id = reader.GetInt32(0),
                        Time = reader.GetInt64(1),
                        Latitude = reader.GetDouble(2),
                        Longitude = reader.GetDouble(3)
                    });
            }

            return returnList;
        }

        private NpgsqlCommand BuildSqlCommand(Coordinate coordinate)
        {
            var cmd =
                new NpgsqlCommand(
                    $"INSERT INTO {_table}(time, latitude, longitude) VALUES (@time, @latitude, @longitude)");
            cmd.Parameters.AddWithValue("time", coordinate.Time);
            cmd.Parameters.AddWithValue("latitude", coordinate.Latitude);
            cmd.Parameters.AddWithValue("longitude", coordinate.Longitude);
            return cmd;
        }
    }
}
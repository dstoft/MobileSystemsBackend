using System;
using Npgsql;

namespace MobileSystemsBackend.Infrastructure.Migrations
{
    public static class Database
    {
        public static void EnsureDatabase(string connectionString, string name)
        {
            Console.WriteLine(connectionString);
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();

            var doesDatabaseExist = false;
            using (var cmd = new NpgsqlCommand("SELECT * FROM pg_catalog.pg_database WHERE datname = @name", conn))
            {
                cmd.Parameters.AddWithValue("name", name);
                using var reader = cmd.ExecuteReader();
                if (reader.HasRows) doesDatabaseExist = true;
            }

            if (!doesDatabaseExist)
            {
                using var cmd = new NpgsqlCommand("CREATE DATABASE " + name, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
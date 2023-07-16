using System;
using Npgsql;
using Dapper;
namespace RoviPractic.DAL
{
    public class Helper
    {
        public static string ConnString = "User ID=postgres;Password=password;Host=localhost;Port=5432;Database=postgres";

        public static async Task<int> ExecuteScalarAsync(string sql, object model)
        {
            using (var connection = new NpgsqlConnection(Helper.ConnString))
            { 
                await connection.OpenAsync();

                return await connection.ExecuteAsync(sql, model);
            }
        }

        public static async Task<IEnumerable<T>> QueryAsync<T>(string sql, object model)
        {
            using (var connection = new NpgsqlConnection(Helper.ConnString))
            {
                await connection.OpenAsync();

                return await connection.QueryAsync<T>(sql, model);
            }
        }
    }
}


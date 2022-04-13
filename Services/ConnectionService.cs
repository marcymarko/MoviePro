using Microsoft.Extensions.Configuration;
using Npgsql;
using System;

namespace MoviePro.Services
{
    public class ConnectionService  
    {
        public static string GetConnectionString(IConfiguration configuration)  // the body of the GetConnectionString method will determine
            // which connection string to retunr to requester
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL"); // determines if were running locally

            return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl); //  asks questions, is databaseUrl string
            // empty, if it is, we're running locally. if not empty,we're running remotely
        }

        private static string BuildConnectionString(string databaseUrl)
        {
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };
            return builder.ToString();
        }
    }
}

using CrudSqlServerDapper.Configs;
using CrudSqlServerDapper.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSqlServerDapper.Repositories
{
    public class ClientRepository
    {
        private Configuration _configuration = new Configuration();

        public void Insert(Client client)
        {
            var query = "INSERT INTO Clients (Id, Name, Email, BirthDate) VALUES (@Id, @Name, @Email, @BirthDate)";

            using (var connection = new SqlConnection(_configuration.Connectionstring))
            {
                connection.Execute(query, client);
            }
        }
    }
}

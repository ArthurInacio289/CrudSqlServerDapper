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
        public List<Client> GetAll()
        {
            var query = "SELECT * FROM Clients";
            using (var connection = new SqlConnection(_configuration.Connectionstring))
            {
                return connection.Query<Client>(query).ToList();
            }
        }
        
        public void Update(Client client)
        {
            var query = "UPDATE Clients SET Name = @Name, Email = @Email, BirthDate = @BirthDate WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.Connectionstring))
            {
                connection.Execute(query, client);
            }
        }
        public void Delete(int id)
        {
            var query = "DELETE FROM Clients WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.Connectionstring))
            {
                connection.Execute(query, new { Id = id });
            }
        }
        public Client Get(int id)
        {
            var query = "SELECT * FROM Clients WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.Connectionstring))
            {
                return connection.QueryFirstOrDefault<Client>(query, new { Id = id });
            }
        }
    }
}

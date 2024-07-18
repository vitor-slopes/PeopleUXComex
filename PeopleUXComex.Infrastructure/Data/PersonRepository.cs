using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using PeopleUXComex.Core.Entities;
using PeopleUXComex.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace PeopleUXComex.Infrastructure.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _connectionString;

        public PersonRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Person>("SELECT * FROM Person");
            }
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Person>("SELECT * FROM Person WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task AddAsync(Person person)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Person (Name, Phone, CPF) VALUES (@Name, @Phone, @CPF)";
                await connection.ExecuteAsync(sql, person);
            }
        }

        public async Task UpdateAsync(Person person)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE Person SET Name = @Name, Phone = @Phone, CPF = @CPF WHERE Id = @Id";
                await connection.ExecuteAsync(sql, person);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Person WHERE Id = @Id";
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}

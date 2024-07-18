using Dapper;
using PeopleUXComex.Core.Entities;
using PeopleUXComex.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleUXComex.Infrastructure.Data
{
    public class AddressRepository : IAddressRepository
    {
        private readonly string _connectionString;

        public AddressRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Address>> GetByPersonIdAsync(int personId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Addresses WHERE PersonId = @PersonId";
                return await connection.QueryAsync<Address>(sql, new { PersonId = personId });
            }
        }

        public async Task<Address?> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Addresses WHERE Id = @Id";
                return await connection.QueryFirstOrDefaultAsync<Address>(sql, new { Id = id });
            }
        }

        public async Task AddAsync(Address address)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Addresses (Street, CEP, City, State, PersonId) VALUES (@Street, @CEP, @City, @State, @PersonId)";
                await connection.ExecuteAsync(sql, address);
            }
        }

        public async Task UpdateAsync(Address address)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE Addresses SET Street = @Street, CEP = @CEP, City = @City, State = @State WHERE Id = @Id";
                await connection.ExecuteAsync(sql, address);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Addresses WHERE Id = @Id";
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}

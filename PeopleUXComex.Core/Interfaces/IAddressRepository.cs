using PeopleUXComex.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleUXComex.Core.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetByPersonIdAsync(int personId);
        Task AddAsync(Address address);
        Task<Address> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Address address);
        Task DeleteAsync(int id);
    }
}

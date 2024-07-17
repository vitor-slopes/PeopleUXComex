using PeopleUXComex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleUXComex.Core.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetByPersonIdAsync(int personId);
        Task<Address> GetByIdAsync(int id);
        Task AddAsync(Address address);
        Task UpdateAsync(Address address);
        Task DeleteAsync(int id);
    }
}

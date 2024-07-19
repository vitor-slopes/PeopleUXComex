using PeopleUXComex.Core.Entities;
using PeopleUXComex.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PeopleUXComex.Infrastructure.Data
{
    public class AddressRepository : IAddressRepository
    {
        private readonly PeopleUXComexContext _context;

        public AddressRepository(PeopleUXComexContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetByPersonIdAsync(int personId)
        {
            return await _context.Addresses.Where(a => a.PersonId == personId).ToListAsync();
        }

        public async Task AddAsync(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task DeleteAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
            }
        }
    }
}

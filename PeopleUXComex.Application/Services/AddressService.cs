using PeopleUXComex.Core.Entities;
using PeopleUXComex.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleUXComex.Application.Services
{
    public class AddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<Address>> GetByPersonIdAsync(int personId)
        {
            return await _addressRepository.GetByPersonIdAsync(personId);
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            return await _addressRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Address address)
        {
            await _addressRepository.AddAsync(address);
        }

        public async Task UpdateAsync(Address address)
        {
            await _addressRepository.UpdateAsync(address);
        }

        public async Task DeleteAsync(int id)
        {
            await _addressRepository.DeleteAsync(id);
        }
    }
}

using PeopleUXComex.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleUXComex.Core.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person> GetByIdAsync(int id);
        Task AddAsync(Person person);
        Task<bool> UpdateAsync(Person person);
        Task DeleteAsync(int id);
    }
}

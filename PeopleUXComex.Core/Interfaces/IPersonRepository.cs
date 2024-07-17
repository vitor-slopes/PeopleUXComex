using PeopleUXComex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleUXComex.Core.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person> GetByIdAsync(int id);
        Task AddAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(int id);
    }
}

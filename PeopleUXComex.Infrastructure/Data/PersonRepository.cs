using PeopleUXComex.Core.Entities;
using PeopleUXComex.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PeopleUXComex.Infrastructure.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PeopleUXComexContext _context;

        public PersonRepository(PeopleUXComexContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task AddAsync(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task DeleteAsync(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }
}

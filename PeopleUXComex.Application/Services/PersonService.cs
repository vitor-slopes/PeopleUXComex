﻿using PeopleUXComex.Core.Entities;
using PeopleUXComex.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleUXComex.Application.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _personRepository.GetAllAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _personRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Person person)
        {
            await _personRepository.AddAsync(person);
        }

        public async Task UpdateAsync(Person person)
        {
            await _personRepository.UpdateAsync(person);
        }

        public async Task DeleteAsync(int id)
        {
            await _personRepository.DeleteAsync(id);
        }
    }
}
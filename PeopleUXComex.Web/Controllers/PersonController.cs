using Microsoft.AspNetCore.Mvc;
using PeopleUXComex.Application.Services;
using PeopleUXComex.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleUXComex.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            var people = await _personService.GetAllAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                await _personService.AddAsync(person);
                return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _personService.UpdateAsync(person);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            await _personService.DeleteAsync(id);
            return NoContent();
        }
    }
}
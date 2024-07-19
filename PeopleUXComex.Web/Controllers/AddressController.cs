using Microsoft.AspNetCore.Mvc;
using PeopleUXComex.Application.Services;
using PeopleUXComex.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleUXComex.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("{personId}")]
        public async Task<ActionResult<IEnumerable<Address>>> GetByPersonId(int personId)
        {
            var addresses = await _addressService.GetByPersonIdAsync(personId);
            if (addresses == null)
            {
                return NotFound();
            }
            return Ok(addresses);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Address address)
        {
            if (ModelState.IsValid)
            {
                await _addressService.AddAsync(address);
                return CreatedAtAction(nameof(GetByPersonId), new { personId = address.PersonId }, address);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("edit/{id}")]
        public async Task<ActionResult<Address>> Edit(int id)
        {
            var address = await _addressService.GetByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _addressService.UpdateAsync(address);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult<Address>> Delete(int id)
        {
            var address = await _addressService.GetByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var address = await _addressService.GetByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            await _addressService.DeleteAsync(id);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeopleUXComex.Application.Services;
using PeopleUXComex.Core.Entities;
using PeopleUXComex.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleUXComex.Web.Controllers
{
    public class PersonViewController : Controller
    {
        private readonly PersonService _personService;
        private readonly AddressService _addressService;
        private readonly ILogger<PersonViewController> _logger;

        public PersonViewController(PersonService personService, AddressService addressService, ILogger<PersonViewController> logger)
        {
            _personService = personService;
            _addressService = addressService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var people = await _personService.GetAllAsync();
            return View(people);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person person)
        {
            ModelState.Remove("Addresses");

            if (ModelState.IsValid)
            {
                await _personService.AddAsync(person);
                return RedirectToAction(nameof(Edit), new { id = person.Id });
            }
            else
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors)
                                       .Select(x => x.ErrorMessage)
                                       .ToList();
                _logger.LogError("Model state is invalid. Errors: {@Errors}", errors);
            }
            return View(person);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            var addresses = await _addressService.GetByPersonIdAsync(id);
            var viewModel = new EditPersonViewModel
            {
                Person = person,
                Addresses = addresses.ToList() // Conversão explícita para List<Address>
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var success = await _personService.UpdateAsync(person);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAddress(Address address)
        {
            _logger.LogInformation("Attempting to add address: {@Address}", address);

            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model state is valid for address: {@Address}", address);
                await _addressService.AddAsync(address);
                return RedirectToAction(nameof(Edit), new { id = address.PersonId });
            }
            else
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors)
                                       .Select(x => x.ErrorMessage)
                                       .ToList();
                _logger.LogError("Model state is invalid for address. Errors: {@Errors}", errors);
            }
            return RedirectToAction(nameof(Edit), new { id = address.PersonId });
        }

        // Método para deletar uma pessoa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _personService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting person with id {PersonId}", id);
                return RedirectToAction(nameof(Index), new { errorMessage = "Error deleting person." });
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PeopleUXComex.Application.Services;
using PeopleUXComex.Core.Entities;

namespace PeopleUXComex.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        public async Task<ActionResult> Index()
        {
            var people = await _personService.GetAllAsync();
            return View(people);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                await _personService.AddAsync(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                await _personService.UpdateAsync(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _personService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
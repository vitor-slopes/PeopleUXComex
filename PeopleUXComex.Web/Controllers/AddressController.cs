using Microsoft.AspNetCore.Mvc;
using PeopleUXComex.Application.Services;
using PeopleUXComex.Core.Entities;
using System.Threading.Tasks;

namespace PeopleUXComex.Web.Controllers
{
    public class AddressController : Controller
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<ActionResult> Index(int personId)
        {
            var addresses = await _addressService.GetByPersonIdAsync(personId);
            ViewBag.PersonId = personId;
            return View(addresses);
        }

        public ActionResult Create(int personId)
        {
            ViewBag.PersonId = personId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Address address)
        {
            if (ModelState.IsValid)
            {
                await _addressService.AddAsync(address);
                return RedirectToAction("Index", new { personId = address.PersonId });
            }
            return View(address);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var address = await _addressService.GetByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                await _addressService.UpdateAsync(address);
                return RedirectToAction("Index", new { personId = address.PersonId });
            }
            return View(address);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var address = await _addressService.GetByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id, int personId)
        {
            await _addressService.DeleteAsync(id);
            return RedirectToAction("Index", new { personId });
        }
    }
}

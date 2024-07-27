using Microsoft.AspNetCore.Mvc;
using PeopleUXComex.Web.Models;
using System.Diagnostics;

namespace PeopleUXComex.Web.Controllers
{    
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")] // Rota para a action Index: /Home ou /Home/Index
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] // Rota para a action Privacy: /Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet] // Rota para a action Error: /Home/Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

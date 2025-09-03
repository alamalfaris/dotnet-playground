using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_mvc_playground.Models;
using web_mvc_playground.Repositories;

namespace web_mvc_playground.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPubsRepository _pubsRepository;

        public HomeController(ILogger<HomeController> logger, IPubsRepository pubsRepository)
        {
            _logger = logger;
            _pubsRepository = pubsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("authors")]
        public async Task<IActionResult> GetAllAuthorsAsync()
        {
            var authors = await _pubsRepository.GetAllAuthorsAsync();
            return Ok(authors);
        }
    }
}

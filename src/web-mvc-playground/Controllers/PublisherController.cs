using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using web_mvc_playground.Repositories;

namespace web_mvc_playground.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPubsRepository _pubsRepository;

        public PublisherController(IPubsRepository pubsRepository)
        {
            _pubsRepository = pubsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var publishers = await _pubsRepository.GetAllPublisherAsync();
            return View(publishers);
        }

        [HttpGet("{id}/logo")]
        public async Task<IActionResult> GetLogoByIdAsync(string id)
        {
            var publisher = await _pubsRepository.GetPublisherById(id);
            if (publisher is null 
                || publisher.Logo is null)
            {
                return NotFound();
            }

            return File(publisher.Logo, "image/png");
        }
    }
}

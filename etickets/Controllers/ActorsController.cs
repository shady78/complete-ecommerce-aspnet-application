using etickets.Data.Services;
using etickets.Models;
//using etickets.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace etickets.Controllers
{
    public class ActorsController : Controller
    {
        //private readonly AppDbContext _context;
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _service.Add(actor);
            return RedirectToAction(nameof(Index));
        }

    }
}

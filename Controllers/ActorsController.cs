using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allActors = await _service.GetAllAsync();
            return View(allActors);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Actor actor)
        {
             await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var actorsDetails = await _service.GetByIdAsync(id);

            if (actorsDetails == null) return View("NotFound");
            return View(actorsDetails);
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorsDetails = await _service.GetByIdAsync(id);

            if (actorsDetails == null) return View("NotFound");
            return View(actorsDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureURL,FullName,Bio")] Actor actor)
        {
            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delate/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorsDetails = await _service.GetByIdAsync(id);
            if (actorsDetails == null) return View("NotFound");
            return View(actorsDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DelateConfirmed(int id)
        {
            var actorsDetails = await _service.GetByIdAsync(id);
            if (actorsDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

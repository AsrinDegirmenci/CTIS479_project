#nullable disable
using Business.Models;
using Business.Services;
using DataAccess.Entities;
using DataAccess.Results.Bases;
using Microsoft.AspNetCore.Mvc;
using MVC.Controllers.BaseController;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class GamesController : MvcController
    {
        // TODO: Add service injections here
        private readonly IGamesService _gamesService;

        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        // GET: Games
        public IActionResult Index()
        {
            List<GamesModel> gamesList = _gamesService.Query().ToList(); // TODO: Add get collection service logic here
            return View(gamesList);
        }

        // GET: Games/Details/5
        public IActionResult Details(int id)
        {
            GamesModel games = _gamesService.Query().SingleOrDefault(g => g.Id == id); // TODO: Add get item service logic here
            if (games == null)
            {
                return NotFound();// 404 HTTP Status Code
            }
            return View(games);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GamesModel games)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                Result result = _gamesService.Add(games);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index),"Games");
                }
                ModelState.AddModelError("", result.Message);
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(games);
        }

        // GET: Games/Edit/5
        public IActionResult Edit(int id)
        {
            GamesModel games = _gamesService.Query().SingleOrDefault(g => g.Id == id); // TODO: Add get item service logic here
            if (games == null)
            {
                return NotFound();
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(games);
        }

        // POST: Games/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GamesModel games)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                Result result = _gamesService.Update(games);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = games.Id});
                }
                ModelState.AddModelError("", result.Message);
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(games);
        }

        // GET: Games/Delete/5
        public IActionResult Delete(int id)
        {
            GamesModel games = _gamesService.Query().SingleOrDefault(g => g.Id == id); // TODO: Add get item service logic here
            if (games == null)
            {
                return NotFound();
            }
            return View(games);
        }

        // POST: Games/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            Result result = _gamesService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}

#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;
using Business.Services;
using Business.Models;
using MVC.Controllers.BaseController;
using Microsoft.AspNetCore.Authorization;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class ReviewersController : MvcController
    {
        // TODO: Add service injections here
        private readonly IReviewerService _reviewerService;
        private readonly IHobbyService _hobbyService;

		public ReviewersController(IReviewerService reviewerService, IHobbyService hobbyService)
		{
			_reviewerService = reviewerService;
			_hobbyService = hobbyService;
		}

		// GET: Reviewers
		public IActionResult Index()
        {
            List<ReviewerModel> reviewerList = _reviewerService.GetList(); // TODO: Add get collection service logic here
            return View(reviewerList);
        }

        // GET: Reviewers/Details/5
        public IActionResult Details(int id)
        {
            ReviewerModel reviewer = _reviewerService.GetItem(id); // TODO: Add get item service logic here
            if (reviewer == null)
            {
                return View("Error", "Reviewer Not Found!");
            }
            return View(reviewer);
        }

        // GET: Reviewers/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewBag.Hobbies = new MultiSelectList(_hobbyService.Query().ToList(), "Id", "Name");
            return View();
        }

        // POST: Reviewers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReviewerModel reviewer)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                var result = _reviewerService.Add(reviewer);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
					return RedirectToAction(nameof(Details), new { id = reviewer.Id});
				}
                ModelState.AddModelError("", result.Message);
			}
			// TODO: Add get related items service logic here to set ViewData if necessary
			ViewBag.Hobbies = new MultiSelectList(_hobbyService.Query().ToList(), "Id", "Name");
			return View(reviewer);
        }

        // GET: Reviewers/Edit/5
        public IActionResult Edit(int id)
        {
            ReviewerModel reviewer = _reviewerService.GetItem(id); // TODO: Add get item service logic here
            if (reviewer == null)
            {
                return View("Error", "Reviewer Not Found!");
            }
			// TODO: Add get related items service logic here to set ViewData if necessary
			ViewBag.Hobbies = new MultiSelectList(_hobbyService.Query().ToList(), "Id", "Name");
			return View(reviewer);
        }

        // POST: Reviewers/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ReviewerModel reviewer)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                var result = _reviewerService.Update(reviewer);
                if (result.IsSuccessful)
                {
					TempData["Message"] = result.Message;
					return RedirectToAction(nameof(Details), new { id = reviewer.Id });
				}
				ModelState.AddModelError("", result.Message);
			}
			// TODO: Add get related items service logic here to set ViewData if necessary
			ViewBag.Hobbies = new MultiSelectList(_hobbyService.Query().ToList(), "Id", "Name");
			return View(reviewer);
        }

        // GET: Reviewers/Delete/5
        public IActionResult Delete(int id)
        {
            ReviewerModel reviewer = _reviewerService.GetItem(id); // TODO: Add get item service logic here
            if (reviewer == null)
            {
                return NotFound();
            }
            return View(reviewer);
        }

        // POST: Reviewers/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            var result = _reviewerService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}

using DoSmart.Models;
using DoSmart.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DoSmart.Controllers
{
    public class ActivitiesController : Controller
    {
        public ActivitiesController()
        {
            _context = new ApplicationDbContext();
        }

        public ApplicationDbContext _context { get; set; }


        public ActionResult Create()
        {
            var viewModel = new ActivityFormViewModel();
            viewModel.ImportanceCategories = _context.ImportanceCategories.ToList();
            viewModel.PageHeader = "Add an Activity";
            return View("ActivityForm",viewModel);
        }
        [HttpPost]
        public ActionResult Create(ActivityFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.PageHeader = "Add an Activity";
                return View("ActivityForm", viewModel);
            }
            var activity = new Activity()
            {
                Title = viewModel.Title,
                Content = viewModel.Content,
                CreatorId = User.Identity.GetUserId(),
                Date = DateTime.Now,
                ImportanceCategoryId = viewModel.ImportanceCategoryId
            };

            _context.Activities.Add(activity);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
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

        [Authorize]
        public ActionResult Create(int id)
        {
            var viewModel = new ActivityFormViewModel()
            {
                ImportanceCategories = _context.ImportanceCategories.ToList(),
                ProjectId = id,
                PageHeader = "Add Activity",
                Action = "Create"
            };

            return View("ActivityForm",viewModel);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Create(ActivityFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.ImportanceCategories = _context.ImportanceCategories.ToList();
                viewModel.PageHeader = "Add an Activity";
                return View("ActivityForm", viewModel);
            }

            var project = _context.Projects.SingleOrDefault(p => p.Id == viewModel.ProjectId);
            if (project == null)
                return HttpNotFound();
            if (project.CreatorId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            var activity = new Activity()
            {
                Title = viewModel.Title,
                Content = viewModel.Content,
                CreatorId = User.Identity.GetUserId(),
                ProjectId = viewModel.ProjectId,
                Date = DateTime.Now,
                ImportanceCategoryId = viewModel.ImportanceCategoryId
            };

            _context.Activities.Add(activity);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home", new { id = viewModel.ProjectId} );
        }



        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var activity = _context.Activities.SingleOrDefault(a => a.Id == id);
            if (activity == null)
                return HttpNotFound();
            if (activity.CreatorId != userId)
                return new HttpUnauthorizedResult();

            var viewModel = new ActivityFormViewModel()
            {
                Id = activity.Id,
                Title = activity.Title,
                Content = activity.Content,
                ProjectId = activity.ProjectId,
                ImportanceCategoryId = activity.ImportanceCategoryId,
                ImportanceCategories = _context.ImportanceCategories.ToList(),
                PageHeader = "Edit Activity",
                Action = "Edit"
            };

            return View("ActivityForm", viewModel);
        }



        [Authorize]
        [HttpPost]
        public ActionResult Edit(ActivityFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.ImportanceCategories = _context.ImportanceCategories.ToList();
                viewModel.PageHeader = "Add an Activity";
                return View("ActivityForm", viewModel);
            }

            var activity = _context.Activities.SingleOrDefault(a => a.Id == viewModel.Id);

            if (activity == null)
                return HttpNotFound();
            if (activity.CreatorId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            activity.Title = viewModel.Title;
            activity.Content = viewModel.Content;
            activity.Date = DateTime.Now;
            activity.ImportanceCategoryId = viewModel.ImportanceCategoryId;
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Home", new { id = viewModel.ProjectId });
        }
    }
}
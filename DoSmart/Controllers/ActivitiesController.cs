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
        public ActionResult Create()
        {
            var viewModel = new ActivityFormViewModel();
            viewModel.ImportanceCategories = _context.ImportanceCategories.ToList();
            viewModel.PageHeader = "Add an Activity";
            viewModel.Action = "Create";
            return View("ActivityForm",viewModel);
        }


        [Authorize]
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
            activity.CreatorId = User.Identity.GetUserId();
            activity.Date = DateTime.Now;
            activity.ImportanceCategoryId = viewModel.ImportanceCategoryId;
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
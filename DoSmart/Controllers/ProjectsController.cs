﻿using DoSmart.Models;
using DoSmart.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace DoSmart.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext _context;

        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ProjectFormViewModel() {
                PageHeader = "Add Project"
            };
            return View("ProjectForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(ProjectFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("ProjectForm", viewModel);
            }

            var newProject = new Project()
            {
                CreatorId = User.Identity.GetUserId(),
                Title = viewModel.Title,
                Date = DateTime.Now                
            };

            _context.Projects.Add(newProject);
            _context.SaveChanges();            

            return RedirectToAction("Index", "Home", new { id = newProject.Id });
        }
    }
}